using System;
using System.IO;

namespace _02_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("input.txt"))
            {
                string line = reader.ReadLine();
                int counter = 1;

                string output = @"E:\SoftUni\C#Advanced-May-2019\09-StreamFilesAndDirectories\02-LineNumbers\output.txt";

                using (var writer = new StreamWriter(output))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
