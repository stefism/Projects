using LoggerProgram.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Factories
{
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            switch (type.ToLower())
            {
                case "simplelayout":
                    return new SimpleLayout();

                case "xmllayout":
                    return new XmlLayout();

                default:
                    throw new ArgumentException("Invalid Layout");
            }
        }
    }
}
