using System;
using System.IO;

namespace _04_MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file1 = File.ReadAllLines("FileOne.txt");
            string[] file2 = File.ReadAllLines("FileTwo.txt");

            string outputFile = string.Empty;

            for (int i = 0; i < file1.Length; i++)
            {
                outputFile += file1[i] + "\n";
                outputFile += file2[i] + "\n";
            }

            File.WriteAllText("E:\\SoftUni\\C#Advanced-May-2019\\09-StreamFilesAndDirectories\\04-MergeFiles\\output.txt", outputFile);
        }
    }
}
