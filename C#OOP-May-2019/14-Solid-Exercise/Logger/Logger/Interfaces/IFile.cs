using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public interface IFile
    {
        string Path { get; }

        ulong Size { get; }

        string Write(Ilayout layout, IError error);
    }
}
