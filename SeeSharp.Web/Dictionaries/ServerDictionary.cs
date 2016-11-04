using System.Web.Configuration;

namespace SeeSharp.Web.Dictionaries
{
    public static class ServerDictionary
    {
        public static string DirectoryNotFoundMessage = "Nie znaleziono użytkownika!";

        public static string XmlFileDirectory
        {
            get
            {
                return WebConfigurationManager.AppSettings["XmlFileDirectory"];
            }
        }

        public static string XmlFileName
        {
            get
            {
                return WebConfigurationManager.AppSettings["XmlFileName"];
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