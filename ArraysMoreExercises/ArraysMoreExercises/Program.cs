using System;
using System.Collections.Generic;
using System.Linq;

namespace _01EncryptSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameNumber = int.Parse(Console.ReadLine());
            List<int> result = new List<int>();

            int sumName = 0;
            int totalSum = 0;

            for (int i = 0; i < nameNumber; i++)
            {
                string name = Console.ReadLine();
                for (int j = 0; j < name.Length; j++)
                {
                    if (name[j] == 'a' || name[j] == 'e' || name[j] == 'i' || name[j] == 'o'
                        || name[j] == 'u' || name[j] == 'A' || name[j] == 'E' || name[j] == 'I'
                        || name[j] == 'O' || name[j] == 'U')
                    {
                        sumName = name[j] * name.Length;
                        totalSum += sumName;
                    }
                    else
                    {
                        sumName = name[j] / name.Length;
                        totalSum += sumName;
                    }
                }

                result.Add(totalSum);
                totalSum = 0;
            }

            result.Sort();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
