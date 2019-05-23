using System;

namespace _01_EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Technology Fundamentals Retake Mid Exam - 16 April 2019 
            double budget = double.Parse(Console.ReadLine());
            double floorPrice = double.Parse(Console.ReadLine());

            double onePackEggPrice = floorPrice * 0.75;
            double oneLiterMilkPrice = floorPrice * 1.25;
            double milk250mlPrice = oneLiterMilkPrice / 4;

            double oneCouzunakPrice = floorPrice + onePackEggPrice + milk250mlPrice;

            double couzunakMade = Math.Floor(budget / oneCouzunakPrice);

            double moneyLeft =  budget - (oneCouzunakPrice * couzunakMade);

            double coloredEgg = couzunakMade * 3;

            int lostEgg = 0;

            for (int i = 1; i <= couzunakMade; i++)
            {
                if (i % 3 == 0)
                {
                    lostEgg += i - 2;
                }
            }

            Console.WriteLine($"You made {couzunakMade} cozonacs! Now you have {coloredEgg-lostEgg} eggs and {moneyLeft:F2}BGN left.");

        }
    }
}
