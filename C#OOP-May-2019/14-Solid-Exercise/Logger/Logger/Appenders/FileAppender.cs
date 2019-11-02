using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class FileAppender : IAppender
    {
        private int messagesAppended;

        public FileAppender(Ilayout layout, Level level, IFile file)
        {
            Layout = layout;
            Level = level;
            File = file;
        }

        public Ilayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            string formattedMessage = File.Write(Layout, error);

            System.IO.File.AppendAllText(File.Path, formattedMessage);
            messagesAppended++;
        }
    }
}
