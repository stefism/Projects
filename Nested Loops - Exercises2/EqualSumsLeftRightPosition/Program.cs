using System;

namespace EqualSumsLeftRightPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = number1; i <= number2; i++)
            {
                string number1AsString = i + "";

                int realNumber1 = (int)char.GetNumericValue(number1AsString[0]);
                int realNumber2 = (int)char.GetNumericValue(number1AsString[1]);
                int realNumber3 = (int)char.GetNumericValue(number1AsString[2]);
                int realNumber4 = (int)char.GetNumericValue(number1AsString[3]);
                int realNumber5 = (int)char.GetNumericValue(number1AsString[4]);

                leftSum = realNumber1 + realNumber2;
                rightSum = realNumber4 + realNumber5;

                if (leftSum == rightSum)
                {
                    Console.Write(i + " ");
                    continue;
                }
                else if (leftSum > rightSum)
                {
                    rightSum += realNumber3;
                }
                else if (leftSum < rightSum)
                {
                    leftSum += realNumber3;
                }

                if (leftSum == rightSum)
                {
                    Console.Write(i + " ");
                }

                // Console.WriteLine($"{realNumber1}-{realNumber2}-{realNumber3}-{realNumber4}-{realNumber5}");


                //for (int n = 0; n < number1AsString.Length; n++) // е тука май гърми
                //{

                // int realNumber1 = (int)char.GetNumericValue(number1AsString[n]);

                //n1 = number1AsString[0]; // Това им дава ACCSSI стойностите!
                //n2 = number1AsString[1];
                //n3 = number1AsString[2];
                //n4 = number1AsString[3];
                //n5 = number1AsString[4];
                //}

                // Console.WriteLine($"{n1}-{n2}-{n3}-{n4}-{n5}-"); // Това им отпечатва ACCSSI стойностите!

            }
        }
    }
}
