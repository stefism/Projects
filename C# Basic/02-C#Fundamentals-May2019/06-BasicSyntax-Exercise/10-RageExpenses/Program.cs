using System;

namespace _10_RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double rageExpences = 0;
            int keyboardCounter = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    rageExpences += headsetPrice;
                }

                if (i % 3 == 0)
                {
                    rageExpences += mousePrice;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    rageExpences += keyboardPrice;
                    keyboardCounter++;

                    if (keyboardCounter % 2 == 0)
                    {
                        rageExpences += displayPrice;
                    }
                }
            }

            Console.WriteLine($"Rage expenses: {rageExpences:F2} lv.");
        }
    }
}
