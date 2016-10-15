using SeeSharp.BO.Dictionaries;
using SeeSharp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SeeSharp
{
    public partial class MainPage : UserControl
    {
        private const string SectionPrefix = "Jesteś w sekcji: ";

        public MainPage()
        {
            InitializeComponent();
            this.ProgressCircle.Percentage = 25.0;
            this.SectionBlock.Text = SectionPrefix + NavigationDictionary.MainView;
        }

        private void AboutAuthors_Click(object sender, RoutedEventArgs e)
        {
            this.DynamicView.Children.Clear();
            this.DynamicView.Children.Add(ViewFactory.GetView(ViewType.AboutAuthors));
            this.DynamicView.UpdateLayout();
            this.SectionBlock.Text = SectionPrefix + NavigationDictionary.AboutAuthorsView;
        }
    }
}
