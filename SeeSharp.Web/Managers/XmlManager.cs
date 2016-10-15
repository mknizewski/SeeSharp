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
    }
}