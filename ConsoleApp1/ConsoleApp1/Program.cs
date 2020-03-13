using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool proba = false;

            ChangeBool(ref proba);
            Console.WriteLine(proba);
        }

        private static void ChangeBool(ref bool proba)
        {
            proba = true;
        }
    }
}
