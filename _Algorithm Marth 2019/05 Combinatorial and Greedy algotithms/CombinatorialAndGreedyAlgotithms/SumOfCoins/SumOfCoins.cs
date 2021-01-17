using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    class SumOfCoins //Greedy algorythm
    {
        static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var result = new Dictionary<int, int>();

            coins = coins.OrderByDescending(c => c).ToList();

            var coinIndex = 0;
            var currentSum = 0;

            while (coinIndex < coins.Count && currentSum != targetSum)
            {
                var currentCoinValue = coins[coinIndex];

                if (currentSum + currentCoinValue > targetSum)
                {
                    coinIndex++;
                    continue;
                }

                var remainingSum = targetSum - currentSum;
                var coinsToTake = remainingSum / currentCoinValue;

                if (coinsToTake > 0)
                {
                    result[currentCoinValue] = coinsToTake;
                    currentSum += coinsToTake * currentCoinValue;
                }
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException("Sorry");
            }

            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
