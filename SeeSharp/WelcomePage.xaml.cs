using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using System;
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
                    this.CodeTextBlock.Text = string.Format(CodeTextBlock.Text, mainView.UserManager.UserInfo.Code);
                    this.PercentageTextBlock.Text = string.Format(PercentageTextBlock.Text, mainView.UserManager.UserInfo.Percentage);
                    this.LastModuleTextBlock.Text = string.Format(LastModuleTextBlock.Text, mainView.UserManager.UserInfo.LastTutorial);
                    this.CuriositiesTextBox.Text = CuriositiesManager.GetRandomCuriosities();
                    this.GreetingsTextBlock.Text = GreetingsManager.GetGreetingsByDayOfWeek(DateTime.Now.DayOfWeek, mainView.UserManager.UserInfo.Login);
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

        private void PervButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.CuriositiesTextBox.Text = CuriositiesManager.GetPervCuriosities();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.CuriositiesTextBox.Text = CuriositiesManager.GetNextCuriosities();
        }

        #region Modules & ModuleEvents

        private void LoadModule(TreeViewItem selectedItem)
        {
            if (selectedItem != null)
            {
                string moduleName = selectedItem.Header.ToString();
                string tag = selectedItem.Tag.ToString();

                ViewFactory.MainPageInstance.SetModule(moduleName, tag);
            }
        }

        private TreeViewItem GetSelectedItem(object sender)
        {
            TreeViewItem list = sender as TreeViewItem;
            TreeViewItem selectedModule = null;

            list.Items.Cast<TreeViewItem>().ToList().ForEach(module =>
            {
                if (module.IsSelected)
                    selectedModule = module;
            });

            return selectedModule;
        }

        private void LoadInnerModule_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            LoadModule(GetSelectedItem(sender));
        }

        private void LoadTopModule_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TreeViewItem selectedModule = sender as TreeViewItem;
            LoadModule(selectedModule);
        }

        #endregion Modules & ModuleEvents
    }
}