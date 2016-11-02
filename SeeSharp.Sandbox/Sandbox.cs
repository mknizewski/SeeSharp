using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Policy;

namespace SeeSharp.Sandbox
{
    public class Sandbox : MarshalByRefObject
    {
        private const string FrienldyName = "Sandbox";

        private Sandbox()
        { }

        public static Sandbox CreateSandbox(string applicationBase, SecurityZone securityZone)
        {
            Type typeOfSandbox = typeof(Sandbox);
            AppDomainSetup appDomainSetup = ObjectFactory.GetInstance<AppDomainSetup>();
            appDomainSetup.ApplicationBase = applicationBase;
            Evidence evidence = ObjectFactory.GetInstance<Evidence>();
            Zone zone = new Zone(securityZone);
            evidence.AddHostEvidence(zone);

            PermissionSet permissionSet = SecurityManager.GetStandardSandbox(evidence);
            StrongName fullTrustAssembly = typeOfSandbox.Assembly.Evidence.GetHostEvidence<StrongName>();
            AppDomain appDomain = AppDomain.CreateDomain(FrienldyName, evidence, appDomainSetup, permissionSet, fullTrustAssembly);

            ObjectHandle handle = Activator.CreateInstanceFrom(
                appDomain, 
                typeOfSandbox.Assembly.ManifestModule.FullyQualifiedName,
                typeOfSandbox.FullName);

            return handle.Unwrap() as Sandbox;
        }

        public void ExecuteUntrusedCode(Assembly assembly)
        {

        }
    }
}
