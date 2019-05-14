using System;
using System.Collections.Generic;
using System.Linq;

namespace _06CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> player1Cards = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> player2Cards = Console.ReadLine().Split().Select(int.Parse).ToList();

            int count = player1Cards.Count;

            int player2Sum = 0;
            int player1Sum = 0;

            for (int i = 0; i <= count; i++)
            {
                if (player1Cards[0] > player2Cards[0])
                {
                    int firstNumber = player1Cards[0];
                    player1Cards.RemoveAt(0);
                    player1Cards.Add(firstNumber);
                    player1Cards.Add(player2Cards[0]);
                    player2Cards.RemoveAt(0);
                }

                else if (player2Cards[0] > player1Cards[0])
                {
                    int firstNumber = player2Cards[0];
                    player2Cards.RemoveAt(0);
                    player2Cards.Add(firstNumber);
                    player2Cards.Add(player1Cards[0]);
                    player1Cards.RemoveAt(0);
                }

                else if (player1Cards[0] == player2Cards[0])
                {
                    player1Cards.RemoveAt(0);
                    player2Cards.RemoveAt(0);
                }

                int minIndex = Math.Min(player1Cards.Count, player2Cards.Count);
                count = minIndex;
                i = 0;
            }

            if (player2Cards.Count == 0)
            {
                player1Sum = player1Cards.Sum();
            }
            else
            {
                player1Sum = player1Cards.Sum() + player2Cards[0];
            }

            if (player1Cards.Count == 0)
            {
                player2Sum = player2Cards.Sum();
            }
            else
            {
                player2Sum = player2Cards.Sum() + player1Cards[0];
            }


            if (player1Sum > player2Sum)
            {
                Console.WriteLine($"First player wins! Sum: {player1Sum}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {player2Sum}");
            }
        }
    }
}
