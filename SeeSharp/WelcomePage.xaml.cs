using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using System;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            MainPage mainPage = ViewFactory.MainPageInstance;

            if (mainPage != null)
            {
                if (mainPage.UserManager != null)
                {
                    this.LayoutRoot.Visibility = System.Windows.Visibility.Visible;
                    this.GreetingsTextBlock.Text = GreetingsManager.GetGreetingsByDayOfWeek(DateTime.Now.DayOfWeek, mainPage.UserManager.UserInfo.Login);
                }
                else
                    this.LayoutRoot.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
                this.LayoutRoot.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}