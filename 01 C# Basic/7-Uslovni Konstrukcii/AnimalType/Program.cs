using System;

namespace AnimalType
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfAnimal = Console.ReadLine();

            switch (typeOfAnimal)
            {
                case "dog":
                    Console.WriteLine("mammal");
                    break;

                case "crocodile":
                case "tortoise":
                case "snake":
                    Console.WriteLine("reptile");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;

            }

        }
    }
}
