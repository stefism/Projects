using System;
using System.Collections.Generic;
using System.Linq;

namespace _03m_TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> nonNumbersList = new List<string>();
            List<int> numbersList = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            //List<string> result = new List<string>();
            string result = string.Empty;

            // Пълниме числата и не числата
            for (int i = 0; i < input.Length; i++)
            {
                bool isNumber = int.TryParse(input[i].ToString(), out int currentNumber);

                if (isNumber)
                {
                    numbersList.Add(currentNumber);
                }
                else
                {
                    nonNumbersList.Add(input[i].ToString());
                }
            }

            // Пълниме листа за взимане и листа за прескачане
            //for (int i = 0; i < numbersList.Count; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        takeList.Add(numbersList[i]);
            //    }
            //    else
            //    {
            //        skipList.Add(numbersList[i]);
            //    }
            //}

            // Изкарваме резултата съгласно условието
            int indexCount = 0;

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    if (numbersList[i] > 0)
                    {
                        string currentResult = ReturnResult(nonNumbersList, indexCount, numbersList[i]);
                        indexCount += numbersList[i];
                        result += currentResult;
                    }
                }
                else
                {
                    indexCount += numbersList[i];
                }
            }

            Console.WriteLine(result);
        }
        static string ReturnResult(List<string> input, int indexCount, int takeList)
        {
            string currentResult = string.Empty;

            for (int i = indexCount; i < indexCount + takeList; i++)
            {
                if (i > input.Count-1)
                {
                    break;
                }
                currentResult += input[i];
            }

            return currentResult;
        }
    }
}
