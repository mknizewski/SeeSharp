using SeeSharp.Web.Dictionaries;
using SeeSharp.Web.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SeeSharp.Web
{
    public class ServerService : IServerService
    {
        private const string Separator = @"\";

        public string Chuj()
        {
            throw new NotImplementedException();
        }

        public void CreateDirectoryForUser(string loginName, int code)
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, WebConfigDictionary.XmlFileDirectory);
            string userDirectory = string.Concat(xmlDirectoryPath, Separator, loginName);

            if (!Directory.Exists(userDirectory))
            {
                Directory.CreateDirectory(userDirectory);
                XmlDocument xmlFile = XmlManager.CreateNewXmlFile(loginName, code);
                string fullXmlFilePath = string.Concat(userDirectory, Separator, WebConfigDictionary.XmlFileName);

                xmlFile.Save(fullXmlFilePath);
            }
        }

        public void CreateMainDirectoryIfDosentExists()
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, WebConfigDictionary.XmlFileDirectory);

            if (!Directory.Exists(xmlDirectoryPath))
                Directory.CreateDirectory(xmlDirectoryPath);
        }

        public Dictionary<string, string> GetUserProfile(string loginName)
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, WebConfigDictionary.XmlFileDirectory);
            string userProfilePath = string.Concat(xmlDirectoryPath, Separator, loginName, Separator, WebConfigDictionary.XmlFileName);

            var xmlUserProfile = new XmlDocument();
            xmlUserProfile.Load(userProfilePath);

            return XmlManager.DeserializeXmlProfile(xmlUserProfile);
        }
    }
}