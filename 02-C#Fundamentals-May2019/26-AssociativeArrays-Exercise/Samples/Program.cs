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
            someDict.Add('a', new List<string>() { "Gosho"});
            someDict.Add('b', new List<string>() { "Dimitar", "Petar"});
            someDict.Add('c', new List<string>() { "Ivan"});
            someDict.Add('d', new List<string>() { "Dragan" });

            List<string> names = someDict['c'];

            //string element = names[5];

            someDict = someDict.Where(x => x.Value.Count > 1)
                .OrderBy(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine(string.Join(Environment.NewLine, someDict
                .Select(x => $"{x.Key}: - {string.Join(", ", x.Value)}")));
        }
    }
}
