using SeeSharp.BO.Dictionaries;
using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using SeeSharp.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class RegisterPage : UserControl
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Register_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string loginName = this.LoginBox.Text;

                if (string.IsNullOrEmpty(loginName))
                    throw new Exception(ExceptionDictionary.LoginNotFoundMessage);

                int generatedNumber = UserManager.GenerateCodeForNewUser();
                this.RegisterButton.IsEnabled = false;

                ServerServiceClient serverService = ServerServiceClient.GetInstance();
                serverService.CreateDirectoryForUserAsync(loginName, generatedNumber);

                this.RegisterAlert.Visibility = Visibility.Visible;
                this.RegisterAlert.Text = string.Format(
                    RegisterPageDictionary.SuccesfulRegisterMessagePattern,
                    loginName,
                    Environment.NewLine,
                    generatedNumber);

                this.LoginButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                this.RegisterAlert.Visibility = Visibility.Visible;
                this.RegisterAlert.Text = ex.Message;
            }
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            ViewFactory.MainPageInstance.SetView(ViewType.Login, NavigationDictionary.LoginPageView);
        }
    }
}