using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
           var grades = new Dictionary<string, List<int>>();
            grades.Add("Niki", new List<int>());
            grades["Niki"].Add(5);
            grades["Niki"].Add(5);
            grades["Niki"].Add(6);
            grades["Niki"].Add(5);

            grades.Add("Pepi", new List<int>());
            grades["Pepi"].Add(4);
            grades["Pepi"].Add(4);

            Console.WriteLine(grades["Niki"].Average());
        }
    }
}
