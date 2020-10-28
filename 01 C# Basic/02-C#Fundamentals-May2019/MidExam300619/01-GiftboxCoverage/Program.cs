using System;

namespace _01_GiftboxCoverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sizeOfSideOfTheBox = double.Parse(Console.ReadLine());
            int numberOfSheetsOfPaper = int.Parse(Console.ReadLine());
            double areaOfSingleSheetPaper = double.Parse(Console.ReadLine());

            double totalSizeOfBox = sizeOfSideOfTheBox * sizeOfSideOfTheBox * 6;

            

            int lowSheet = numberOfSheetsOfPaper / 3;
            int fullSheet = numberOfSheetsOfPaper - lowSheet;

            double lowCovered = areaOfSingleSheetPaper * 0.25;

            double totalLowCovered = lowSheet * lowCovered;
            double otherCovered = fullSheet * areaOfSingleSheetPaper;

            double totalAreaCovered = totalLowCovered + otherCovered;

            //for (int i = 0; i < numberOfSheetsOfPaper; i++)
            //{
            //    if (i % 3 == 0)
            //    {
            //        double coveredArea = areaOfSingleSheetPaper * 0.25;
            //        totalAreaCovered += coveredArea;
            //    }
            //    else
            //    {
            //        totalAreaCovered += areaOfSingleSheetPaper;
            //    }
            //}

            double totalPercentCovered = (totalAreaCovered / totalSizeOfBox) * 100;

            Console.WriteLine($"You can cover {totalPercentCovered:F2}% of the box.");
        }
    }
}
