using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class IOManager : IIOManager
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        private IOManager()
        {
            currentPath = GetCurrentPath();
        }

        public IOManager(string currentDirectory, string currentFile) 
            : this ()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }

        public string CurrentDirectoryPath => 
            currentPath + currentDirectory;

        public string CurrentFilePath => 
            CurrentDirectoryPath + currentFile;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(CurrentDirectoryPath))
            {
                Directory.CreateDirectory(CurrentDirectoryPath);
            }

            File.WriteAllText(CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
