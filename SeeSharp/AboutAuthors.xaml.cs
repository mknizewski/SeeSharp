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
