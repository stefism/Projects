using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] numbers = new int[] {1, 101, 50, 18, 42, 99, 7, 6 }; // Това прави същото като долното но по-лесно.
            int[] numbers = { 1, 101, 50, 18, 42, 99, 7, 6 }; // Може и така за по-кратко.

            //numbers[0] = 1;
            //numbers[1] = 101;
            //numbers[2] = 50;
            //numbers[3] = 18;
            //numbers[4] = 42;
            //numbers[5] = 99;

            int sum = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                sum = sum + numbers[index];
            }

            // int sum = numbers[0] + numbers[1] + numbers[2]
            //    + numbers[3] + numbers[4]; - това е същото като горното, но горното е във фор цикъл. Много по-удобно.

            double average = (double)sum / numbers.Length;

            Console.WriteLine(average);
        }
    }
}
