using System;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double strana = double.Parse(Console.ReadLine());
            double visocina = double.Parse(Console.ReadLine());
            double liceto = strana * visocina / 2;
            Console.WriteLine("{0:F2}", liceto);
        }
    }
}
