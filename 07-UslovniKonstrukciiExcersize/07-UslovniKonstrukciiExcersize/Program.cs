using System;

namespace _07_UslovniKonstrukciiExcersize
{
    class Program
    {
        static void Main(string[] args)
        {
            int minute1 = int.Parse(Console.ReadLine());
            int minute2 = int.Parse(Console.ReadLine());
            int minute3 = int.Parse(Console.ReadLine());

            int minuteSum = minute1 + minute2 + minute3;
              
            int minutes = minuteSum / 60;
            int seconds = minuteSum % 60;

            if (seconds < 10)
            {
                Console.WriteLine("{0}:0{1}", minutes, seconds);
            }
            else
            {
                Console.WriteLine("{0}:{1}", minutes, seconds);
            }
        }
    }
}
