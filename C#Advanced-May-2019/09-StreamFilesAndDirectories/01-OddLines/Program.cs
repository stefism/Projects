using System;
using System.IO;

namespace _01_OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("input.txt"))
            {
                int count = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (count % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    count++;

                    line = reader.ReadLine();
                }
            }
        }
    }
}
