using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split().ToList();
            string conditions = Console.ReadLine();

            lessons.GroupBy(a => a.StartsWith(conditions));
            
            lessons.Insert(3, "Proba");

        }
    }
}
