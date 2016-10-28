﻿using SeeSharp.BO.Dictionaries;
using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using SeeSharp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class LoginPage : UserControl, IDisposable
    {
        private const string RegexNumberOnlyPattern = "[^0-9.-]+";

        public LoginPage()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            ;
        }

        private void LoginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                string loginName = this.LoginBox.Text;
                string loginCode = this.CodeBox.Text;
                MainPage root = ViewFactory.MainPageInstance;
                ServerServiceClient serverService = ServerServiceClient.GetInstance();

                if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(loginCode))
                    throw new ArgumentNullException(ExceptionDictionary.IncorrectLoginCreditentials);

                if (!IsTextAllowed(loginCode))
                    throw new Exception(ExceptionDictionary.CodeIsNotNumber);

                serverService.GetUserProfileAsync(loginName);
                serverService.GetUserProfileCompleted += (send, recive) => {

                    try
                    {
                        root.UserManager = ManagerFactory.GetManager<UserManager>();
                        root.UserManager.SignIn(recive.Result, loginCode);
                        root.LoginName.Text = root.UserManager.UserInfo.Login;

                        root.SetView(ViewType.WelcomePage, NavigationDictionary.WelcomePageView);
                        root.LoggedUserMenuView();
                    }
                    catch (Exception ex)
                    {
                        this.LoginAlert.Visibility = System.Windows.Visibility.Visible;
                        this.LoginAlert.Text = ex.Message;
                    }

                };
            }
            catch (Exception ex)
            {
                this.LoginAlert.Visibility = System.Windows.Visibility.Visible;
                this.LoginAlert.Text = ex.Message;
            }
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex(RegexNumberOnlyPattern);
            return !regex.IsMatch(text);
        }
    }
}
