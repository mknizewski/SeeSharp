using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace SeeSharp.Sandbox
{
    public class Compiler : IDisposable
    {
        private CodeDomProvider _codeDomProvider;
        private const string CSharpLanguague = "CSharp";
        private string _assemblyName;

        public string AssemblyName
        {
            get { return _assemblyName; }
            set { _assemblyName = value; }
        }

        public Compiler(string assemblyName)
        {
            _codeDomProvider = CodeDomProvider.CreateProvider(CSharpLanguague);
            _assemblyName = assemblyName;
        }

        private CompilerParameters GetCompilerParameters(string assemblyName)
        {
            CompilerParameters compilerParameters = ObjectFactory.GetInstance<CompilerParameters>();

            string fullPathToAssembly = string.Format("");

            compilerParameters.GenerateInMemory = true;
            compilerParameters.GenerateExecutable = true;
            compilerParameters.TreatWarningsAsErrors = false;
            compilerParameters.OutputAssembly = fullPathToAssembly;

            return compilerParameters;
        }

        public void Compile()
        {
            CompilerParameters compilerParameters = GetCompilerParameters(_assemblyName);
        }

        public void Dispose()
        {
            _codeDomProvider.Dispose();
        }
    }
}
