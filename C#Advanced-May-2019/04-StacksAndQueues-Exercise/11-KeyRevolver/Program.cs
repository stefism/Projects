using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int intelligenceValue = int.Parse(Console.ReadLine());

            int shootCount = 0;

            while (bullets.Count != 0)
            {
                int currentBulletValue = bullets.Pop();
                int currentLockValue = locks.Peek();

                if (currentBulletValue <= currentLockValue)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                shootCount++;
                intelligenceValue -= bulletPrice;

                if (bullets.Count > 0 && shootCount == gunBarrelSize)
                {
                    Console.WriteLine("Reloading!");
                    shootCount = 0;
                }

                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
                    break;
                }
            }

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                return;
            }
        }
    }
}
