using System;

namespace Substitute_Smeni_
{
    class Program
    {
        static void Main(string[] args)
        {
            // 28 и 29 юли 2018 Задача 6. Смени

            int K = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            int changeCounter = 0;

            for (int number1 = K; number1 <= 8; number1 ++)
            {

                if (changeCounter == 6)
                {
                    break;
                }

                for (int number2 = 9; number2 >= L; number2 --)
                {
                    for (int number3 = M; number3 <= 8; number3 ++)
                    {
                        for (int number4 = 9; number4 >= N; number4 --)
                        {
                            if (number1 % 2 == 0 && number2 % 2 == 1 && number3 % 2 == 0 && number4 % 2 == 1)
                            {
                                if (number1 == number3 && number2 == number4)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    Console.WriteLine($"{number1}{number2} - {number3}{number4}");
                                    changeCounter++;
                                }

                                //if (changeCounter == 6) // Баботи. Браво за ретърна.
                                //{
                                //    return;
                                //}

                                //if (changeCounter == 6) // Не излиза от всички цикли така.
                                //{
                                //    break;
                                //}
                            }
                        }
                    }
                }
            }
        }
    }
}
