using System;

namespace ReadNamesExsample
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstname = Console.ReadLine();
            string secondname = Console.ReadLine();
            double age = double.Parse(Console.ReadLine());

            // simple way
            Console.WriteLine("My name is " + firstname + " "+ secondname);

            //string format {0}
            Console.WriteLine("2 My name is {0} {1}", firstname, secondname);

            //string interpolation {variable}
            Console.WriteLine($"3 My name is {firstname} {secondname} и съм на {age:F1} години");
        }
    }
}
