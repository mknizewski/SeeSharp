using System;

namespace SeeSharp.BO.Managers
{
    public class UserManager
    {
        public static int GenerateCodeForNewUser()
        {
            Random randomNumber = new Random(DateTime.Now.Millisecond);

            return randomNumber.Next(0, 9999);
        }
    }
}