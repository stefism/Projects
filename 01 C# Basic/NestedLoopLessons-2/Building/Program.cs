using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFloors = int.Parse(Console.ReadLine());
            int numberOfRooms = int.Parse(Console.ReadLine());
            int counterFloors = numberOfFloors;
            int counterRooms = 0;

            char odd = ' ';
            char even = ' ';

            int numbers = 10;

            for (int f = numberOfFloors; f >= 1; f--)
            {

                counterRooms = counterFloors * numbers;

                if (counterFloors % 2 == 0)
                {
                    if (counterFloors == numberOfFloors)
                    {
                        even = 'L';
                    }
                    else
                    {
                        even = 'O';
                    }

                    for (int r = 0; r < numberOfRooms; r++)
                    {
                        Console.Write($"{even}{counterRooms} ");
                        counterRooms++;
                        
                    }
                    
                    Console.WriteLine();
                }

                else
                {
                    if (counterFloors == numberOfFloors)
                    {
                        odd = 'L';
                    }
                    else
                    {
                        odd = 'A';
                    }

                    for (int r = 0; r < numberOfRooms; r++)
                    {
                        Console.Write($"{odd}{counterRooms} ");
                        counterRooms++;
                    }

                    Console.WriteLine();
                }

                counterFloors--;
            }
        }
    }
}
