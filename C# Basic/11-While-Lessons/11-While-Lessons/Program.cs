using System;

namespace _11_While_Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            while (!(number >=1 && number <=100))
            {
                
                number = double.Parse(Console.ReadLine());
            }

            Console.WriteLine(number);
        }
    }
}
