using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ChronometerAsync
{
    class Engine
    {
        Stopwatch Stopwatch = new Stopwatch();
        List<string> Laps = new List<string>();
        string Time = string.Empty;
        
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                GetUserCommand(command);
            }
        }

        private  void GetUserCommand(string command)
        {
            switch (command)
            {
                case "start":
                    StartAsync();
                    break;

                case "stop":
                    StopAsync();
                    break;

                case "lap":
                    LapAsync();
                    break;

                case "laps":
                    LapsAsync();
                    break;

                case "time":
                    TimeAsync();
                    break;

                case "reset":
                    ResetAsync();
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;
            }
        }

        private async Task ResetAsync()
        {
            Laps = new List<string>();
            Time = string.Empty;
            Stopwatch.Reset();
        }

        private async Task TimeAsync()
        {
            Console.WriteLine(Time);
        }

        private async Task StopAsync()
        {
            Time = Stopwatch.Elapsed.ToString();
        }

        private async Task StartAsync()
        {
            Stopwatch.Start();
        }

        private async Task LapAsync()
        {
            var lap = Stopwatch.Elapsed.ToString();
            Console.WriteLine(lap);
            Laps.Add(lap);
        }

        private async Task LapsAsync()
        {
            int counter = 0;

            Console.WriteLine("Laps:");

            foreach (var lap in Laps)
            {
                Console.WriteLine($"{counter++}. {lap}");
            }
        }
    }   
}
