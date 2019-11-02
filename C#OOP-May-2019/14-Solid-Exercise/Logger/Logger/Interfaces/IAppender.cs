using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public interface IAppender
    {
        Ilayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}
