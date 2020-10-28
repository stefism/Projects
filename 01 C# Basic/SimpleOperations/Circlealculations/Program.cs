using System;

namespace Circlealculations
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            double pi = Math.PI;
            double area = pi * radius * radius;
            double perimeter = 2 * pi * radius;

            Console.WriteLine("{0:F2}", area);
            Console.WriteLine("{0:F2}", perimeter);
            

        }
    }
}
