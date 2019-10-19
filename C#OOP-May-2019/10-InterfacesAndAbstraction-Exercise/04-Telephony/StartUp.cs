using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Telephony
{
    public class StartUp
    {
        static List<string> numbers;
        static List<string> webAddresses;
        static ICalling call;
        static IBrowsing browse;

        static void Main()
        {
            numbers = Console.ReadLine().Split().ToList();
            webAddresses = Console.ReadLine().Split().ToList();

            call = new Smartphone();
            browse = new Smartphone();

            CallNumbers();

            BrowseWeb();
        }

        private static void BrowseWeb()
        {
            foreach (var webAddress in webAddresses)
            {
                try
                {
                    Console.WriteLine(browse.Browsing(webAddress));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void CallNumbers()
        {
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(call.Calling(number));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
