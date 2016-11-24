using System.Collections.Generic;
using System.Xml;

namespace SeeSharp.Web.Managers
{
    public static class XmlManager
    {
        public static XmlDocument CreateNewXmlFile(string loginName, int code)
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlNode rootNode = xmlDocument.CreateElement("appProfile");
            xmlDocument.AppendChild(rootNode);

            XmlNode userNode = xmlDocument.CreateElement("user");

            XmlNode userLoginSubNode = xmlDocument.CreateElement("login");
            userLoginSubNode.InnerText = loginName;
            userNode.AppendChild(userLoginSubNode);

            XmlNode codeSubNode = xmlDocument.CreateElement("code");
            codeSubNode.InnerText = code.ToString();
            userNode.AppendChild(codeSubNode);

            rootNode.AppendChild(userNode);

            XmlNode tutorialNode = xmlDocument.CreateElement("tutorial");

            XmlNode percentageSubNode = xmlDocument.CreateElement("percentage");
            percentageSubNode.InnerText = decimal.Zero.ToString();
            tutorialNode.AppendChild(percentageSubNode);

            XmlNode lastSubNode = xmlDocument.CreateElement("last");
            tutorialNode.AppendChild(lastSubNode);

            rootNode.AppendChild(tutorialNode);

            return xmlDocument;
        }

        public static Dictionary<string, string> DeserializeXmlProfile(string xmlFilePath)
        {
            XmlDocument xmlProfile = new XmlDocument();
            xmlProfile.Load(xmlFilePath);

            var userDictionary = new Dictionary<string, string>();
            foreach (XmlNode node in xmlProfile.ChildNodes)
            {
                foreach (XmlNode subNode in node.ChildNodes)
                {
                    foreach (XmlNode properties in subNode.ChildNodes)
                    {
                        userDictionary.Add(properties.Name, properties.InnerText);
                    }
                }
            }

            return userDictionary;
        }

        public static void UpdateXml(Dictionary<string, string> userProfile, string xmlFilePath)
        {
            XmlDocument xmlProfile = new XmlDocument();
            xmlProfile.Load(xmlFilePath);

            XmlNode appProfileNode = xmlProfile.FirstChild;

            XmlNode userNode = appProfileNode.FirstChild;
            XmlNode loginProp = userNode.FirstChild;
            XmlNode codeProp = userNode.LastChild;

            XmlNode tutorialNode = appProfileNode.LastChild;
            XmlNode percetnageProp = tutorialNode.FirstChild;
            XmlNode lastProp = tutorialNode.LastChild;

            loginProp.InnerText = userProfile["login"];
            codeProp.InnerText = userProfile["code"];
            percetnageProp.InnerText = userProfile["percentage"];
            lastProp.InnerText = userProfile["last"];

            xmlProfile.Save(xmlFilePath);
        }
    }
}