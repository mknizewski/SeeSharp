using System.Resources;

namespace SeeSharp.BO.Dictionaries
{
    public static class AppSettingsDictionary
    {
        private readonly static ResourceManager AppSettings = new ResourceManager(typeof(Resources.AppSettings));

        public static string XmlFilesDirectiory
        {
            get
            {
                return AppSettings.GetString("XmlFileDirectory");
            }
        }

        public static string AppVersion
        {
            get
            {
                return AppSettings.GetString("AppVersion");
            }
        }

        public static string AppVersionMessagePattern
        {
            get
            {
                return AppSettings.GetString("VersionMessagePattern");
            }
        }

        public static string HelloWorldProgram
        {
            get
            {
                return AppSettings.GetString("HelloWorld");
            }
        }
    }
}