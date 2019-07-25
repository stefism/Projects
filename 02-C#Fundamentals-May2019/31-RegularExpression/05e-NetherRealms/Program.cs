using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05e_NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var infoDictionary = new Dictionary<string, Values>();

            for (int i = 0; i < input.Length; i++)
            {
                string currentInput = input[i];

                var health = new Regex(@"([^0-9\+\-\*\/\.])");

                var digit = new Regex(@"-?\d+\.?\d*");
               
                // var digit = new Regex(@"([\-\+]?[0-9]?\.?[0-9])"); - Не!

                var multiplySumbol = new Regex(@"\*");

                var divideSymbol = new Regex(@"\/");


                var matchHealth = health.Matches(currentInput);

                string healthChars = string.Join("", matchHealth);

                int totalHealth = 0;

                for (int j = 0; j < healthChars.Length; j++)
                {
                    totalHealth += healthChars[j];
                }

                var digitMatch = digit.Matches(currentInput);

                double[] digits = digitMatch.Select(x => x.Value).Select(double.Parse).ToArray();

                double damage = digits.Sum();

                var multiplyMatch = multiplySumbol.Matches(currentInput);
                var divideMatch = divideSymbol.Matches(currentInput);

                if (multiplyMatch.Count > 0)
                {
                    damage *= multiplyMatch.Count * 2;
                }

                if (divideMatch.Count > 0)
                {
                    damage /= divideMatch.Count * 2;
                }

                infoDictionary[currentInput] = new Values { Health = totalHealth, Damage = damage};
            }

            infoDictionary = infoDictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in infoDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Health} health, {item.Value.Damage:F2} damage");
            }
        }
    }

    class Values
    {
        public int Health { get; set; }
        public double Damage { get; set; }
    }
}
