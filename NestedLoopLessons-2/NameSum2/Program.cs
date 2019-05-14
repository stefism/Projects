using System;

namespace NamesSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int sumMax = 0;
            string nameMax = "";

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "STOP")
                {
                    Console.WriteLine($"Winner is {nameMax} - {sumMax}!");
                    break;
                }

                for (int i = 0; i < name.Length; i++)
                {
                    int letterValue = name[i];
                    sum += letterValue;
                }

                //foreach (char c in name)
                //{
                //    //Console.WriteLine(System.Convert.ToInt32(c));
                //    System.Convert.ToInt32(c);
                //    sum = sum + c;
                //    //Console.WriteLine($"Sum is: {sum}");
                //}

                if (sum > sumMax)
                {
                    sumMax = sum;
                    nameMax = name;
                }

                sum = 0;
            }
        }
    }
}
