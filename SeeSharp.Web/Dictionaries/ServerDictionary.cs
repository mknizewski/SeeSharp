using System.Web.Configuration;

namespace SeeSharp.Web.Dictionaries
{
    public static class ServerDictionary
    {
        public static string DirectoryNotFoundMessage = "Nie znaleziono użytkownika!";
        public static string ErrorPattern = "Linia {0}: {1} {2}{3}";
        public static string ExeExtensionPattern = "{0}.exe";

        public static string XmlFileDirectory
        {
            get
            {
                return WebConfigurationManager.AppSettings["XmlFileDirectory"];
            }
        }

        public static string XmlAchivmentsFileName
        {
            get
            {
                return WebConfigurationManager.AppSettings["XmlAchivmentsFileName"];
            }
        }

        public static string XmlProfileFileName
        {
            get
            {
                return WebConfigurationManager.AppSettings["XmlProfileFileName"];
            }
        }

        public static string SourceFileDictionary
        {
            get
            {
                return WebConfigurationManager.AppSettings["SourceFilesDirectory"];
            }
        }
    }
}