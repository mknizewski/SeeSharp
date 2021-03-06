﻿using SeeSharp.Sandbox;
using SeeSharp.Web.Dictionaries;
using SeeSharp.Web.Managers;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Xml;

namespace SeeSharp.Web
{
    public class ServerService : IServerService
    {
        private const string Separator = @"\";

        public bool CreateDirectoryForUser(string loginName, int code)
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.XmlFileDirectory);
            string userDirectory = string.Concat(xmlDirectoryPath, Separator, loginName);

            if (!Directory.Exists(userDirectory))
            {
                Directory.CreateDirectory(userDirectory);
                XmlDocument xmlProfileFile = XmlManager.CreateNewXmlProfileFile(loginName, code);
                XmlDocument xmlAchivmentFile = XmlManager.CreateNewAchivmentFile();

                string fullXmlProfileFilePath = string.Concat(userDirectory, Separator, ServerDictionary.XmlProfileFileName);
                string fullXmlAchivmentFilePath = string.Concat(userDirectory, Separator, ServerDictionary.XmlAchivmentsFileName);

                xmlProfileFile.Save(fullXmlProfileFilePath);
                xmlAchivmentFile.Save(fullXmlAchivmentFilePath);

                return true;
            }

            return false;
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
            string userProfilePath = string.Concat(
                xmlDirectoryPath,
                Separator,
                loginName,
                Separator,
                ServerDictionary.XmlProfileFileName);

            if (!File.Exists(userProfilePath))
                return new Dictionary<string, string>();

            return XmlManager.DeserializeXmlProfile(userProfilePath);
        }

        public string CompileAndRunProgram(string sourceCode, string[] parameters)
        {
            string consoleOutput = string.Empty;
            string randomDirectoryName = Guid.NewGuid().ToString();
            string pathToProgramDirectory = string.Concat(
                AppDomain.CurrentDomain.BaseDirectory,
                ServerDictionary.SourceFileDictionary,
                Separator,
                randomDirectoryName);
            string randomFileName = string.Format(ServerDictionary.ExeExtensionPattern, Path.GetRandomFileName());
            string pathToProgramAssembly = string.Concat(pathToProgramDirectory, Separator, randomFileName);

            try
            {
                Directory.CreateDirectory(pathToProgramDirectory);
                Compiler compiler = new Compiler(sourceCode);
                CompilerResults compilerResults = compiler.Compile(pathToProgramAssembly);

                if (compilerResults.Errors.HasErrors)
                {
                    string errorList = string.Empty;

                    foreach (CompilerError error in compilerResults.Errors)
                        errorList += string.Format(
                            ServerDictionary.ErrorPattern,
                            error.Line,
                            error.ErrorNumber,
                            error.ErrorText,
                            Environment.NewLine);

                    throw new Exception(errorList);
                }

                SandboxInstance sandobxAssembly = SandboxInstance.CreateSandbox(pathToProgramDirectory, SecurityZone.Internet);
                Assembly untrusedAssembly = compilerResults.CompiledAssembly;

                consoleOutput = sandobxAssembly.ExecuteUntrusedCode(untrusedAssembly, parameters);
                compiler.Dispose();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return consoleOutput;
        }

        public void UpdateUserProfile(Dictionary<string, string> userProfile)
        {
            string loginName = userProfile["login"];
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.XmlFileDirectory);
            string userProfilePath = string.Concat(
                xmlDirectoryPath,
                Separator,
                loginName,
                Separator,
                ServerDictionary.XmlProfileFileName);

            XmlManager.UpdateXmlProfile(userProfile, userProfilePath);
        }

        public int[] GetAchivmentFile(string loginName)
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.XmlFileDirectory);
            string userAchivmentPath = string.Concat(
                xmlDirectoryPath,
                Separator,
                loginName,
                Separator,
                ServerDictionary.XmlAchivmentsFileName);

            return XmlManager.DeserializeXmlAchivments(userAchivmentPath);
        }

        public void UpdateAchivmentFile(int achivId, string loginName)
        {
            string xmlDirectoryPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, ServerDictionary.XmlFileDirectory);
            string userAchivmentPath = string.Concat(
                xmlDirectoryPath,
                Separator,
                loginName,
                Separator,
                ServerDictionary.XmlAchivmentsFileName);

            XmlManager.UpdateXmlAchivments(achivId, userAchivmentPath);
        }

        public string GetModuleText(string path)
        {
            return File.ReadAllText(string.Concat(AppDomain.CurrentDomain.BaseDirectory, path));
        }
    }
}