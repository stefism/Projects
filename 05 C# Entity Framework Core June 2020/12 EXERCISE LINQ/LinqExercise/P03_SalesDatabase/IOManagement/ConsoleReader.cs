using P03_SalesDatabase.IOManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.IOManagement
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
