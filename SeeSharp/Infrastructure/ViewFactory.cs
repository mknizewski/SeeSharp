using System.Windows.Controls;

namespace SeeSharp.Infrastructure
{
    public static class ViewFactory
    {
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
                    break;
                default:
                    return new MainPage();
            }

            return new MainPage();
        }
    }

    public enum ViewType
    {
        WelcomePage,
        AboutAuthors,
        Register,
        Login
    }
}
