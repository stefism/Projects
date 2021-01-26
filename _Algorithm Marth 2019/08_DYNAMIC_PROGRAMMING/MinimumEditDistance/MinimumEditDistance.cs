using System;

namespace MinimumEditDistance
{
    class MinimumEditDistance
    {
        static void Main(string[] args)
        {
            int costReplace = int.Parse(Console.ReadLine().Split()[2]);
            int costInsert = int.Parse(Console.ReadLine().Split()[2]);
            int costDelete = int.Parse(Console.ReadLine().Split()[2]);
            
            string string1 = Console.ReadLine().Split('=')[1].Trim();
            string string2 = Console.ReadLine().Split('=')[1].Trim();

            int[,] matix = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 1; i <= string2.Length; i++)
            {
                matix[0, i] = matix[0, i - 1] + costInsert;
            }

            for (int i = 1; i <= string1.Length; i++)
            {
                matix[i, 0] = matix[i - 1, 0] + costDelete;
            }

            for (int row = 1; row <= string1.Length; row++)
            {
                for (int col = 1; col <= string2.Length; col++)
                {
                    if (string1[row - 1] == string2[col - 1])
                    {
                        matix[row, col] = matix[row - 1, col - 1];
                    }
                    else
                    {
                        int currDeleteCost = matix[row - 1, col] + costDelete;
                        int currInsertCost = matix[row, col - 1] + costInsert;
                        int currReplaceCost = matix[row - 1, col - 1] + costReplace;

                        int minimalCost = Math.Min(currInsertCost, Math.Min(currDeleteCost, currReplaceCost));

                        matix[row, col] = minimalCost;
                    }
                }
            }

            int minimumEditDistance = matix[string1.Length, string2.Length];

            Console.WriteLine($"Minimum edit distance: {minimumEditDistance}");
        }
    }
}
