using System;

namespace SumSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            int second1 = int.Parse(Console.ReadLine());
            int second2 = int.Parse(Console.ReadLine());
            int second3 = int.Parse(Console.ReadLine());

            int sumSecond = (second1 + second2 + second3) / 60;

            int munutes = sumSecond / 60;
            int second = sumSecond % 60;


        }
    }
}
