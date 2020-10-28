using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfJudges = int.Parse(Console.ReadLine());
            double averageGrade = 0;

            int sessionCounter = 0;

            double totalGrade = 0;

            while (true)
            {
                string presentationName = Console.ReadLine();

                if (presentationName == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {(totalGrade / sessionCounter):F2}.");
                    break;
                }
                sessionCounter++;
                averageGrade = 0;

                for (int i = 0; i < numberOfJudges; i++)
                {
                    double judgesGrade = double.Parse(Console.ReadLine());
                    averageGrade += judgesGrade;
                }

                Console.WriteLine($"{presentationName} - {(averageGrade / numberOfJudges):F2}.");
                totalGrade += averageGrade / numberOfJudges;
            }
        }
    }
}
