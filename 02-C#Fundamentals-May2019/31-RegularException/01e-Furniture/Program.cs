using System;
using System.Text.RegularExpressions;

namespace _01e_Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            // >>([A-Z]+[a-z]+|[A-Z]+)<<(\d+\.?\d+)!(\d+)
            // >>(?<name>[A-Z]+[a-z]+|[A-Z]+)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)

            var regex = new Regex(@">>(?<name>[A-Z]+[a-z]+|[A-Z]+)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)");

            while (true)
            {
                string currentInfo = Console.ReadLine();

                if (currentInfo == "Purchase")
                {
                    Console.WriteLine("Bought furniture:");
                }

                var matches = regex.Matches(currentInfo);
                

            }
        }
    }
}
