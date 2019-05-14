using System;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double spaceShipWidth = double.Parse(Console.ReadLine()); // широчина
            double spaceShipLength = double.Parse(Console.ReadLine()); // дължина
            double spaceShipHeight = double.Parse(Console.ReadLine()); // височина
            double averageAustronaftHeight = double.Parse(Console.ReadLine()); // средна височина на астронафтите

            double rocketSize = spaceShipWidth * spaceShipLength * spaceShipHeight;
            double roomSize = (averageAustronaftHeight + 0.40) * 2 * 2;
            double numberAustronaftSpace = Math.Floor(rocketSize / roomSize);

            if (numberAustronaftSpace >= 3 && numberAustronaftSpace <= 10)
            {
                Console.WriteLine($"The spacecraft holds {numberAustronaftSpace} astronauts.");
            }
            else if (numberAustronaftSpace < 3)
            {
                Console.WriteLine("The spacecraft is too small.");            }
            else if (numberAustronaftSpace > 10)
            {
                Console.WriteLine("The spacecraft is too big.");            }
        }
    }
}
