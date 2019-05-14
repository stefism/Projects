using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;
            int counter = 1;

            for (int i = number1; i <= number2; i++)
            {
                string number1AsString = i + "";

                sumOdd = 0; sumEven = 0;

                for (int n = 0; n < number1AsString.Length; n++) // е тука май гърми
                {
                    
                    int realNumber1 = (int)char.GetNumericValue(number1AsString[n]);

                    counter++;

                    if (counter % 2 == 1)
                    {
                        sumOdd += realNumber1;
                    }
                    if (counter % 2 == 0)
                    {
                        sumEven += realNumber1;
                    }

                    //if (sumOdd == sumEven) // ТУКА НЕМА КАК ДА ПРОРАБОТИ!
                    //{
                    //    Console.Write(i + " ");
                    //    //sumOdd = 0; sumEven = 0;
                    //}
                }

                if (sumOdd == sumEven)
                {
                    Console.Write(i + " ");
                    //sumOdd = 0; sumEven = 0;
                }
            }
        }
    }
}
