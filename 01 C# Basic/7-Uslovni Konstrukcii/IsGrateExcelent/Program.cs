using System;

namespace IsGrateExcelent
{
    class Program
    {
        static void Main(string[] args)
        {
            double evaluation = double.Parse(Console.ReadLine());
            double lowestExcellentGradeValue = 5.50;
            bool isGradeExcellent = evaluation >= lowestExcellentGradeValue;

            if (isGradeExcellent)

            {
                Console.WriteLine("Excellent!");
            }

            //Console.WriteLine("End of program");

        }
    }
}
