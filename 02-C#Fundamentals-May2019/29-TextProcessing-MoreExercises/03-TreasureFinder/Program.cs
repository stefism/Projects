using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _03_TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split().Select(int.Parse).ToArray();
            while (true)
            {
                string inputString = Console.ReadLine();
                var finalString = new StringBuilder();

                if (inputString == "find")
                {
                    break;
                }

                for (int i = 0; i < inputString.Length; i++)
                {
                    for (int key = 0; key < keys.Length; key++)
                    {
                        if (i == inputString.Length)
                        {
                            break;
                        }

                        int newAscciCode = inputString[i] - keys[key];
                        i++;

                        finalString.Append((char)newAscciCode);
                    }

                    i--;
                }

                string decodedString = finalString.ToString();

                string[] minerals = decodedString.Split("&");
                string mineral = minerals[1];

                string[] coordinates = decodedString.Split(new char[] {'<', '>' });
                string coordinate = coordinates[1];

                Console.WriteLine($"Found {mineral} at {coordinate}");
            }
        }
    }
}
