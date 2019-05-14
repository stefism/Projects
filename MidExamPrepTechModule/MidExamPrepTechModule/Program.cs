using System;

namespace _01PartyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mid Exam - 4 November 2018. 01 Party Profit

            int partySize = int.Parse(Console.ReadLine());
            int partyDays = int.Parse(Console.ReadLine());

            int coins = 0;

            for (int i = 1; i <= partyDays; i++)
            {
                //coins += 50;
                //coins -= 2 * partySize;

                if (i % 10 == 0)
                {
                    partySize -= 2;
                }

                if (i % 15 == 0)
                {
                    partySize += 5;
                }

                coins += 50;
                coins -= 2 * partySize;

                if (i % 3 == 0)
                {
                    coins -= 3 * partySize;
                }

                if (i % 5 == 0)
                {
                    coins += 20 * partySize;

                    //if (i % 3 == 0)
                    //{
                    //    coins -= 2 * partySize;
                    //}
                }

                if (i % 3 == 0 && i % 5 == 0)
                {
                    coins -= 2 * partySize;
                }
            }

            //coins = (partyDays * 50) - ((partyDays * 2) * partySize);

            int finalCoins = coins / partySize;
            Console.WriteLine($"{partySize} companions received {finalCoins} coins each.");
        }
    }
}
