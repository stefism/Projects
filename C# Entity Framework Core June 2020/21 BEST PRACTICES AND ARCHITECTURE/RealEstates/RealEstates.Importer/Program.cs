using System;
using System.IO;

namespace RealEstates.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("imot.bg-raw-data-2020-07-23.json");
        }
    }
}
