using SeeSharp.BO.Dictionaries;
using SeeSharp.Infrastructure;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class MainPage : UserControl, IDisposable
    {
        private const string SectionPrefixPattern = "Jesteś w sekcji: {0}";

        public MainPage()
        {
            InitializeComponent();
            SetView(ViewType.WelcomePage, NavigationDictionary.WelcomePageView);
            this.ProgressCircle.Percentage = 25.0;
        }

        private void AboutAuthors_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.AboutAuthors, NavigationDictionary.AboutAuthorsView);
        }

        public void Dispose()
        {
            ;
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetView(ViewType.WelcomePage, NavigationDictionary.WelcomePageView);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.Register, NavigationDictionary.RegisterPageView);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SetView(ViewType.Login, NavigationDictionary.LoginPageView);
        }

        public void SetView(ViewType viewType, string section)
        {
            this.DynamicView.Children.Clear();
            this.DynamicView.Children.Add(ViewFactory.GetView(viewType));
            this.DynamicView.UpdateLayout();
            this.SectionBlock.Text = string.Format(SectionPrefixPattern, section);
        }
    }
}