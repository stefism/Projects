using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int thousandths = 1; thousandths <=9; thousandths++) // хилядни
            {
                for (int hundreds = 1; hundreds <= 9; hundreds++) // стотици
                {
                    for (int tens = 1; tens <= 9; tens++) // десетици
                    {
                        for (int units = 1; units <= 9; units++) // единици
                        {
                            if (number % thousandths == 0 && number % hundreds == 0 && number % tens == 0 && number % units == 0)
                            {
                                Console.Write($"{thousandths}{hundreds}{tens}{units} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
