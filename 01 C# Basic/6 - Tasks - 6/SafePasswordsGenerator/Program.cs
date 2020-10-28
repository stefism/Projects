using System;

namespace SafePasswords_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 и 2 Декември 2018 Задача 6. Генератор засигурнипароли

            int a_Number = int.Parse(Console.ReadLine());
            int b_Number = int.Parse(Console.ReadLine());
            int maxPasswordCombination = int.Parse(Console.ReadLine());

            int combinationCounter = 0;
            int A = 35;
            int B = 64;
            int x = 0;
            int y = 0;

            while (true)
            {


                for (x = 1; x < a_Number; x++)
                {

                    for (y = 1; y < b_Number; y++)
                    {

                        Console.Write($"{(char)A}{(char)B}{x}{y}{(char)B}{(char)A}|");

                        A++; B++;

                        combinationCounter++;

                        if (combinationCounter == maxPasswordCombination)
                        {
                            break;
                        }

                        //break;
                    }

                    break;
                }

                break;
            }
        }
    }
}
