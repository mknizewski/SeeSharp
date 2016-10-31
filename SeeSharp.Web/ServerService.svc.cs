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

        public void CreateDirectoryForUser(string loginName, int code)
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.XmlFileDirectory);
            string userDirectory = string.Concat(xmlDirectoryPath, Separator, loginName);

            if (!Directory.Exists(userDirectory))
            {
                Directory.CreateDirectory(userDirectory);
                XmlDocument xmlFile = XmlManager.CreateNewXmlFile(loginName, code);
                string fullXmlFilePath = string.Concat(userDirectory, Separator, ServerDictionary.XmlFileName);

                xmlFile.Save(fullXmlFilePath);
            }
        }

        public void CreateMainDirectoryIfDosentExists()
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.XmlFileDirectory);

            if (!Directory.Exists(xmlDirectoryPath))
                Directory.CreateDirectory(xmlDirectoryPath);
        }

        public Dictionary<string, string> GetUserProfile(string loginName)
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.XmlFileDirectory);
            string userProfilePath = string.Concat(xmlDirectoryPath, Separator, loginName, Separator, ServerDictionary.XmlFileName);

            if (!File.Exists(userProfilePath))
                return new Dictionary<string, string>();

            return XmlManager.DeserializeXmlProfile(userProfilePath);
        }
    }
}