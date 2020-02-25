using System;

namespace _03_ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            int lastIndex = inputString.LastIndexOf("\\");

            string fileName = inputString.Substring(lastIndex+1);

            string[] fileNameAndExtension = fileName.Split(".");

            string finalFileName = fileNameAndExtension[0];
            string fileExtension = fileNameAndExtension[1];

            Console.WriteLine($"File name: {finalFileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
