using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private void Menu_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TreeViewItem selected = GetSelectedItem(sender);

            if (selected != null)
                System.Windows.Browser.HtmlPage.Window.Eval("alert('" + selected.Header + "');");
        }

        private TreeViewItem GetSelectedItem(object sender)
        {
            TreeViewItem list = sender as TreeViewItem;
            TreeViewItem selected = null;

            list.Items.Cast<TreeViewItem>().ToList().ForEach(x =>
            {
                List<TreeViewItem> subList = x.Items.Cast<TreeViewItem>().ToList();

                subList.ForEach(y =>
                {
                    if (y.IsSelected)
                        selected = y;
                });
            });

            return selected;
        }
    }
}