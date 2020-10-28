using System;


    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.StealFieldInfo("Hacker", "password", "username");

            Console.WriteLine(result);
        }
    }

