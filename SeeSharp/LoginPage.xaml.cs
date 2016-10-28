using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
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
            UserManager = ManagerFactory.GetManager<UserManager>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void LoginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string loginName = this.LoginBox.Text;
            string loginCode = this.CodeBox.Text;
        }
    }
}
