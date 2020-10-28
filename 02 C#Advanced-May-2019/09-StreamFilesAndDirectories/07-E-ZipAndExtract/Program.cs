using System;
using System.IO.Compression;
using System.IO;

namespace _06_E_ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string targetPath = @"E:\SoftUni\C#Advanced-May-2019\09-StreamFilesAndDirectories\07-E-ZipAndExtract\ZipFolder\result.zip";
            string extractFolder = @"E:\SoftUni\C#Advanced-May-2019\09-StreamFilesAndDirectories\07-E-ZipAndExtract\ZipFolder\Extract";

            ZipFile.CreateFromDirectory(".", targetPath);

            ZipFile.ExtractToDirectory(targetPath, extractFolder);
        }
    }
}
