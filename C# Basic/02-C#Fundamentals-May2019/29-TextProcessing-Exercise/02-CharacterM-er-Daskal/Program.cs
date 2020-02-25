using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_CharacterM_er_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();

            string firstStr = strings[0];
            string secondSrt = strings[1];

            string minStr = string.Empty;
            string maxStr = string.Empty;

            if (firstStr.Length > secondSrt.Length)
            {
                minStr = secondSrt;
                maxStr = firstStr;
            }
            else
            {
                minStr = firstStr;
                maxStr = secondSrt;
            }

            int totalSum = 0;

            for (int i = 0; i < minStr.Length; i++)
            {
                totalSum += minStr[i] * maxStr[i];
            }

            for (int i = minStr.Length; i < maxStr.Length; i++)
            {
                totalSum += maxStr[i];
            }

            Console.WriteLine(totalSum);
        }
    }
}
