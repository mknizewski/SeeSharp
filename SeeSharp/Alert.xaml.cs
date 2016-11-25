using System.Windows;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class Alert : ChildWindow
    {
        public Alert(string message)
        {
            InitializeComponent();
            this.MessageBox.Text = message;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}