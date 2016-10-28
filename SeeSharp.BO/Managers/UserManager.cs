using System;

namespace SeeSharp.BO.Managers
{
    public class UserManager
    {
        private const int MinValue = 1000;
        private const int MaxValue = 9999;

        public static int GenerateCodeForNewUser()
        {
            Random randomNumber = new Random(DateTime.Now.Millisecond);

            return randomNumber.Next(MinValue, MaxValue);
        }
    }
}