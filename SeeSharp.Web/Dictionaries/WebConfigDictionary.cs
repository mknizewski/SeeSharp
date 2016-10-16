using System.Web.Configuration;

namespace SeeSharp.Web.Dictionaries
{
    public static class WebConfigDictionary
    {
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
    }
}