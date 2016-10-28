using SeeSharp.BO.Managers;
using System;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class LoginPage : UserControl, IDisposable
    {
        private UserManager UserManager;

        public LoginPage()
        {
            InitializeComponent();
            UserManager = new UserManager();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void LoginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
