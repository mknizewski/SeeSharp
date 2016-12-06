using SeeSharp.Infrastructure;
using SeeSharp.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SeeSharp
{
    public partial class App : Application
    {
        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Grid grid = new Grid();
            MainPage mainPage = new MainPage();
            ViewFactory.MainPageInstance = mainPage;

            grid.Children.Add(mainPage);
            this.RootVisual = grid;
            this.ConfigureServer();
        }

        private void Application_Exit(object sender, EventArgs e)
        {
            ViewFactory.MainPageInstance.Dispose();
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }

        private void ConfigureServer()
        {
            ServerServiceClient serverService = ServerServiceClient.GetInstance();
            serverService.CreateDirectoriesIfDosentExistsAsync();
        }
    }
}