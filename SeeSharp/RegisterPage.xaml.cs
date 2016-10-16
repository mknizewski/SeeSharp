using SeeSharp.BO.Dictionaries;
using SeeSharp.BO.Managers;
using SeeSharp.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class RegisterPage : UserControl
    {
        private const string SuccesfullRegisterMessagePattern = "Pomyślnie zarejestrowano konto o loginie {0}! \n\r Twój kod rejestracyjny to: {1}";

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
                    throw new ArgumentNullException(nameof(loginName), ExceptionDictionary.LoginNotFoundMessage);

                int generatedNumber = UserManager.GenerateCodeForNewUser();
                this.RegisterButton.IsEnabled = false;

                ServerServiceClient serverService = new ServerServiceClient();
                serverService.CreateDirectoryForUserAsync(loginName, generatedNumber);

                this.RegisterAlert.Visibility = Visibility.Visible;
                this.RegisterAlert.Text = string.Format(SuccesfullRegisterMessagePattern, loginName, generatedNumber);
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
        }
    }
}