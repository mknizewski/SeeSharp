using System;
using System.CodeDom.Compiler;

namespace SeeSharp.Sandbox
{
    public class Compiler : IDisposable
    {
        private CodeDomProvider _codeDomProvider;
        private string _assemblyName;
        private string _sourceCode;

        private const string CSharpLanguague = "CSharp";

        public string SourceCode
        {
            get { return _sourceCode; }
            set { _sourceCode = value; }
        }

        public Compiler(string sourceCode)
        {
            _codeDomProvider = CodeDomProvider.CreateProvider(CSharpLanguague);
            _sourceCode = sourceCode;
        }

        private CompilerParameters GetCompilerParameters(string pathToWriteAssembly)
        {
            CompilerParameters compilerParameters = ObjectFactory.GetInstance<CompilerParameters>();

            compilerParameters.GenerateInMemory = true;
            compilerParameters.GenerateExecutable = true;
            compilerParameters.TreatWarningsAsErrors = false;
            compilerParameters.OutputAssembly = pathToWriteAssembly;

            return compilerParameters;
        }

        public CompilerResults Compile(string pathToWriteAssembly)
        {
            CompilerParameters compilerParameters = GetCompilerParameters(pathToWriteAssembly);
            CompilerResults compilerResult = _codeDomProvider.CompileAssemblyFromSource(compilerParameters, _sourceCode);

            return compilerResult;
        }

        public void Dispose()
        {
            _codeDomProvider.Dispose();
        }
    }
}