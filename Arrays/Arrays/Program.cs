using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];

            numbers[0] = 1;
            numbers[1] = 101;
            numbers[2] = 50;
            numbers[3] = 18;
            numbers[4] = 42;

            int sum = numbers[0] + numbers[1] + numbers[2]
                + numbers[3] + numbers[4];

            double average = sum / 5.0;

            Console.WriteLine(average);
        }
    }
}
