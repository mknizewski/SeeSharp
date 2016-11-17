using SeeSharp.BO.Infrastructure;
using System;
using System.Resources;

namespace SeeSharp.BO.Managers
{
    public static class CuriositiesManager
    {
        private static ResourceManager CuriositiesDictionary = ResourceManagerFactory.GetResource(typeof(Resources.Curiosities));
        private static int CuriositiesIterator = 1;

        private const int CuriositiesCount = 8;
        private const int CuriosityMinValue = 1;
        private const string CouriositiesPattern = "Curiosities_{0}";

        public static string GetRandomCuriosities()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int randomCuriosity = random.Next(CuriositiesCount);

            CuriositiesIterator = randomCuriosity;

            return CuriositiesDictionary.GetString(string.Format(CouriositiesPattern, CuriositiesIterator));
        }

        public static string GetNextCuriosities()
        {
            if (CuriositiesIterator >= CuriositiesCount)
                CuriositiesIterator = CuriosityMinValue;
            else
                CuriositiesIterator++;

            return CuriositiesDictionary.GetString(string.Format(CouriositiesPattern, CuriositiesIterator));
        }

        public static string GetPervCuriosities()
        {
            if (CuriositiesIterator <= CuriosityMinValue)
                CuriositiesIterator = CuriosityMinValue;
            else
                CuriositiesIterator--;

            return CuriositiesDictionary.GetString(string.Format(CouriositiesPattern, CuriositiesIterator));
        }
    }
}
