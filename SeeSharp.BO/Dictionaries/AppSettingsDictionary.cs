using SeeSharp.BO.Infrastructure;
using System.Resources;

namespace SeeSharp.BO.Dictionaries
{
    public static class AppSettingsDictionary
    {
        private readonly static ResourceManager AppSettings = ResourceManagerFactory.GetResource(typeof(Resources.AppSettings));

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

        public static string UnllogedAlert
        {
            get
            {
                return AppSettings.GetString("UnloggedAlert");
            }
        }

        public static string SectionPrefixPattern
        {
            get
            {
                return AppSettings.GetString("SectionPrefixPattern");
            }
        }

        public static string PercentagePattern
        {
            get
            {
                return AppSettings.GetString("PercentagePattern");
            }
        }

        public static string CheckMark
        {
            get
            {
                return AppSettings.GetString("CheckMark");
            }
        }
    }
}