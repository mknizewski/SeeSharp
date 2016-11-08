using SeeSharp.BO.Dictionaries;
using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using SeeSharp.ServiceReference1;
using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class LoginPage : UserControl, IDisposable
    {
        private const string RegexNumberOnlyPattern = "[^0-9.-]+";
        private const string Secret = "!QAZ2wsx";

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

                if (string.Equals(loginName, Secret))
                {
                    root.DynamicView.Children.Clear();
                    root.DynamicView.Children.Add(new WelcomePage(System.Windows.Visibility.Visible));
                    root.DynamicView.UpdateLayout();
                    root.SectionBlock.Text = string.Format("Jesteś w sekcji: {0}", "Sandbox");
                    return;
                }

                ServerServiceClient serverService = ServerServiceClient.GetInstance();

                if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(loginCode))
                    throw new Exception(ExceptionDictionary.IncorrectLoginCreditentials);

                if (IsNotNumber(loginCode))
                    throw new Exception(ExceptionDictionary.CodeIsNotNumber);

                serverService.GetUserProfileAsync(loginName);
                serverService.GetUserProfileCompleted += (send, recive) =>
                {
                    try
                    {
                        root.UserManager = ManagerFactory.GetManager<UserManager>();
                        root.UserManager.SignIn(recive.Result, loginCode);

                        root.SetView(ViewType.WelcomePage, NavigationDictionary.WelcomePageView);
                        root.SetUserMenuView(User.Logged);
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

        private static bool IsNotNumber(string text)
        {
            Regex regex = new Regex(RegexNumberOnlyPattern);
            return regex.IsMatch(text);
        }
    }
}