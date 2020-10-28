using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine()); // широчина
            int length = int.Parse(Console.ReadLine()); // дължина
            int height = int.Parse(Console.ReadLine()); // височина

            int cubicMeters = width * length * height;
            //int boxNumber = 0;
            int sumbox = 0;

            while (true)
            {
                string numberOrDone = Console.ReadLine();

                if (numberOrDone == "Done")

                {
                    Console.WriteLine($"{cubicMeters - sumbox} Cubic meters left.");
                    break;
                }

                int noDone = int.Parse(numberOrDone);
                sumbox = sumbox + noDone;

                if (sumbox > cubicMeters)

                {
                    Console.WriteLine($"No more free space! You need {sumbox - cubicMeters} Cubic meters more.");
                    break;
                }
                
            }


        }
    }
}
