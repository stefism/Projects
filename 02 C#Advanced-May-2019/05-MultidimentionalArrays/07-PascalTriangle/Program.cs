using System;
using System.Linq;

namespace _07_PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int triangleRow = int.Parse(Console.ReadLine());

            long[][] triangle = new long[triangleRow][];

            triangle[0] = new long[] { 1 };

            if (triangleRow == 1)
            {
                Console.WriteLine(1);
                return;
            }

            else if (triangleRow == 2)
            {
                Console.WriteLine("1 1");
                return;
            }

            else if (triangleRow == 3)
            {
                Console.WriteLine("1 2 1");
                return;
            }


            triangle[1] = new long[] { 1, 1 };
            triangle[2] = new long[] { 1, 2, 1 };

            for (int i = 3; i < triangle.Length; i++)
            {
                triangle[i] = new long[i+1];

                triangle[i][0] = 1;
                triangle[i][triangle[i].Length - 1] = 1;

                for (int j = 0; j < triangle[i-1].Length-1; j++)
                {
                    triangle[i][j + 1] = triangle[i - 1][j] + triangle[i - 1][j + 1];
                }
            }

            for (int i = 0; i < triangle.Length; i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }
    }
}
