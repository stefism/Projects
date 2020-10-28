using System;

namespace SafePasswordsGenerator
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

            while (A <= 55)
            {
                A++;
                for (int B = 64; B <= 96; B++)
                {
                    for (int x = 1; x <= a_Number; x++)
                    {
                        for (int y = 1; y <= b_Number; y++)
                        {
                            Console.Write($"{(char)A}{(char)B}{x}{y}{(char)B}{(char)A}|");
                            combinationCounter++;

                            if (combinationCounter < maxPasswordCombination)
                            {
                                break;
                            }
                        }
                    }
                   
                }
                
            }

        }
    }
}
