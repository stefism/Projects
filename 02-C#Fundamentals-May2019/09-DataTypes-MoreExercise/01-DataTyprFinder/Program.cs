using System;

namespace _01_DataTyprFinder
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

                else if (input == "true" || input == "false")
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                
                else
                {
                    bool isNumber = double.TryParse(input, out double result);

                    if (isNumber)
                    {
                        string intOrDouble = result.ToString();

                        if (intOrDouble.Contains("."))
                        {
                            Console.WriteLine($"{result} is floating point type");
                        }
                        else
                        {
                            Console.WriteLine($"{result} is integer type");
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
