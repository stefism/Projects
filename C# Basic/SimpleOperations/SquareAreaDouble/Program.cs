using System;

namespace SquareAreaDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            double stranakvadrad = double.Parse(Console.ReadLine());
            double rezultatkvadrad = stranakvadrad * stranakvadrad;
            Console.WriteLine(rezultatkvadrad);
        }
    }
}
