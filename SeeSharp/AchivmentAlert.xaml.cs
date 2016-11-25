using SeeSharp.BO.Dictionaries;
using SeeSharp.BO.Managers;
using SeeSharp.Infrastructure;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SeeSharp
{
    public partial class AchivmentAlert : ChildWindow
    {
        private Achivment _achivment;

        public AchivmentAlert(Achivment achivment)
        {
            this._achivment = achivment;

            InitializeComponent();
            InitializeAlert();
        }

        private void InitializeAlert()
        {
            string achivImageFileName = string.Format(AppSettingsDictionary.AchivmentImageDirectory, _achivment.File);
            Uri uri = new Uri(achivImageFileName, UriKind.Relative);

            this.AchivImage.Source = new BitmapImage(uri);
            this.TitleText.Text = _achivment.Title;
            this.DetailsText.Text = _achivment.Details;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            AchivmentManager.SaveAchivmentToProfile(_achivment.Id, ViewFactory.MainPageInstance.UserManager.UserInfo.Login);
            this.DialogResult = true;
        }
    }
}

