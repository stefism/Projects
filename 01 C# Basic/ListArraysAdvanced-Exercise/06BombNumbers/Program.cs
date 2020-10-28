using System;
using System.Collections.Generic;
using System.Linq;

namespace _05BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> specialNumberAndPower = Console.ReadLine().Split().Select(int.Parse).ToList();

            int specialNumber = specialNumberAndPower[0];
            int power = specialNumberAndPower[1];

            int indexLeft = 0;
            int indexRight = 0;

            // 3 3 4 5 6 7 3
            // 3 1

            for (int i = 0; i < numbers.Count; i++)
            {
                indexLeft = i - 1;
                indexRight = i + 1;

                if (numbers[i] == specialNumber)
                {
                    for (int right = 0; right < power; right++)
                    {
                        if (indexRight <= numbers.Count-1)
                        {
                            numbers.RemoveAt(indexRight);
                        }
                    }

                    for (int left = 0; left < power; left++)
                    {
                        if (indexLeft >= 0)
                        {
                            
                            numbers.RemoveAt(indexLeft);
                            indexLeft--;
                            //numbers.RemoveAt(numbers[(i-1)-j]);
                        }
                    }
                }
            }

            int sumSpecial = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == specialNumber)
                {
                    sumSpecial += numbers[i];
                }
            }

            //Console.WriteLine(sumSpecial);
            //Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(Math.Abs(numbers.Sum() - sumSpecial));
        }
    }
}
