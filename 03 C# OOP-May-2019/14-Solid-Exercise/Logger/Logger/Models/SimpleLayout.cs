using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class SimpleLayout : Ilayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
