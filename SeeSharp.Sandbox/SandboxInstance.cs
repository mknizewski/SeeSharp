using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace SeeSharp.Sandbox
{
    public class SandboxInstance : MarshalByRefObject
    {
        private const string FrienldyName = "Sandbox";
        private const string EntryPoint = "Main";
        private const int TimeOutInSec = 3;

        public SandboxInstance()
        { }

        public static SandboxInstance CreateSandbox(string applicationBase, SecurityZone securityZone)
        {
            Type typeOfSandbox = typeof(SandboxInstance);
            AppDomainSetup appDomainSetup = ObjectFactory.GetInstance<AppDomainSetup>();
            Evidence evidence = ObjectFactory.GetInstance<Evidence>();
            Zone zone = new Zone(securityZone);

            appDomainSetup.ApplicationBase = applicationBase;
            evidence.AddHostEvidence(zone);

            PermissionSet permissionSet = SecurityManager.GetStandardSandbox(evidence);
            StrongName fullTrustAssembly = typeOfSandbox.Assembly.Evidence.GetHostEvidence<StrongName>();
            AppDomain appDomain = AppDomain.CreateDomain(
                FrienldyName,
                evidence,
                appDomainSetup,
                permissionSet,
                fullTrustAssembly);

            ObjectHandle handle = Activator.CreateInstanceFrom(
                appDomain,
                typeOfSandbox.Assembly.ManifestModule.FullyQualifiedName,
                typeOfSandbox.FullName);
     
            return handle.Unwrap() as SandboxInstance;
        }

        [SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
        private void SetConsoleStreamToConsoleReader(ConsoleReader consoleReader)
        {
            Console.SetOut(consoleReader);
        }

        [SecurityPermission(SecurityAction.Assert, ControlThread = true)]
        private void AbortThread(Thread thread)
        {
            thread.Abort();
            throw new Exception(SandboxExceptions.Timeout);
        }

        private MethodInfo FindMainMethod(Assembly assembly)
        {
            List<Type> type = assembly.GetTypes().ToList();
            MethodInfo untrustedMethod = null;

            type.ForEach(typeInList =>
            {
                List<MethodInfo> methods = typeInList.GetMethods().ToList();
                methods.ForEach(method =>
                {
                    if (string.Equals(method.Name, EntryPoint))
                        untrustedMethod = method;
                });
            });

            return untrustedMethod;
        }

        public string ExecuteUntrusedCode(Assembly assembly, string[] parameters)
        {
            try
            {
                MethodInfo untrustedMethod = FindMainMethod(assembly);

                if (untrustedMethod == null)
                    throw new Exception(SandboxExceptions.MainNotFound);

                ConsoleReader consoleReader = new ConsoleReader();
                SetConsoleStreamToConsoleReader(consoleReader);

                Thread thread = new Thread(() => 
                {
                    try
                    {
                        untrustedMethod.Invoke(null, parameters);
                    }
                    catch (Exception ex)
                    {
                        consoleReader.ConsoleOut = ex.InnerException.Message;
                    }
                });
                thread.Start();

                if (!thread.Join(TimeSpan.FromSeconds(TimeOutInSec)))
                    AbortThread(thread);

                consoleReader.Close();
                consoleReader.Dispose();

                return consoleReader.ConsoleOut;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    internal class ConsoleReader : TextWriter
    {
        private string _consoleOut;
        public string ConsoleOut { get { return _consoleOut; } set { _consoleOut = value; } }

        public ConsoleReader()
        {
            _consoleOut = string.Empty;
        }

        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }

        public override void Write(char value)
        {
            _consoleOut += value.ToString();
        }
    }
}