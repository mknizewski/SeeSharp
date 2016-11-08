using SeeSharp.BO.Dictionaries;
using SeeSharp.ServiceReference1;
using System.Windows;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        public WelcomePage(Visibility visibility)
        {
            InitializeComponent();
            textBox.Text = AppSettingsDictionary.HelloWorldProgram;
            LayoutRoot.Visibility = visibility;
        }

        private void CompileButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CompileButton.Content = "Proszę czekać";
            CompileButton.IsEnabled = false;

            ServerServiceClient serverService = ServerServiceClient.GetInstance();
            serverService.CompileAndRunProgramAsync(textBox.Text, new System.Collections.Generic.List<string>());

            serverService.CompileAndRunProgramCompleted += (send, recv) => 
            {
                outputText.Text = recv.Result;

                CompileButton.Content = "Kompiluj & Uruchom";
                CompileButton.IsEnabled = true;
            };
        }
    }
}