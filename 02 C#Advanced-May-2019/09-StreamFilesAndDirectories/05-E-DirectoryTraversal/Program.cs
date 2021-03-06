﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _05_E_DirectoryTraversal
{
    class FilesNameAndSize
    {
        public Dictionary<string, double> FilesDictionary { get; set; }

        public FilesNameAndSize()
        {
            FilesDictionary = new Dictionary<string, double>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //string[] fileArray = Directory.GetFiles(".", "*.*");

            DirectoryInfo directoryInfo = new DirectoryInfo(".");

            FileInfo[] allFiles = directoryInfo.GetFiles();

            var filesNameAndSize = new Dictionary<string, FilesNameAndSize>();

            foreach (var file in allFiles)
            {
                string currentFileName = file.Name;
                string currentFileExtension = file.Extension;
                double currentFileSize = (double)file.Length / 1024;

                if (!filesNameAndSize.ContainsKey(currentFileExtension))
                {
                    filesNameAndSize[currentFileExtension] = new FilesNameAndSize ();
                }

                if (!filesNameAndSize[currentFileExtension].FilesDictionary.ContainsKey(currentFileName))
                {
                    filesNameAndSize[currentFileExtension].FilesDictionary[currentFileName] = currentFileSize;
                }
            }

            filesNameAndSize = filesNameAndSize
                .OrderByDescending(x => x.Value.FilesDictionary.Values.Count())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            string folderPath = @"E:\SoftUni\C#Advanced-May-2019\09-StreamFilesAndDirectories\05-E-DirectoryTraversal\output.txt";

            //string path = Directory.GetParent(Environment.GetFolderPath("05-E-DirectoryTraversal")).FullName;

            foreach (var extension in filesNameAndSize)
            {
                Console.WriteLine(extension.Key);
                File.AppendAllText(folderPath, extension.Key + Environment.NewLine);

                foreach (var file in extension.Value.FilesDictionary.OrderBy(x => x.Value))
                {
                    Console.WriteLine($"--{file.Key} - {file.Value:F3}kb");
                    File.AppendAllText(folderPath, $"--{file.Key} - {file.Value:F3}kb{Environment.NewLine}");
                }
            }
        }
    }
}
