using SeeSharp.Infrastructure;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class UserProfile : UserControl
    {
        public UserProfile()
        {
            InitializeComponent();
            FillTextBlocks();
        }

        private void FillTextBlocks()
        {
            MainPage mainView = ViewFactory.MainPageInstance;

            this.AccountNameTextBlock.Text = string.Format(AccountNameTextBlock.Text, mainView.UserManager.UserInfo.Login);
            this.CodeTextBlock.Text = string.Format(CodeTextBlock.Text, mainView.UserManager.UserInfo.Code);
            this.PercentageTextBlock.Text = string.Format(PercentageTextBlock.Text, mainView.UserManager.UserInfo.Percentage);
            this.LastModuleTextBlock.Text = string.Format(LastModuleTextBlock.Text, mainView.UserManager.UserInfo.LastTutorial);
        }

        private void DeleteAccountButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void NewModuleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
