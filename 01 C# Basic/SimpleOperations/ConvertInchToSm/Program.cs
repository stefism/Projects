using System;

namespace ConvertInchToSm
{
    class Program
    {
        static void Main(string[] args)
        {
            double inchRatio = 2.54;
            double kolkoincha = double.Parse(Console.ReadLine());
            double rezultat = kolkoincha * inchRatio;
            Console.WriteLine("{0:F2}", rezultat);
            
        }
    }
}
