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
            MainPage mainView = ViewFactory.MainPageInstance;

            if (mainView != null)
            {
                if (mainView.UserManager != null)
                {
                    this.LayoutRoot.Visibility = System.Windows.Visibility.Visible;
                    this.GreetingsTextBlock.Text = GreetingsManager.GetGreetingsByDayOfWeek(DateTime.Now.DayOfWeek, mainView.UserManager.UserInfo.Login);
                    this.CodeTextBlock.Text = string.Format(CodeTextBlock.Text, mainView.UserManager.UserInfo.Code);
                    this.PercentageTextBlock.Text = string.Format(PercentageTextBlock.Text, mainView.UserManager.UserInfo.Percentage);
                    this.LastModuleTextBlock.Text = string.Format(LastModuleTextBlock.Text, mainView.UserManager.UserInfo.LastTutorial);
                    this.CuriositiesTextBox.Text = CuriositiesManager.GetRandomCuriosities();
                }
                else
                    this.LayoutRoot.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
                this.LayoutRoot.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void DeleteAccountButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void NewModuleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

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

        private void PervButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.CuriositiesTextBox.Text = CuriositiesManager.GetPervCuriosities();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.CuriositiesTextBox.Text = CuriositiesManager.GetNextCuriosities();
        }
    }
}