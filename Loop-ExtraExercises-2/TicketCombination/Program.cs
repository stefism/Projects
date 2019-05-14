using System;

namespace TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int combinationNumber = int.Parse(Console.ReadLine());
            int counterCombination = 0;

            for (int bl = 'B'; bl <= 'L'; bl+=2)
            {
                for (int fa = 'f'; fa >= 'a'; fa--)
                {
                    for (int ac = 'A'; ac <= 'C'; ac++)
                    {
                        for (int from1To10 = 1; from1To10 <= 10; from1To10++)
                        {
                            for (int from10To1 = 10; from10To1 >= 1; from10To1--)
                            {
                                counterCombination++;

                                if (counterCombination == combinationNumber)
                                {
                                    Console.WriteLine($"Ticket combination: {(char)bl}{(char)fa}{(char)ac}{from1To10}{from10To1}");
                                    int prize = bl + fa + ac + from1To10 + from10To1;
                                    Console.WriteLine($"Prize: {prize} lv.");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
