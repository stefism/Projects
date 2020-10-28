using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ChronometerAsync
{
    class Program
    {
        Stopwatch Stopwatch = new Stopwatch();
        List<string> Laps = new List<string>();
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();            
        }      
    }
}
