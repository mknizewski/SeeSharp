﻿using System;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeeSharp.Sandbox
{
    public class Sandbox : MarshalByRefObject
    {
        private const string FrienldyName = "Sandbox";
        private const string EntryPoint = "Main";
        private const int TimeOutInMs = 3;

        public Sandbox()
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

            StrongName fullTrustAssembly = typeof(Sandbox).Assembly.Evidence.GetHostEvidence<StrongName>();
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

        [SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
        private void SetConsoleReader(ConsoleReader consoleReader)
        {
            Console.SetOut(consoleReader);
        }

        [SecurityPermission(SecurityAction.Assert, ControlThread = true)]
        private void AbortThread(Thread thread)
        {
            thread.Abort();
        }

        public string ExecuteUntrusedCode(Assembly assembly, string[] parameters)
        {
            string consoleOutput = string.Empty;

            try
            {
                Type[] type = assembly.GetTypes();
                MethodInfo[] untrused = type[0].GetMethods();
                MethodInfo untrustedMethod = untrused[0];
                ConsoleReader consoleReader = new ConsoleReader();
                SetConsoleReader(consoleReader);

                Thread thread = new Thread(() => 
                {
                    untrustedMethod.Invoke(null, parameters);
                });
                thread.Start();

                if (!thread.Join(TimeSpan.FromSeconds(TimeOutInMs)))
                {
                    AbortThread(thread);
                    throw new Exception("Upłynął limit oczekiwania");
                }
 
                consoleOutput = consoleReader.ConsoleOut;

                consoleReader.Close();
                consoleReader.Dispose();
            }
            catch (Exception ex)
            {
                consoleOutput = ex.Message;
            }

            return consoleOutput;
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
                return System.Text.Encoding.UTF8;
            }
        }

        public override void Write(char value)
        {
            base.Write(value);
            _consoleOut += value.ToString();
        }
    }
}