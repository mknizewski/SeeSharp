using System.Resources;

namespace SeeSharp.BO.Dictionaries
{
    public static class AppSettingsDictionary
    {
        private readonly static ResourceManager AppSetttings = new ResourceManager(typeof(Resources.AppSettings));

        public static string XmlFilesDirectiory
        {
            get
            {
                return AppSetttings.GetString("XmlFileDirectory");
            }
        }
    }
}