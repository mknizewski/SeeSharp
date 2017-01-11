using SeeSharp.BO.Managers;
using System.Windows.Controls;

namespace SeeSharp.Infrastructure
{
    public static class ViewFactory
    {
        /// <summary>
        /// Instancja MainPage służąca w celu zmiany widoków.
        /// </summary>
        public static MainPage MainPageInstance;

        public static UserControl GetView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.WelcomePage:
                    return new WelcomePage();

                case ViewType.AboutAuthors:
                    return new AboutAuthors();

                case ViewType.Register:
                    return new RegisterPage();

                case ViewType.Login:
                    return new LoginPage();

                case ViewType.AboutCourse:
                    return new AboutCourse();

                default:
                    return new MainPage();
            }
        }

        public static Alert GetAlert(string meesage)
        {
            return new Alert(meesage);
        }

        public static UserControl GetModule(string tag)
        {
            return new ModulePage(tag);
        }

        public static AchivmentAlert GetAchivmentAlert(Achivments achivments)
        {
            return new AchivmentAlert(AchivmentManager.GetAchivment(achivments));
        }
    }

    public enum ViewType
    {
        WelcomePage,
        AboutAuthors,
        Register,
        Login,
        AboutCourse
    }
}