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

            string beerModel = beerInfo[0];
            int beerLiter = int.Parse(beerInfo[1]);

            int firstNumber = int.Parse(numbersInfo[0]);
            double secondNumber = double.Parse(numbersInfo[1]);

            var personTuple = new Tuple<string, string>(personName, personAddress);
            var beerTuple = new Tuple<string, int>(beerModel, beerLiter);
            var numbersTuple = new Tuple<int, double>(firstNumber, secondNumber);

            Console.WriteLine(personTuple.GetInfo());
            Console.WriteLine(beerTuple.GetInfo());
            Console.WriteLine(numbersTuple.GetInfo());
        }
    }
}
