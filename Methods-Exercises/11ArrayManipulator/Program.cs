using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string[] commnands = Console.ReadLine().Split();

                string currentCommand = commnands[0];

                if (currentCommand == "end")
                {
                    Console.WriteLine("[" + string.Join(", ", input) + "]");
                    break;
                }

                switch (currentCommand)
                {
                    case "exchange":

                        int index = int.Parse(commnands[1]);

                        if (index > 0 && index <= input.Length-2)
                        {
                            input = SplitArray(index, input);
                        }

                        else if (index == 0 || index == input.Length-1)
                        {

                        }

                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;

                    case "max":

                        string evenOrOdd = commnands[1];
                        int maxIndex = ReturnMaxEvenOrOddNuber(evenOrOdd, input);

                        if (maxIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(maxIndex);
                        }

                        break;

                    case "min":

                        string evenOrOddMin = commnands[1];
                        int minIndex = ReturnMinEvemOrOddNumber(evenOrOddMin, input);

                        if (minIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(minIndex);
                        }
                        
                        break;

                    case "first":

                        int indexFirst = int.Parse(commnands[1]);

                        if (indexFirst >= 0 && indexFirst <= input.Length-1)
                        {
                            string evenOrOddFirst = commnands[2];
                            string result = ReturnFirtsEvenOrOddElements(indexFirst, evenOrOddFirst, input);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }
                        
                        break;

                    case "last":

                        int indexLast = int.Parse(commnands[1]);

                        if (indexLast >= 0 && indexLast <= input.Length-1)
                        {
                            string evenOrOddLast = commnands[2];
                            string resultLast = ReturnLastEvenOrOddElements(indexLast, evenOrOddLast, input);
                            Console.WriteLine(resultLast);
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }

                        break;
                }
            }
        }

        static string ReturnLastEvenOrOddElements(int count, string evenOrOdd, int[] input)
        {
            int lastCounter = 0;
            List<int> evenOrOddList = new List<int>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                switch (evenOrOdd)
                {
                    case "even":
                        if (input[i] % 2 == 0)
                        {
                            evenOrOddList.Add(input[i]);
                            lastCounter++;
                            if (lastCounter == count)
                            {
                                evenOrOddList.Reverse();
                                return "[" + string.Join(", ", evenOrOddList) + "]";
                            }
                        }
                        break;

                    case "odd":
                        if (input[i] % 2 == 1)
                        {
                            evenOrOddList.Add(input[i]);
                            lastCounter++;
                            if (lastCounter == count)
                            {
                                evenOrOddList.Reverse();
                                return "[" + string.Join(", ", evenOrOddList) + "]";
                            }
                        }
                        break;
                }
                
            }

            return " ";
        }
        static string ReturnFirtsEvenOrOddElements(int count, string evenOrOdd, int[] input)
        {
            int firstCounter = 0;
            List<int> evenOrOddList = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                switch (evenOrOdd)
                {
                    case "even":
                        if (input[i] % 2 == 0)
                        {
                            evenOrOddList.Add(input[i]);
                            firstCounter++;
                            if (firstCounter == count)
                            {
                                return "[" + string.Join(", ", evenOrOddList) + "]";
                            }
                        }
                        break;

                    case "odd":
                        if (input[i] % 2 == 1)
                        {
                            evenOrOddList.Add(input[i]);
                            firstCounter++;
                            if (firstCounter == count)
                            {
                                return "[" + string.Join(", ", evenOrOddList) + "]";
                            }
                         }
                        break;
                }
            }

            return " ";
        }
        static int ReturnMinEvemOrOddNumber(string evenOrOdd, int[] input)
        {
            if (evenOrOdd == "odd")
            {
                int minValue = int.MaxValue;
                int indexCount = -1;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 1)
                    {
                        if (input[i] <= minValue)
                        {
                            minValue = input[i];
                            indexCount = i;
                        }
                    }
                }

                return indexCount;
            }
            else if (evenOrOdd == "even")
            {
                int minValue = int.MaxValue;
                int indexCount = -1;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 0)
                    {
                        if (input[i] <= minValue)
                        {
                            minValue = input[i];
                            indexCount = i;
                        }
                    }
                }

                return indexCount;
            }

            return -1;
        }
        static int ReturnMaxEvenOrOddNuber(string evenOrOdd, int[] input)
        {
            if (evenOrOdd == "odd")
            {
                int maxValue = int.MinValue;
                int indexCount = -1;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 1)
                    {
                        if (input[i] >= maxValue)
                        {
                            maxValue = input[i];
                            indexCount = i;
                        }
                    }
                }

                return indexCount;
            }
            else if (evenOrOdd == "even")
            {
                int maxValue = int.MinValue;
                int indexCount = -1;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 0)
                    {
                        if (input[i] >= maxValue)
                        {
                            maxValue = input[i];
                            indexCount = i;
                        }
                    }
                }

                return indexCount;
            }

            return -1;
        }
        static int[] SplitArray(int index, int[] input)
        {
            int[] splitArr = new int[input.Length];
            int counrerSplit = 0;

            for (int i = index + 1; i <= input.Length - 1; i++)
            {
                splitArr[counrerSplit] = input[i];
                counrerSplit++;
            }

            counrerSplit = index;
            for (int i = 0; i <= index; i++)
            {
                splitArr[counrerSplit] = input[i];
                counrerSplit++;
            }

            return splitArr;
        }
    }
}
