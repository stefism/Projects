using System;

namespace ProfitBanknotiIMoneti
{
    class Program
    {
        static void Main(string[] args)
        {
            // От допълнителните упражнения за циклите Nested Loops More Exercises - Exercise

            int coins1Lv = int.Parse(Console.ReadLine());
            int coins2Lv = int.Parse(Console.ReadLine());
            int banknote5Lv = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int OneLeva = 0; OneLeva <= coins1Lv; OneLeva++)
            {
                for (int TwoLeva = 0; TwoLeva <= coins2Lv; TwoLeva++)
                {
                    for (int note5Lv = 0; note5Lv <= banknote5Lv; note5Lv++)
                    {
                        if ((OneLeva * 1) + (TwoLeva * 2) + (note5Lv * 5) == sum)
                        {
                            Console.WriteLine($"{OneLeva} * 1 lv. + {TwoLeva} * 2 lv. + {note5Lv} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
