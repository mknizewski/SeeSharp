using System;

namespace SeeSharp.BO.Managers
{
    public class ModuleManager : IDisposable
    {
        public string ModuleName { get { return _moduleName; } set { _moduleName = value; } }
        public string Tag { get { return _tag; } set { _tag = value; } }

        private string _moduleName;
        private string _tag;

        private ModuleManager(string moduleName, string tag )
        {
            _moduleName = moduleName;
            _tag = tag;
        }

        public static ModuleManager GetModuleManager(string moduleName, string tag)
        {
            return new ModuleManager(moduleName, tag);
        }

        public void Dispose()
        {
            _moduleName = string.Empty;
            _tag = string.Empty;
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
    }
}
