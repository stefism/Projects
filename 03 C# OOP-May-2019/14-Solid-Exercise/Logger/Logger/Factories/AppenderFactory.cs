using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelStr)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelStr, out level);

            if (!hasParsed)
            {
                throw new InvalidOperationException();
            }

            Ilayout layout = layoutFactory.GetIlayout(layoutType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();

                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException();
            }

            return appender;
        }
    }
}
