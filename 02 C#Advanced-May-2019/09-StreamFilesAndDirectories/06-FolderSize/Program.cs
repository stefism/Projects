using System;
using System.IO;

namespace _06_FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("E:\\SoftUni\\C#Advanced-May-2019\\09-StreamFilesAndDirectories\\06-FolderSize\\TestFolder");

            double sum = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            Console.WriteLine(sum);

            File.WriteAllText("E:\\SoftUni\\C#Advanced-May-2019\\09-StreamFilesAndDirectories\\06-FolderSize\\output.txt", sum.ToString());
        }
    }
}
