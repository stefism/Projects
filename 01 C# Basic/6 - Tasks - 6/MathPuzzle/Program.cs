using System;

namespace MathPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 и 2 Декември 2018. Задача 6. Математически пъзел

            int key = int.Parse(Console.ReadLine());

            bool assembler = true;
            bool multiplication = true;
            int a = 0;
            int b = 0;
            int c = 0;

            int resultAssembler = 0;
            int resultMultiplication = 0;

            for (a = 1; a <= 30; a++)
            {
                for (b = 1; b <= 30; b++)
                {
                    for (c = 1; c <= 30; c++)
                    {
                        assembler = a < b && b < c; // събиране
                        multiplication = a > b && b > c; // умножение

                        if (assembler)
                        {
                            if (a + b + c == key)
                            {
                                resultAssembler = a + b + c;
                                Console.WriteLine($"{a} + {b} + {c} = {resultAssembler}");
                            }
                        }
                        

                        if (multiplication)
                        {
                            if (a * b * c == key)
                            {
                                resultMultiplication = a * b * c;
                                Console.WriteLine($"{a} * {b} * {c} = {resultMultiplication}");
                            }
                        }
                        
                    }
                }   
            }

            if (resultMultiplication != key && resultAssembler != key)
            {
                Console.WriteLine("No!");
            }
        }
    }
}
