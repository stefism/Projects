using System;

namespace _02_CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            // 80 от 100

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double closeX = 0;
            double closeY = 0;

            if (Math.Abs(x1) < Math.Abs(x2))
            {
                closeX = x1;
            }
            else
            {
                closeX = x2;
            }

            if (Math.Abs(y1) < Math.Abs(y2))
            {
                closeY = y1;
            }
            else
            {
                closeY = y2;
            }

            Console.WriteLine($"({closeX}, {closeY})");
        }
    }
}
