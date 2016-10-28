using System;

namespace SeeSharp.BO.Managers
{
    public class UserManager
    {
        private const int MinRandomValue = 1000;
        private const int MaxRandomValue = 9999;

        public static int GenerateCodeForNewUser()
        {
            Random randomNumber = new Random(DateTime.Now.Millisecond);

            return randomNumber.Next(MinRandomValue, MaxRandomValue);
        }

        public void SignIn()
        {

        }

        public void SignOut()
        {

        }
    }
}