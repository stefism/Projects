using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badScore = int.Parse(Console.ReadLine());
            int counterBadScore = 0;
            int counterTask = 0;
            double sumAverage = 0;
            string lastTask = "";

            while (true)
            {
                string task = Console.ReadLine();

                if (task == "Enough")
                {
                    Console.WriteLine($"Average score: {(sumAverage / (counterTask)):F2}");
                    Console.WriteLine($"Number of problems: {counterTask}");
                    Console.WriteLine($"Last problem: {lastTask}");
                    break;
                }

                double average = double.Parse(Console.ReadLine());

                if (task != "Enough")
                {
                    lastTask = task;
                }

                counterTask++;

                if (average <= 4)
                {
                    counterBadScore++;
                }

                if (counterBadScore == badScore)
                {
                    Console.WriteLine($"You need a break, {badScore} poor grades.");
                    break;
                }
                sumAverage = sumAverage + average;

                // Тука долната проверка не работи правилно! Трябва да е горе на ред 19.
                //if (task == "Enough")
                //{
                //    Console.WriteLine($"Average score: {(sumAverage / (counterTask)):F2}");
                //    Console.WriteLine($"Number of problems: {counterTask}");
                //    Console.WriteLine($"Last problem: {lastTask}");
                //    break;
                //}
                // counterTask++;
            }

        }
    }
}
