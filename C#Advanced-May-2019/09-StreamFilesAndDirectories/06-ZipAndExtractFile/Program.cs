using System;
using System.IO;
using System.IO.Compression;

namespace _06_ZipAndExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipFilePath = @"E:\SoftUni\C#Advanced-May-2019\09-StreamFilesAndDirectories\06-ZipAndExtractFile\ZipFolder\myZip.zip";
            string file = "copyMe.png";

            using (var archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }
    }
}
