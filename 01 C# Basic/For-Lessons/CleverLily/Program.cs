using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageLili = int.Parse(Console.ReadLine());
            double washCost = double.Parse(Console.ReadLine());
            double toyCost = double.Parse(Console.ReadLine());
            double totalSum = 0;
            double moneySum = 10;

            double toySum = 0;
            double savedMoney = 0;

            if (ageLili % 2 == 0)
            {
                toySum = (ageLili / 2) * toyCost;
                
            }
            else
            {
                toySum = ((ageLili / 2) * toyCost) + toyCost;
            }

            for (int i = 0; i < ageLili / 2; i++)
            {
                savedMoney = savedMoney + moneySum;
                moneySum = moneySum + 10;
            }

            savedMoney = savedMoney - (ageLili / 2);
            totalSum = toySum + savedMoney;

            if (totalSum >= washCost)
            {
                Console.WriteLine($"Yes! {(totalSum - washCost):F2}");
            }
            else
            {
                Console.WriteLine($"No! {(washCost - totalSum):F2}");
            }
        }
    }
}
