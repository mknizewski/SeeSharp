using SeeSharp.BO.Infrastructure;
using System.Resources;

namespace SeeSharp.BO.Dictionaries
{
    public static class RegisterPageDictionary
    {
        private readonly static ResourceManager ResourceManager = ResourceManagerFactory.GetResource(typeof(Resources.RegisterPage));

        public static string SuccesfulRegisterMessagePattern
        {
            get
            {
                return ResourceManager.GetString("SuccesfullRegisterMessagePattern");
            }
        }
    }
}