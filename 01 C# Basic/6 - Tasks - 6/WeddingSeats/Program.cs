using System;

namespace WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3 и 4 Ноември 2018 Задача 6. Сватбени места

            char lastSector = char.Parse(Console.ReadLine());
            int rowsInFirstSector = int.Parse(Console.ReadLine());
            int numberOfSeatsOddRow = int.Parse(Console.ReadLine());

            int seatsInSector = 0;

            int counreRow = 0;
            int seatsCounter = 0;

            for (int sector = 'A'; sector <= lastSector; sector++)
            {
                for (int rows = 1; rows <= rowsInFirstSector; rows++)
                {
                    counreRow++;

                    seatsInSector = numberOfSeatsOddRow;

                    if (rows % 2 == 0) //
                    {
                        seatsInSector =  numberOfSeatsOddRow + 2;
                    }

                    if (rows % 2 == 1) //
                    {
                        seatsInSector = numberOfSeatsOddRow;
                    }

                    for (int seats = 'a'; seats < 'a'+ seatsInSector; seats++)
                    {
                        Console.WriteLine($"{(char)sector}{rows}{(char)seats}");
                        //rowInSector = rowsInFirstSector;
                        seatsCounter++;
                    }
                }
                rowsInFirstSector++;
            }
            Console.WriteLine(seatsCounter);
        }
    }
}
