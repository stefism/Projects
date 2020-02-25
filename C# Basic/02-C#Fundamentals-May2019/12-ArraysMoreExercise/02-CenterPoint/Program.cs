using System;

namespace _02_CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double closeX = 0;
            double closeY = 0;

            if (Math.Abs(x1) + Math.Abs(y1) < Math.Abs(x2) + Math.Abs(y2))
            {
                closeX = x1;
                closeY = y1;
            }
            else
            {
                closeX = x2;
                closeY = y2;
            }

            Console.WriteLine($"({closeX}, {closeY})");
        }
    }
}
