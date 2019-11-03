using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class LayoutFactory
    {
        public Ilayout GetIlayout(string type)
        {
            Ilayout layout;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new InvalidOperationException();
            }

            return layout;
        }
    }
}
