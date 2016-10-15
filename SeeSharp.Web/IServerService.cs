using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace SeeSharp.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServerService" in both code and config file together.
    [ServiceContract]
    public interface IServerService
    {
        [OperationContract]
        void CreateMainDirectoryIfDosentExists(string nameOfDirectory);

        [OperationContract]
        void CreateDirectoryForUser(string loginName);

        [OperationContract]
        XmlDocument GetUserXml(string loginName);
    }
}
