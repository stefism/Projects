using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNumberA = Console.ReadLine().Split(".").ToArray();
            string[] inputNumberB = Console.ReadLine().Split(".").ToArray();

            string left = inputNumberA[1];
            string right = inputNumberB[1];

            List<int> numberA = new List<int>();
            List<int> numberB = new List<int>();

            if (left.Length < 6 || right.Length < 6)
            {
                for (int i = 0; i < left.Length; i++)
                {
                    numberA.Add(int.Parse(left[i].ToString()));
                }

                for (int j = 0; j < right.Length; j++)
                {
                    numberB.Add(int.Parse(right[j].ToString()));
                }
            }

            else
            {
                for (int i = 0; i < 6; i++)
                {
                    //char charValue = left[i];
                    //string stringValue = charValue.ToString();
                    //int intValue = int.Parse(stringValue);

                    numberA.Add(int.Parse(left[i].ToString()));

                    numberB.Add(int.Parse(right[i].ToString())); // Това прави същото като горното! Горното е разбито на по-малки операции.
                }
            }

            if (numberA.Sum() == numberB.Sum())
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
