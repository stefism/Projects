using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFoodQuantity = int.Parse(Console.ReadLine());

            Queue<int> orderQuantity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(orderQuantity.Max());

            while (orderQuantity.Count > 0)
            {
                int currentOrderValue = orderQuantity.Peek();

                if (totalFoodQuantity >= currentOrderValue)
                {
                    orderQuantity.Dequeue();
                    totalFoodQuantity -= currentOrderValue;
                }
                else
                {
                    Console.Write("Orders left: ");
                    Console.WriteLine(string.Join(" ", orderQuantity));
                    break;
                }
            }

            if (orderQuantity.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
