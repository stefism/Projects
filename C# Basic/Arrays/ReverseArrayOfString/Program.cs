using System;
using System.Linq;

namespace ReverseArrayOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            string items = Console.ReadLine();
            string[] itemsToRevese = items.Split().ToArray();

            //double[] numbersAsString = numbers.Split().Select(double.Parse).ToArray();
            Array.Reverse(itemsToRevese);

            Console.WriteLine(string.Join(" ", itemsToRevese));

            //Console.WriteLine(string.Join(" ", items));


            //for (int i = 0; i < itemsToRevese.Length; i++)
            //{
            //    Console.Write(itemsToRevese[i]);
            //}
        }
    }
}
