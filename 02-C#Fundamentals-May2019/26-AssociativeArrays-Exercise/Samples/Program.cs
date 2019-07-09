using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var someDict = new Dictionary<char, List<string>>();
            someDict.Add('a', new List<string>() { "Gosho", "Ivan"});
        }
    }
}
