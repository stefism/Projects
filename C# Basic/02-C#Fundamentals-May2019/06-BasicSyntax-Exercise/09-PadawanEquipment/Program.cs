using System;

namespace _09_PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double studentsPlusTenPercent = Math.Ceiling(numberOfStudents * 1.10);
            int freeBelts = numberOfStudents / 6;
            int totalBelts = numberOfStudents - freeBelts;

            double moneyLeft = (lightsabersPrice * studentsPlusTenPercent) + (robesPrice * numberOfStudents)
                + (totalBelts * beltsPrice);

            if (money >= moneyLeft)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyLeft:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(moneyLeft-money):F2}lv more.");
            }
        }
    }
}
