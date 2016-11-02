using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Policy;
using System.Threading;

namespace SeeSharp.Sandbox
{
    public class Sandbox : MarshalByRefObject
    {
        private const string FrienldyName = "Sandbox";
        private const string EntryPoint = "Main";
        private const int TimeOut = 10;

        private Sandbox()
        { }

        public static Sandbox CreateSandbox(string applicationBase, SecurityZone securityZone)
        {
            Type typeOfSandbox = typeof(Sandbox);
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

            return handle.Unwrap() as Sandbox;
        }

        public string ExecuteUntrusedCode(Assembly assembly, string[] parameters)
        {
            StreamReader streamReader = new StreamReader(Console.OpenStandardOutput());
            MethodInfo untrustedMethod = assembly
                .GetTypes()
                .Select(x => x.GetMethod(EntryPoint))
                .FirstOrDefault();
            string consoleOutput = string.Empty;

            try
            {
                Thread thread = new Thread(() =>
                {
                    untrustedMethod.Invoke(null, parameters);
                });

                thread.Start();
                consoleOutput = streamReader.ReadToEnd();

                if (!thread.Join(TimeSpan.FromSeconds(TimeOut)))
                {
                    thread.Abort();
                    string exMessage = string.Format("Przekroczono {0} sekund!", TimeOut);

                    throw new TimeoutException(exMessage);
                }
            }
            catch (Exception ex)
            {
                consoleOutput = ex.Message;
            }
            finally
            {
                streamReader.Close();
                streamReader.Dispose();
            }

            return consoleOutput;
        }
    }
}