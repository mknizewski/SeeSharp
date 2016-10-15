using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

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
