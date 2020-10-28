using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05e_Nether___Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^0-9+\-*\/.]";
            Regex healthRegex = new Regex(healthPattern);

            string digitPattern = @"-?\d+\.?\d*";
            Regex digitRegex = new Regex(digitPattern);

            string operatorPattern = @"[*\/]";
            Regex operatorRegex = new Regex(operatorPattern);

            string[] demonNames = Regex.Split(Console.ReadLine(), @"\s*,\s*")
                .OrderBy(x => x).ToArray();

            for (int i = 0; i < demonNames.Length; i++)
            {
                string currentDemon = demonNames[i];

                int currentHealth = 0;

                var healthSymbols = healthRegex.Matches(currentDemon);

                foreach (Match symbol in healthSymbols)
                {
                    currentHealth += char.Parse(symbol.Value);
                }

                var digitMatch = digitRegex.Matches(currentDemon);

                double baseDamage = 0;

                foreach (Match number in digitMatch)
                {
                    baseDamage += double.Parse(number.Value);
                }

                var operatorMatch = operatorRegex.Matches(currentDemon);

                foreach (Match operatorr in operatorMatch)
                {
                    string @operator = operatorr.Value;

                    if (@operator == "*")
                    {
                        baseDamage *= 2;
                    }
                    else
                    {
                        baseDamage /= 2;
                    }
                }

                Console.WriteLine($"{currentDemon} - {currentHealth} health, {baseDamage:F2} damage");
            }
        }
    }
}
