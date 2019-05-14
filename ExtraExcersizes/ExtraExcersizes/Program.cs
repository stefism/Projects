using System;

namespace ExtraExcersizes
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine(); //високосна или не
            double hollydays = double.Parse(Console.ReadLine()); //празници, които не са събота и неделя
            double weekendsInOwnTown = double.Parse(Console.ReadLine()); //в които пътува до родния си град

            //Колко пъти играе Влади в София?
            double vladiInSofia = 48 - weekendsInOwnTown;
            double playInSofia = vladiInSofia * 3 / 4;
            double playHollydays = hollydays * 2 / 3;

            if (yearType == "leap")
            {
                playInSofia = playInSofia * 1.15;
                weekendsInOwnTown = weekendsInOwnTown * 1.15;
                playHollydays = playHollydays * 1.15;
            }

            Console.WriteLine(Math.Floor(playInSofia + weekendsInOwnTown + playHollydays));
            
        }
    }
}
