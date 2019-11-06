using System;

namespace Spy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.AnalyzeAcessModifiers("Hacker");

            Console.WriteLine(result);
        }
    }
}
