using System;
using System.Linq;

namespace ReadingArrays_SplitOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            string [] valuesAsString = values.Split();

            // int[] valuesAsString = values.Split().Select(int.Parse).ToArray();
            // Този ред прави същото като цикъла по-долу.
            // Казва да вземе отделните елементи и да ги парсне в масив, като число.

            int[] numbers = new int[valuesAsString.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(valuesAsString[i]);
            }

            // Четем числа като стринг, разделени с интервал от конзолата.
            // После със сплит казваме, където има интервал да ги раздели и
            // да ги направи на масив всеки стринг по отделно.
            // после правим масив с дължина, колкото са вече елементите след разделянето
            // с цикъла казваме всеки елемент да го парсне към число
        }
    }
}
