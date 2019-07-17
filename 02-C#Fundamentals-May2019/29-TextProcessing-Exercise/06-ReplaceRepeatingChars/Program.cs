using System;

namespace _06_ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (i + 1 == inputString.Length - 1 && inputString[inputString.Length-1] != inputString[inputString.Length - 2])
                {
                    break;
                }

                if (inputString[i+1] == inputString[i])
                {
                    inputString =  inputString.Remove(i+1, 1);
                    i--;

                    if (i+1 == inputString.Length-1)
                    {
                        break;
                    }

                    continue;
                }
            }

            Console.WriteLine(inputString);
        }
    }
}
