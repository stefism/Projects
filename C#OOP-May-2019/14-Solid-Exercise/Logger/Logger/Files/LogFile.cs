﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger
{
    public class LogFile : IFile
    {
        private const string dateFormat = "M/dd/yyyy H:mm:ss tt";

        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt";

        private string currentPath;
        private IIOManager IOManager;

        public LogFile()
        {
            IOManager = new IOManager(currentDirectory, currentFile);
            currentPath = IOManager.CurrentFilePath;
            IOManager.EnsureDirectoryAndFileExist();
        }

        public string Path => currentPath;

        public ulong Size => GetFileSize();

        public string Write(Ilayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = 
                string.Format(format, dateTime
                .ToString(dateFormat, 
                CultureInfo.InvariantCulture), 
                level.ToString(), message);

            return formattedMessage;
        }

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(Path);

            ulong size = (ulong)text.ToCharArray()
                .Where(x => Char.IsLetter(x))
                .Sum(x => x);

            return size;
        }
    }
}
