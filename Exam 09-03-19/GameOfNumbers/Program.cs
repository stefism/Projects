using System;

namespace GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayerName = Console.ReadLine();
            string secondPlayerName = Console.ReadLine();

            int firstPlayerPoints = 0;
            int secondPlayerPoints = 0;

            while (true)
            {
                string endGameOrCard = Console.ReadLine();

                if (endGameOrCard == "End of game")
                {
                    Console.WriteLine($"{firstPlayerName} has {firstPlayerPoints} points");
                    Console.WriteLine($"{secondPlayerName} has {secondPlayerPoints} points");
                    break;
                }

                int firstCard = int.Parse(endGameOrCard);
                int secondCard = int.Parse(Console.ReadLine());

                if (firstCard > secondCard)
                {
                    firstPlayerPoints += firstCard - secondCard;
                }
                else if (firstCard < secondCard)
                {
                    secondPlayerPoints += secondCard - firstCard;
                }
                else if (firstCard == secondCard)
                {
                    Console.WriteLine("Number wars!");

                    int player1lastCard = int.Parse(Console.ReadLine());
                    int player2lastCard = int.Parse(Console.ReadLine());

                    if (player1lastCard > player2lastCard)
                    {
                        Console.WriteLine($"{firstPlayerName} is winner with {firstPlayerPoints} points");
                        break;
                    }
                    else if (player1lastCard < player2lastCard)
                    {
                        Console.WriteLine($"{secondPlayerName} is winner with {secondPlayerPoints} points");
                        break;
                    }
                }
            }
        }
    }
}
