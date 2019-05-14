using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeMovie = Console.ReadLine();
            double rows = double.Parse(Console.ReadLine());
            double columns = double.Parse(Console.ReadLine());

            double price = 0;
            double seats = rows * columns;

            if (typeMovie == "Premiere")
            {
                price = seats * 12;
            }
            else if (typeMovie == "Normal")
            {
                price = seats * 7.50;
            }
            else if (typeMovie == "Discount")
            {
                price = seats * 5;
            }

            Console.WriteLine($"{price:F2} leva");

        }
    }
}
