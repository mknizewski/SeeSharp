using System;
using System.IO;
using System.Xml;

namespace SeeSharp.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServerService.svc or ServerService.svc.cs at the Solution Explorer and start debugging.
    public class ServerService : IServerService
    {
        public void CreateDirectoryForUser(string loginName)
        {
            throw new NotImplementedException();
        }

        public void CreateMainDirectoryIfDosentExists(string nameOfDirectory)
        {
            string xmlPath = string.Join(@"\", AppDomain.CurrentDomain.BaseDirectory, nameOfDirectory);

            if (!Directory.Exists(xmlPath))
                Directory.CreateDirectory(xmlPath);
        }

        public XmlDocument GetUserXml(string loginName)
        {
            throw new NotImplementedException();
        }
    }
}
