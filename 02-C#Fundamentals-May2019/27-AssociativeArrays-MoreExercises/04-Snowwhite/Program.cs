using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" <:> ");

                string name = input[0];

                if (name == "Once upon a time")
                {

                    break;
                }

                string hatColor = "(" + input[1] + ")";
                int physics = int.Parse(input[2]);

                if (dwarfs.ContainsKey(string.sta))
                {

                }
            }
        }
    }
}
