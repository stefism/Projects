using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string[] beerInfo = Console.ReadLine().Split();
            string[] numbersInfo = Console.ReadLine().Split();

            string personName = personInfo[0] + " " + personInfo[1];
            string personAddress = personInfo[2];
            string personTown = personInfo[3];

            string beerModel = beerInfo[0];
            int beerLiter = int.Parse(beerInfo[1]);
            string drunkOrNot = beerInfo[2];

            bool isDrunk = false;

            if (drunkOrNot == "drunk")
            {
                isDrunk = true;
            }

            string firstNumber = numbersInfo[0];
            double bankBalance = double.Parse(numbersInfo[1]);
            string bankName = numbersInfo[2];

            var personTuple = new Tuple<string, string, string>(personName, personAddress, personTown);
            var beerTuple = new Tuple<string, int, bool>(beerModel, beerLiter, isDrunk);
            var numbersTuple = new Tuple<string, double, string>(firstNumber, bankBalance, bankName);

            Console.WriteLine(personTuple.GetInfo());
            Console.WriteLine(beerTuple.GetInfo());
            Console.WriteLine(numbersTuple.GetInfo());
        }
    }
}
