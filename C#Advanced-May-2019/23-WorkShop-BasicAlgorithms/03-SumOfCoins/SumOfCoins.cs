using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        int currentSum = 0;
        int currentCoinsPosition = 0;

        Dictionary<int, int> selectedCoins = new Dictionary<int, int>();

        coins = coins.OrderByDescending(x => x).ToList();

        while (currentSum < targetSum)
        {
            currentSum += coins[currentCoinsPosition];

            if (currentSum > targetSum)
            {
                currentSum -= coins[currentCoinsPosition];
                currentCoinsPosition++;
            }
            else
            {
                if (!selectedCoins.ContainsKey(coins[currentCoinsPosition]))
                {
                    selectedCoins[coins[currentCoinsPosition]] = 0;
                }

                selectedCoins[coins[currentCoinsPosition]]++;
            }

            if (currentCoinsPosition == coins.Count)
            {
                Console.WriteLine("Error");
                Environment.Exit(1);
            }
        }

        return selectedCoins;
    }
}