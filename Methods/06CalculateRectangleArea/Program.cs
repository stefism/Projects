using System;

namespace _06CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double result = CalcRectangleArea(width, height);
            Console.WriteLine(result);
        }

        static double CalcRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
