using System;
using System.Linq;

namespace _02CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string elements1 = Console.ReadLine();
            string elements2 = Console.ReadLine();

            string[] array1 = elements1.Split().ToArray();
            string[] array2 = elements2.Split().ToArray();

            for (int a2 = 0; a2 < array2.Length; a2++)
            {
                for (int a1 = 0; a1 < array1.Length; a1++)
                {
                    if (array2[a2] == array1[a1])
                    {
                        Console.Write($"{array2[a2]} ");
                    }
                }
            }
        }
    }
}
