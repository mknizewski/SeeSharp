using System.Security;

namespace SeeSharp.Sandbox
{
    internal static class ObjectFactory
    {
        public static T GetInstance<T>() where T : new()
        {
            return new T();
        }
    }
}
