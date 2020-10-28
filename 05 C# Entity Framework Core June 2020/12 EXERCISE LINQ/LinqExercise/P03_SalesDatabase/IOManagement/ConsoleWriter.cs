using P03_SalesDatabase.IOManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.IOManagement
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
