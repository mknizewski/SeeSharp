using SeeSharp.BO.Dictionaries;
using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class MainPage : UserControl, IDisposable
    {
        private const string SectionPrefixPattern = "Jesteś w sekcji: {0}";
        private const string UnloggedAlert = "Niezalogowany";

        public UserManager UserManager;

        public MainPage()
        {
            InitializeComponent();
            SetView(ViewType.WelcomePage, NavigationDictionary.WelcomePageView);
            this.AppVersion.Text = string.Format(AppSettingsDictionary.AppVersionMessagePattern, AppSettingsDictionary.AppVersion);
        }

        private void AboutAuthors_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.AboutAuthors, NavigationDictionary.AboutAuthorsView);
        }

        public void Dispose()
        {
            ;
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetView(ViewType.WelcomePage, NavigationDictionary.WelcomePageView);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.Register, NavigationDictionary.RegisterPageView);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.Login, NavigationDictionary.LoginPageView);
        }

        private void AboutCourse_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.AboutCourse, NavigationDictionary.AboutCourseView);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignOut();
            SetUserMenuView(User.Unlogged);
            SetView(ViewType.WelcomePage, NavigationDictionary.WelcomePageView);
        }

        public void SetView(ViewType viewType, string section)
        {
            this.DynamicView.Children.Clear();
            this.DynamicView.Children.Add(ViewFactory.GetView(viewType));
            this.DynamicView.UpdateLayout();
            this.SectionBlock.Text = string.Format(SectionPrefixPattern, section);
        }

        public void SetUserMenuView(User user)
        {
            if (user == User.Logged)
            {
                this.LogOutButtonMenu.Visibility = Visibility.Visible;
                this.RegisterButtonMenu.Visibility = Visibility.Collapsed;
                this.LoginButtonMenu.Visibility = Visibility.Collapsed;

                this.ProgressTextViewBox.Visibility = Visibility.Visible;
                this.ProgressCircleViewBox.Visibility = Visibility.Visible;
                this.ProgressCircle.Percentage = UserManager.UserInfo.Percentage;

                this.LoginName.Text = UserManager.UserInfo.Login;
            }
            else
            {
                this.LogOutButtonMenu.Visibility = Visibility.Collapsed;
                this.LoginButtonMenu.Visibility = Visibility.Visible;
                this.RegisterButtonMenu.Visibility = Visibility.Visible;

                this.ProgressTextViewBox.Visibility = Visibility.Collapsed;
                this.ProgressCircleViewBox.Visibility = Visibility.Collapsed;

                this.LoginName.Text = UnloggedAlert;
            }
        }
    }

    public enum User
    {
        Logged, Unlogged
    }
}