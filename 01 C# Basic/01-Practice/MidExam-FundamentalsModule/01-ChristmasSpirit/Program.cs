using System;

namespace _01_ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Retake Mid Exam - 18 December 2018

            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            Decoration decoration = new Decoration();

            double spirit = 0;
            double cost = 0;

            for (int i = 1; i <= days; i++)
            {
                // Когато проверката за 11ти ден е най-долу, дава 60 от 100.
                // Явно това е защото другите стойности зависят от количеството.
                // Странно тогава защо минава втория нулев тест?
                // Значи когато имаме в задачата промяна на стойности, които преди това са дефинирани най-горе,
                // трябва да правим проверка първо за тяхната промяна. Най-горе.

                if (i % 11 == 0)
                {
                    quantity += 2;
                }

                if (i % 2 == 0)
                {
                    cost += decoration.ornamentSet * quantity;
                    spirit += 5;
                }

                if (i % 3 == 0)
                {
                    cost += decoration.TreeSkirt * quantity;
                    cost += decoration.TreeGarlands * quantity;
                    spirit += 13;
                }

                if (i % 5 == 0)
                {
                    cost += decoration.TreeLights * quantity;
                    spirit += 17;

                    if (i % 3 == 0)
                    {
                        spirit += 30;
                    }
                }

                if (i % 10 == 0)
                {
                    spirit -= 20;
                    cost += decoration.TreeSkirt;
                    cost += decoration.TreeGarlands;
                    cost += decoration.TreeLights;
                }

                //if (i % 11 == 0)
                //{
                //    quantity += 2;
                //}
            }

            if (days % 10 == 0)
            {
                spirit -= 30;
            }

            Console.WriteLine($"Total cost: {cost}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
    class Decoration
    {
        public double ornamentSet = 2;
        public double TreeSkirt = 5;
        public double TreeGarlands = 3;
        public double TreeLights = 15;

    }
}
