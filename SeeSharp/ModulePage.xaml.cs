using SeeSharp.BO.Dictionaries;
using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SeeSharp
{
    public partial class ModulePage : UserControl, IDisposable
    {
        private const double Width720p = 1280.0;
        private const double Height720p = 720;
        private const double Width480p = 854.0;
        private const double Height480p = 480.0;

        private ModuleManager _moduleManager;
        private MediaViewModel _viewModel;

        private enum ButtonState { Play, Pause, Restart }

        public ModulePage(string tag)
        {
            this._moduleManager = ModuleManager.GetModuleManager(tag);

            InitializeComponent();
            InitializeView();
            InitializeModule();
            AdjustMediaMaxResolution();
        }

        private void AdjustMediaMaxResolution()
        {
            double actualViewWidth = this.ActualWidth;
            double actualViewHeight = this.ActualHeight;
            double mediaWidth = double.NaN;
            double mediaHeight = double.NaN;

            mediaHeight = actualViewHeight >= Height720p ? Height720p : Height480p;
            mediaWidth = actualViewWidth >= Width720p ? Width720p : Width480p;

            this.media.MaxHeight = mediaHeight;
            this.media.MaxWidth = mediaWidth;
        }

        private void InitializeModule()
        {
            this.ModuleTitle.Text = _moduleManager.CurrentModule.ModuleName;
            this.ModuleTextBox.Text = AppSettingsDictionary.RandomText;

            string pathToVegas = string.Format(AppSettingsDictionary.VideoDirectory, "2_1_3");
            this.media.Source = new Uri(HtmlPage.Document.DocumentUri, pathToVegas);

            string pathToTemplateProgram = string.Format(AppSettingsDictionary.ProgramFilesDirectory, "ProgramTemplate");
            this.ProgramDownloadLink.NavigateUri = new Uri(HtmlPage.Document.DocumentUri, pathToTemplateProgram);

            this.PervModule.IsEnabled = !_moduleManager.First;
            this.NextModule.IsEnabled = !_moduleManager.Last;

            this.Scroll.ScrollToVerticalOffset(0.0);
            ViewFactory.MainPageInstance.SectionBlock.Text = string.Format(AppSettingsDictionary.SectionPrefixPattern, _moduleManager.CurrentModule.ModuleName);
        }

        private void InitializeView()
        {
            this.DataContext = this._viewModel = new MediaViewModel(this.media);

            this.media.MediaOpened += this.MediaOpened;
            this.media.MediaFailed += this.MediaFailed;
            this.media.CurrentStateChanged += this.MediaCurrentStateChanged;

            this._viewModel.PositionChanged += PositionChanged;
            this.media.DownloadProgressChanged += (s, e) => this.UpdateBufferBar();

            this.media.BufferingTime = TimeSpan.FromSeconds(1);
            this.UpdateStatusText();
            this.UpdatePlayPauseButton();
        }

        public void Dispose()
        {
            _moduleManager.Dispose();
            _moduleManager = null;
        }

        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            this._viewModel.UpdateDurationInfo();
        }

        private void playPauseButton_Click(object sender, RoutedEventArgs e)
        {
            var buttonState = (ButtonState)this.playPauseButton.Tag;
            if (buttonState == ButtonState.Play)
            {
                media.Play();
            }
            else if (buttonState == ButtonState.Pause)
            {
                media.Pause();
            }
            else if (buttonState == ButtonState.Restart)
            {
                media.Stop();
                media.Play();
            }
        }

        private void PositionChanged(object sender, EventArgs e)
        {
            this.UpdatePlayBar();
            this.UpdatePlayPauseButton();
        }

        private void PlayCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(playCanvas);
            var relativePosition = position.X / playCanvas.ActualWidth;

            media.Position = new TimeSpan((long)(media.NaturalDuration.TimeSpan.Ticks * relativePosition));
        }

        private void MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            errorText.Visibility = Visibility.Visible;
            errorText.Text = e.ErrorException.Message;
        }

        private void MediaCurrentStateChanged(object sender, RoutedEventArgs e)
        {
            this.UpdateStatusText();
            this.UpdatePlayPauseButton();
        }

        private void UpdatePlayBar()
        {
            if (media.NaturalDuration.TimeSpan != TimeSpan.Zero)
                playBar.Width = media.Position.TotalMilliseconds / media.NaturalDuration.TimeSpan.TotalMilliseconds * playCanvas.ActualWidth;
        }

        private void UpdateBufferBar()
        {
            Debug.WriteLine("offset: " + media.DownloadProgressOffset);
            Debug.WriteLine("progress: " + media.DownloadProgress);

            Canvas.SetLeft(playCanvas, media.DownloadProgressOffset * playCanvas.ActualWidth);
            bufferBar.Width = media.DownloadProgress * playCanvas.ActualWidth;
        }

        private void UpdateStatusText()
        {
            errorText.Visibility = Visibility.Collapsed;
        }

        private void UpdatePlayPauseButton()
        {
            this.playPauseButton.IsEnabled = true;
            this.playPauseButton.Tag = ButtonState.Play;

            if (media.Position == media.NaturalDuration && media.NaturalDuration.TimeSpan != TimeSpan.Zero)
            {
                this.playPauseButton.Tag = ButtonState.Restart;
                this.playPauseButton.Style = (Style)App.Current.Resources["ReplayButtonStyle"];
            }
            else if (media.CurrentState == MediaElementState.Playing)
            {
                this.playPauseButton.Tag = ButtonState.Pause;
                this.playPauseButton.Style = (Style)App.Current.Resources["PauseButtonStyle"];
            }
            else if (media.CurrentState == MediaElementState.Paused || media.CurrentState == MediaElementState.Stopped)
            {
                this.playPauseButton.Tag = ButtonState.Play;
                this.playPauseButton.Style = (Style)App.Current.Resources["PlayButtonStyle"];
            }
            else
                this.playPauseButton.IsEnabled = false;
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            ViewFactory.MainPageInstance.SetView(ViewType.WelcomePage, NavigationDictionary.WelcomePageView);
        }

        private void PervModule_Click(object sender, RoutedEventArgs e)
        {
            _moduleManager.ChangeModule(ActionModule.Perv);
            InitializeModule();
        }

        private void NextModule_Click(object sender, RoutedEventArgs e)
        {
            _moduleManager.ChangeModule(ActionModule.Next);
            InitializeModule();

            //ViewFactory.MainPageInstance.ProgressCircle.Percentage += 2.93;
            //ViewFactory.MainPageInstance.ProgressPercentageTextBlock.Text = Math.Ceiling(ViewFactory.MainPageInstance.ProgressCircle.Percentage).ToString() + " %";
        }
    }
}