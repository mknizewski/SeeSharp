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

        public static UserControl GetModule(ModuleType moduleType)
        {
            return null;
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

    public enum ModuleType
    {
    }
}