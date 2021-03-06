﻿using System.Collections.Generic;
using System.ServiceModel;

namespace SeeSharp.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServerService" in both code and config file together.
    [ServiceContract]
    public interface IServerService
    {
        [OperationContract]
        void CreateDirectoriesIfDosentExists();

        [OperationContract]
        bool CreateDirectoryForUser(string loginName, int code);

        [OperationContract]
        Dictionary<string, string> GetUserProfile(string loginName);

        [OperationContract]
        string CompileAndRunProgram(string sourceCode, string[] parameters);

        [OperationContract]
        void UpdateUserProfile(Dictionary<string, string> userProfile);

        [OperationContract]
        int[] GetAchivmentFile(string loginName);

        [OperationContract]
        void UpdateAchivmentFile(int achivId, string loginName);

        [OperationContract]
        string GetModuleText(string path);
    }
}