using System;
using System.Resources;

namespace SeeSharp.BO.Infrastructure
{
    public static class ResourceManagerFactory
    {
        public static ResourceManager GetInstance(Type type)
        {
            return new ResourceManager(type);
        }
    }
}
