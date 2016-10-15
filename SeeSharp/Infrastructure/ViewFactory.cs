using System.Windows.Controls;

namespace SeeSharp.Infrastructure
{
    public static class ViewFactory
    {
        public static UserControl GetView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.MainPage:
                    return new MainPage();
                case ViewType.AboutAuthors:
                    return new AboutAuthors();
                case ViewType.Register:
                    break;
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
        MainPage,
        AboutAuthors,
        Register,
        Login
    }
}
