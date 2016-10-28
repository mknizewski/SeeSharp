using System;

namespace SeeSharp.BO.Managers
{
    public class UserManager
    {
        private const int MinRandomValue = 1000;
        private const int MaxRandomValue = 9999;

        public UserInfo UserInfo;

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
            UserInfo = null;
        }
    }

    public class UserInfo
    {
        public string Login { get; set; }
        public string Code { get; set; }
        public int Percentage { get; set; }
        public string LastTutorial { get; set; }
    }
}