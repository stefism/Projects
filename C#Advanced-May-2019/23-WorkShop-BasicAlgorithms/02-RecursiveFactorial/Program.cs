using System;

namespace _02_RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int result = Factorial(input);

            Console.WriteLine(result);
        }

        static int Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            int next = Factorial(number - 1);
            int result = number * next;
            return result;
        }

        //static int Factorial5(int number)
        //{
        //    if (number == 0)
        //    {
        //        return 1;
        //    }

        //    int next = Factorial4(number - 1);
        //    int result = number * next;
        //    return result;
        //}
        //static int Factorial4(int number)
        //{
        //    if (number == 0)
        //    {
        //        return 1;
        //    }

        //    int next = Factorial3(number - 1);
        //    int result = number * next;
        //    return result;
        //}
        //static int Factorial3(int number)
        //{
        //    if (number == 0)
        //    {
        //        return 1;
        //    }

        //    int next = Factorial2(number - 1);
        //    int result = number * next;
        //    return result;
        //}
        //static int Factorial2(int number)
        //{
        //    if (number == 0)
        //    {
        //        return 1;
        //    }

        //    int next = Factorial1(number - 1);
        //    int result = number * next;
        //    return result;
        //}
        //static int Factorial1(int number)
        //{
        //    if (number == 0)
        //    {
        //        return 1;
        //    }

        //    int next = Factorial0(number - 1);
        //    int result = number * next;
        //    return result;
        //}

        //static int Factorial0(int number)
        //{
        //    if (number == 0)
        //    {
        //        return 1;
        //    }

        //    int next = Factorial0(number - 1);
        //    int result = number * next;
        //    return result;
        //}
    }
}
