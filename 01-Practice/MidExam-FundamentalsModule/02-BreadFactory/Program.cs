using System;
using System.Linq;

namespace _02_BreadFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // (Demo) Technology Fundamentals Mid Exam - 02 March 2019

            string[] inputCases = Console.ReadLine().Split("|");

            int energy = 100;
            int coins = 100;

            for (int i = 0; i < inputCases.Length; i++)
            {
                string[] currentCase = inputCases[i].Split("-");

                string command = currentCase[0];
                int value = int.Parse(currentCase[1]);

                switch (command)
                {
                    case "rest":
                        if (energy + value > 100)
                        {
                            int receivedEnergy = 100 - energy;
                            energy = 100;
                            Console.WriteLine($"You gained {receivedEnergy} energy.");
                            Console.WriteLine($"Current energy: {energy}.");
                        }
                        else
                        {
                            energy += value;
                            Console.WriteLine($"You gained {value} energy.");
                            Console.WriteLine($"Current energy: {energy}.");
                        }
                        break;

                        //Енергията ти става -30, само ако имаш такава! 
                        //Ако ти е по-малко от нула, не намаляваш с - 30.
                        // Затова долу става +80, а не + 50 както беше.
                        //+50 от текущата енергия.

                    case "order":
                        energy -= 30;

                        if (energy < 0)
                        {
                            energy += 80; // беше energy += 50; 
                            Console.WriteLine("You had to rest!");
                        }

             /*
                           Дословен превод ...
            If you are not bankrupt (coins <= 0)you've bought the ingredient successfully, and you should print
            Ако не си банкрутирал (пари <=0 ) ти си купуваш подправката успешно, и трябва да отпечаташ ...
            В случая действително ти е дадено условието което се счита за банкрут -> когато парите са <=0
            След 2 корекции по кода вече дава 100/100. Първата е за условието за банкрут coins > value, 
            а втората за възстановяването на енергията с 80 (50+30) Отнемаш още в началото 30 без 
            да е изпълнил поръчката, които трябва да се върнат обратно.
            https://pastebin.com/HCyDPxzE
            */

                        else
                        {
                            coins += value;
                            Console.WriteLine($"You earned {value} coins.");
                        }
                        break;

                    default:
                        if (coins > value) // Тука беше coins >= value
                        {
                            Console.WriteLine($"You bought {command}.");
                            coins -= value;
                        }
                        else
                        {
                            Console.WriteLine($"Closed! Cannot afford {command}.");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {energy}");
        }
    }
}
