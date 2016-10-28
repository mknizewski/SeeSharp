using System.Resources;

namespace SeeSharp.BO.Dictionaries
{
    public static class ExceptionDictionary
    {
        private static ResourceManager ExceptionsMessage = new ResourceManager(typeof(BO.Exception));

        public static string LoginNotFoundMessage
        {
            get
            {
                return ExceptionsMessage.GetString("LoginNameNotFound");
            }
        }
    }
}