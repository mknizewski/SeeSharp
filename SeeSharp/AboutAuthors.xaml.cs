using System;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class AboutAuthors : UserControl
    {
        private const string CopyRightInfoPattern = "Białystok, {0}";

        public AboutAuthors()
        {
            this.InitializeComponent();
            this.CopyrightInformation.Text = string.Format(CopyRightInfoPattern, DateTime.Now.Year.ToString());
            this.Focus();
        }
    }
}