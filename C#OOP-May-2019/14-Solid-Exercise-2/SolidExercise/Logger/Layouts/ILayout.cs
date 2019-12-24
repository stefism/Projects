using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Layouts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
