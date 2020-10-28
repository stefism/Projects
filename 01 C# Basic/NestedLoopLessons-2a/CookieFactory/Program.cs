using System;

namespace CookieFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int partideNumber = int.Parse(Console.ReadLine());
            string product = "";

            int counterPartide = 0;

            bool flour = false;
            bool eggs = false;
            bool sugar = false;

            while (true)
            {
                if (partideNumber == 0)
                {
                    break;
                }

                product = Console.ReadLine();

                if (product == "flour")
                {
                    flour = true;
                }
                else if (product == "eggs")
                {
                    eggs = true;
                }
                else if (product == "sugar")
                {
                    sugar = true;
                }

                if (product == "Bake!")
                {
                    if (flour == true && eggs == true && sugar == true)
                    {
                        counterPartide++;
                        Console.WriteLine($"Baking batch number {counterPartide}...");
                        flour = false; eggs = false; sugar = false;

                        if (counterPartide == partideNumber)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    }
                }

            }
        }
    }
}
