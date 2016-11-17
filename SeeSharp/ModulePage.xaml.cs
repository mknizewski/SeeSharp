using SeeSharp.BO.Managers;
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
        private ModuleManager _moduleManager;
        private MediaViewModel _viewModel;
        private enum ButtonState { Play, Pause, Restart }

        public ModulePage(string moduleName, string tag)
        {
            _moduleManager = ModuleManager.GetModuleManager(moduleName, tag);

            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            this.ModuleTitle.Text = _moduleManager.ModuleName;

            string pathToVegas = @"/Content/MovieCourses/testVegass.wmv";
            this.media.Source = new Uri(HtmlPage.Document.DocumentUri, pathToVegas);

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
            statusText.Visibility = Visibility.Collapsed;
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
            statusText.Visibility = Visibility.Visible;
            statusText.Text = media.CurrentState.ToString();
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
    }
}
