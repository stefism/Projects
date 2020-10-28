using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Socks
{
    class Program
    {
        static void Main()
        {
            Stack<int> leftSocks = new Stack<int>(Console.ReadLine()
                .Split().Select(int.Parse));

            Queue<int> rightSocks = new Queue<int>(Console.ReadLine()
                .Split().Select(int.Parse));

            List<int> socksPairs = new List<int>();

            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                int currentLeftSock = leftSocks.Peek();
                int currentRightSock = rightSocks.Peek();

                if (currentLeftSock == currentRightSock)
                {
                    rightSocks.Dequeue();
                    currentLeftSock++;
                    leftSocks.Pop();
                    leftSocks.Push(currentLeftSock);
                }
                else if (currentLeftSock < currentRightSock)
                {
                    leftSocks.Pop();
                }
                else if (currentLeftSock > currentRightSock)
                {
                    int pairSum = currentLeftSock + currentRightSock;

                    leftSocks.Pop();
                    rightSocks.Dequeue();

                    socksPairs.Add(pairSum);
                }
            }

            int maxSockPairSum = socksPairs.Max();

            Console.WriteLine(maxSockPairSum);
            Console.WriteLine(string.Join(" ", socksPairs));
        }
    }
}
