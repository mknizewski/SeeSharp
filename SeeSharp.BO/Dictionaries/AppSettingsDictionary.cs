using System.Resources;

namespace SeeSharp.BO.Dictionaries
{
    public static class AppSettingsDictionary
    {
        private static ResourceManager AppSetttings = new ResourceManager(typeof(AppSettings));

        public static string XmlFilesDirectiory
        {
            get
            {
                return AppSetttings.GetString("XmlFileDirectory");
            }
        }
    }
}