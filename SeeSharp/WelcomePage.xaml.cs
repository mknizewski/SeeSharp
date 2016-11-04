using SeeSharp.BO.Dictionaries;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
            textBox.Text = AppSettingsDictionary.HelloWorldProgram;
        }

        private void CompileButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CompileButton.Content = "Proszę czekać";
            CompileButton.IsEnabled = false;

            ServiceReference1.ServerServiceClient serverService = ServiceReference1.ServerServiceClient.GetInstance();
            serverService.CompileAndRunProgramAsync(textBox.Text);

            serverService.CompileAndRunProgramCompleted += (send, recv) => 
            {
                outputText.Text = recv.Result;

                CompileButton.Content = "Kompiluj";
                CompileButton.IsEnabled = true;
            };
        }
    }
}