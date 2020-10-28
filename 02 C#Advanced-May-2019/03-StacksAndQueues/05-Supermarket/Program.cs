using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> supermarket = new Queue<string>();

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    Console.WriteLine($"{supermarket.Count} people remaining.");

                    break;
                }

                else if (name == "Paid")
                {
                    int count = supermarket.Count;

                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(supermarket.Dequeue());
                    }
                }

                else
                {
                    supermarket.Enqueue(name);
                }
            }
        }
    }
}
