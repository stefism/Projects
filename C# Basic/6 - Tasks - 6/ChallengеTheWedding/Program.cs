using System;

namespace ChallengеTheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3 и 4 Ноември 2018. Задача 6. Предизвикай Сватбата

            int menClients = int.Parse(Console.ReadLine());
            int womanClients = int.Parse(Console.ReadLine());
            int freeTablesForSeat = int.Parse(Console.ReadLine());

            int freeTableCounter = 0;

            for (int men = 1; men <= menClients; men++)
            {
                for (int woman = 1; woman <= womanClients; woman++)
                {
                    Console.Write($"({men} <-> {woman}) ");

                    freeTableCounter++;

                    if (freeTableCounter == freeTablesForSeat)
                    {
                        return;
                    }
                }
            }
        }
    }
}
