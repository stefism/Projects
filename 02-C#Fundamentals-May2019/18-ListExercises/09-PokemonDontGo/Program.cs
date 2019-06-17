using System;
using System.Collections.Generic;
using System.Linq;

namespace _09PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            // Увеличаваме всички, които са ПО-МАЛКИ ИЛИ РАВНИ.
            // Намаляваме всички, които са ПО-ГОЛЕМИ.
            int sum = 0;

            while (input.Count >= 1)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int numberToRemove = input[0];
                    sum += numberToRemove;
                    input[0] = input[input.Count - 1];
                    input = IncreaseAndDecreaseNumbers(input, numberToRemove);
                }

                else if (index > input.Count-1)
                {
                    int numberToRemove = input[input.Count-1];
                    sum += numberToRemove;
                    input[input.Count - 1] = input[0];
                    input = IncreaseAndDecreaseNumbers(input, numberToRemove);
                }

                else
                {
                    int numberToRemove = input[index];
                    sum += numberToRemove;
                    input.RemoveAt(index);
                    input = IncreaseAndDecreaseNumbers(input, numberToRemove);
                }
            }

            Console.WriteLine(sum);
        }

        static List<int> IncreaseAndDecreaseNumbers (List<int> input, int index)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] <= index)
                {
                    input[i] += index;
                }
                else if (input[i] > index)
                {
                    input[i] -= index;
                }
            }
            return input;
        }
    }
}
