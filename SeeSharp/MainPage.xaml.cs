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
            if (UserManager != null)
                SetView(ViewType.UserProfile, NavigationDictionary.UserProfileView);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.Register, NavigationDictionary.RegisterPageView);
        }

        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.UserProfile, NavigationDictionary.UserProfileView);
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
            UserControl view = ViewFactory.GetView(viewType);

            this.DynamicView.Children.Clear();
            this.DynamicView.Children.Add(view);
            this.DynamicView.UpdateLayout();

            this.SectionBlock.Text = string.Format(AppSettingsDictionary.SectionPrefixPattern, section);
        }

        public void SetUserMenuView(User user)
        {
            if (user == User.Logged)
            {
                this.LogOutButtonMenu.Visibility = Visibility.Visible;
                this.RegisterButtonMenu.Visibility = Visibility.Collapsed;
                this.LoginButtonMenu.Visibility = Visibility.Collapsed;
                this.MyProfileButtonMenu.Visibility = Visibility.Visible;

                this.ProgressTextViewBox.Visibility = Visibility.Visible;
                this.ProgressCircleViewBox.Visibility = Visibility.Visible;
                this.ProgressPercentageTextBlock.Visibility = Visibility.Visible;
                this.ProgressPercentageViewBox.Visibility = Visibility.Visible;

                this.ProgressCircle.Percentage = UserManager.UserInfo.Percentage;
                this.LoginName.Text = UserManager.UserInfo.Login;
                this.ProgressPercentageTextBlock.Text = string.Format(AppSettingsDictionary.PercentagePattern, UserManager.UserInfo.Percentage);
            }
            else
            {
                this.LogOutButtonMenu.Visibility = Visibility.Collapsed;
                this.LoginButtonMenu.Visibility = Visibility.Visible;
                this.RegisterButtonMenu.Visibility = Visibility.Visible;
                this.MyProfileButtonMenu.Visibility = Visibility.Collapsed;

                this.ProgressTextViewBox.Visibility = Visibility.Collapsed;
                this.ProgressCircleViewBox.Visibility = Visibility.Collapsed;
                this.ProgressPercentageViewBox.Visibility = Visibility.Collapsed;
                this.ProgressPercentageTextBlock.Visibility = Visibility.Collapsed;

                this.LoginName.Text = AppSettingsDictionary.UnllogedAlert;
            }
        }
    }
}