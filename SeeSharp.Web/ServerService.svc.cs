using SeeSharp.Sandbox;
using SeeSharp.Web.Dictionaries;
using SeeSharp.Web.Managers;
using System;
using System.CodeDom.Compiler;
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

        public void CreateDirectoriesIfDosentExists()
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.XmlFileDirectory);
            string sourceFileDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.SourceFileDictionary);

            if (!Directory.Exists(xmlDirectoryPath))
                Directory.CreateDirectory(xmlDirectoryPath);

            if (!Directory.Exists(sourceFileDirectoryPath))
                Directory.CreateDirectory(sourceFileDirectoryPath);
        }

        public Dictionary<string, string> GetUserProfile(string loginName)
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.XmlFileDirectory);
            string userProfilePath = string.Concat(xmlDirectoryPath, Separator, loginName, Separator, ServerDictionary.XmlFileName);

            if (!File.Exists(userProfilePath))
                return new Dictionary<string, string>();

            return XmlManager.DeserializeXmlProfile(userProfilePath);
        }

        public string CompileAndRunProgram(string sourceCode)
        {
            string output = string.Empty;
            string randomDirectoryName = Guid.NewGuid().ToString();
            string directoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.SourceFileDictionary, Separator, randomDirectoryName);
            string randomFileName = string.Format(ServerDictionary.ExeExtensionPattern, Path.GetRandomFileName());
            string filePath = string.Concat(directoryPath, Separator, randomFileName);

            try
            {
                DirectoryInfo dinfo = Directory.CreateDirectory(directoryPath);
                Compiler compiler = new Compiler(sourceCode);
                CompilerResults cResults = compiler.Compile(filePath);

                if (cResults.Errors.HasErrors)
                {
                    string errorList = string.Empty;

                    foreach (CompilerError item in cResults.Errors)
                        errorList += string.Format(ServerDictionary.ErrorPattern, item.Line, item.ErrorNumber, item.ErrorText, Environment.NewLine);

                    throw new Exception(errorList);
                }

                Sandbox.Sandbox sandobx = Sandbox.Sandbox.CreateSandbox(directoryPath, System.Security.SecurityZone.Internet);
                output = sandobx.ExecuteUntrusedCode(cResults.CompiledAssembly, new string[] { });

                compiler.Dispose();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
            return output;
        }
    }
}