using System;

namespace _01_DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                else if (input.ToLower() == "true" || input.ToLower() == "false")
                {
                    Console.WriteLine($"{input} is boolean type");
                }

                else
                {
                    bool isNumber = double.TryParse(input, out double result);

                    if (isNumber)
                    {
                        //string intOrDouble = result.ToString();

                        if (input.Contains("."))
                        {
                            Console.WriteLine($"{input} is floating point type");
                        }
                        else
                        {
                            Console.WriteLine($"{input} is integer type");
                        }

                    }
                    else
                    {
                        if (input.Length > 1)
                        {
                            Console.WriteLine($"{input} is string type");
                        }
                        else
                        {
                            Console.WriteLine($"{input} is character type");
                        }
                    }
                }
            }
        }
    }
}
