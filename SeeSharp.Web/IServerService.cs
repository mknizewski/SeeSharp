using System.ServiceModel;

namespace SeeSharp.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServerService" in both code and config file together.
    [ServiceContract]
    public interface IServerService
    {
        [OperationContract]
        void CreateMainDirectoryIfDosentExists();

        [OperationContract]
        void CreateDirectoryForUser(string loginName, int code);
    }
}
