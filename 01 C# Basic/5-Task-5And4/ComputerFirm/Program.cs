using System;

namespace ComputerFirm
{
    class Program
    {
        static void Main(string[] args)
        {
            // 11 и 12 Август 2018. Задача 5. Компютърна фирма

            int computerNumber = int.Parse(Console.ReadLine());
            double rating = 0;
            double totalRating = 0;
            int sales = 0;
            double totalSales = 0;


            for (int i = 0; i < computerNumber; i++)
            {
                int salesAndRating = int.Parse(Console.ReadLine());
                rating = salesAndRating % 10;

                totalRating += rating;

                sales = salesAndRating;

                while (sales >= 100)
                {
                    sales /= 10;
                }

                string salesAsString = Convert.ToString(sales);
                double salesAsNumber = double.Parse(salesAsString);

                //Console.WriteLine(salesAsNumber);
                //int salesInt = int.Parse(sales);

                //double salesDoube = double.Parse(sales);

                if (rating == 2)
                {
                    salesAsNumber = 0;
                }

                else if (rating == 3)
                {
                    
                    salesAsNumber *= 0.50;
                }

                else if (rating == 4)
                {
                    salesAsNumber *= 0.70;
                }

                else if (rating == 5)
                {
                    salesAsNumber *= 0.85;
                }

                totalSales += salesAsNumber;
                

                //rating = 0;

                //Console.WriteLine(sales);
                //Console.WriteLine(rating);

                //string salesAsString = Convert.ToString(salesAndRating);
            }

            Console.WriteLine("{0:F2}", totalSales);
            Console.WriteLine($"{(totalRating / computerNumber):F2}");
        }
    }
}
