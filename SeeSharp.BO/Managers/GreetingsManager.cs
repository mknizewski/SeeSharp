using SeeSharp.BO.Dictionaries;

namespace SeeSharp.BO.Managers
{
    public class GreetingsManager
    {
        public static string GetGreetingsByDayOfWeek(int dayOfWeek, string userName)
        {
            string greetings = string.Empty;

            switch (dayOfWeek)
            {
                case 1:
                    greetings = GreetingsDictionary.MondayPattern;
                    break;
                case 2:
                    greetings = GreetingsDictionary.TuesdayPattern;
                    break;
                case 3:
                    greetings = GreetingsDictionary.WenesdayPattern;
                    break;
                case 4:
                    greetings = GreetingsDictionary.ThursdayPattern;
                    break;
                case 5:
                    greetings = GreetingsDictionary.FridayPattern;
                    break;
                case 6:
                    greetings = GreetingsDictionary.SaturdayPattern;
                    break;
                case 7:
                    greetings = GreetingsDictionary.SundayPattern;
                    break;
                default:
                    greetings = GreetingsDictionary.DefaultPattern;
                    break;
            }

            return string.Format(greetings, userName);
        }
    }
}
