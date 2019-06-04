using System;
using System.Globalization;

namespace _01DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputData = Console.ReadLine(); // 18-04-2016
            
            //DateTime dateTime = DateTime.Parse(inputData); 

            DateTime dateTime = DateTime.ParseExact(inputData, "dd-MM-yyyy", 
                CultureInfo.InvariantCulture);

            Console.WriteLine(dateTime.DayOfWeek);
        }
    }
}
