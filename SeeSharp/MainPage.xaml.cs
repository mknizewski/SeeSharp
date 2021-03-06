﻿using SeeSharp.BO.Dictionaries;
using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using SeeSharp.ServiceReference1;
using System;
using System.Collections.Generic;
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
            GC.Collect();
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
            SetView(ViewType.AboutCourse, NavigationDictionary.AboutAuthorsView);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignOut();
            UserManager = null;

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

        public void SetAlert(string message)
        {
            ViewFactory.GetAlert(message).Show();
        }

        public void SetAchivmentAlert(Achivments achivments)
        {
            ServerServiceClient serverService = ServerServiceClient.GetInstance();
            serverService.GetAchivmentFileAsync(UserManager.UserInfo.Login);
            serverService.GetAchivmentFileCompleted += (send, recv) =>
            {
                List<int> achivList = recv.Result;
                int achivId = (int)achivments;

                if (achivList != null)
                {
                    if (!achivList.Contains(achivId))
                        ViewFactory.GetAchivmentAlert(achivments).Show();
                }
                else
                    ViewFactory.GetAchivmentAlert(achivments).Show();
            };
        }

        public void SetModule(string tag)
        {
            UserControl modulePage = ViewFactory.GetModule(tag);

            this.DynamicView.Children.Clear();
            this.DynamicView.Children.Add(modulePage);
            this.DynamicView.UpdateLayout();
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

                this.ProgressTextViewBox.Visibility = Visibility.Collapsed;
                this.ProgressCircleViewBox.Visibility = Visibility.Collapsed;
                this.ProgressPercentageViewBox.Visibility = Visibility.Collapsed;
                this.ProgressPercentageTextBlock.Visibility = Visibility.Collapsed;

                this.LoginName.Text = AppSettingsDictionary.UnllogedAlert;
            }
        }

        private void WelcomePageButtonMenuButton_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.WelcomePage, NavigationDictionary.WelcomePageView);
        }

        private void LayoutRoot_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int fullScreenIndex = 1;

            if (e.Key == System.Windows.Input.Key.Escape)
            {
                try
                {
                    UIElement element = this.LayoutRoot.Children[fullScreenIndex];

                    if (element is ModulePage)
                        (element as ModulePage).ChangeScreen();
                }
                catch (ArgumentOutOfRangeException)
                { }
            }
        }
    }
}