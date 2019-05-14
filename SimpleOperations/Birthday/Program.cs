using System;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double daljina = double.Parse(Console.ReadLine());
            double sirocina = double.Parse(Console.ReadLine());
            double visocina = double.Parse(Console.ReadLine());
            double procent = double.Parse(Console.ReadLine());

            double obem = daljina * sirocina * visocina;
            double obstoLitri = obem * 0.001;
            double procentsmiatane = procent * 0.01;

            double realnoLitri = obstoLitri * (1 - procentsmiatane);

            Console.WriteLine("{0:F3}", realnoLitri);

                
      
        }
    }
}
