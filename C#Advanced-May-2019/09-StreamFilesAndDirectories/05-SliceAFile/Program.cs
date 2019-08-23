using System;
using System.IO;

namespace _05_SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var inputFile = new FileStream("sliceMe.txt", FileMode.Open))
            {
                long inputFileSize = inputFile.Length;
                int partFileSize = (int)Math.Ceiling((double)inputFileSize / 4);
                byte[] buffer = new byte[partFileSize];

                for (int i = 1; i <= 4; i++)
                {
                    using (var outputFile = new FileStream($"E:\\SoftUni\\C#Advanced-May-2019\\09-StreamFilesAndDirectories\\05-SliceAFile\\Part-{i}.txt", FileMode.Create))
                    { // Тука да тествам с path.combine (join) май беше за чертите и имената на дисковете.
                        int readedBytes = inputFile.Read(buffer, 0, partFileSize);
                        outputFile.Write(buffer, 0, readedBytes);
                    }
                }
            }
        }
    }
}
