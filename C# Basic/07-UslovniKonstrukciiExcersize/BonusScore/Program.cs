using System;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            double bonusNumber = double.Parse(Console.ReadLine());
            double bonusPoints = 0;

            if (bonusNumber <= 100)
            {
                bonusPoints = 5;
            }

            else if (bonusNumber > 1000) // if е било

            {
                bonusPoints = bonusNumber * 0.1;
            }
            
            else if (bonusNumber > 100)
            {
                bonusPoints = bonusNumber * 0.2;
            }
            

            if (bonusNumber % 2 == 0) 
            {
                bonusPoints = bonusPoints + 1;
            }

            else if (bonusNumber % 10 == 5) //if е било
            {
                bonusPoints = bonusPoints + 2;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(bonusNumber + bonusPoints);


        }
    }
}
