using System;
using System.Collections.Generic;

namespace SeeSharp.BO.Managers
{
    public class ModuleManager : IDisposable
    {
        public string ModuleName { get { return _currentModuleName; } set { _currentModuleName = value; } }
        public string Tag { get { return _currentTag; } set { _currentTag = value; } }

        private static List<Module> _moduleList;
        private static List<Exam> _examList;

        private string _currentModuleName;
        private string _currentTag;
            
        private ModuleManager(string moduleName, string tag)
        {
            _currentModuleName = moduleName;
            _currentTag = tag;

            InitializeList();
        }

        public static ModuleManager GetModuleManager(string moduleName, string tag)
        {
            return new ModuleManager(moduleName, tag);
        }

        public void Dispose()
        {
            _currentModuleName = string.Empty;
            _currentTag = string.Empty;
        }

        public void LoadModule()
        {
        }

        public string GetNextModule()
        {
            return string.Empty;
        }

        public string GetPervModule()
        {
            return string.Empty;
        }

        #region List Initializer
        private void InitializeList()
        {
            // Rozdział I
            _moduleList.Add(Module.CreateModule("Czym jest .NET?", "1.1", false));
            _moduleList.Add(Module.CreateModule("Dlaczego C#", "1.2", false));

            // Rozdział II

        }
        #endregion
    }

    public struct Module
    {
        public string ModuleName { get; set; }
        public string ModuleTag { get; set; }
        public bool IsExamNext { get; set; }

        public Module(string moduleName, string moduleTag, bool isExamNext) : this()
        {
            this.ModuleName = moduleName;
            this.ModuleTag = moduleTag;
            this.IsExamNext = isExamNext;
        }

        public static Module CreateModule(string moduleName, string moduleTag, bool isExamNext)
        {
            return new Module(moduleName, moduleTag, isExamNext);
        }
    }

    public struct Exam
    {
        public string ModuleTag { get; set; }
        public string Task { get; set; }
        public string Code { get; set; }
        public string TestOutput { get; set; }
        public string TestInput { get; set; }
    }
}