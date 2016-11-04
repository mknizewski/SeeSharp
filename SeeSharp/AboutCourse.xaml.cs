using System;
using System.Windows.Browser;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class AboutCourse : UserControl
    {
        public AboutCourse()
        {
            InitializeComponent();
            string myRelativePath = @"/Content/MovieCourses/First_movie.htm";
            string pathToVegas = @"/Content/MovieCourses/testVegass.wmv";
            Uri myAbsoluteUri = new Uri(HtmlPage.Document.DocumentUri, myRelativePath);
            link.NavigateUri = myAbsoluteUri;

            media.Source = new Uri(HtmlPage.Document.DocumentUri, pathToVegas);
            media.Play();
        }
    }
}