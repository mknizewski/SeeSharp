﻿using System.Windows.Controls;

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

                default:
                    return new MainPage();
            }
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