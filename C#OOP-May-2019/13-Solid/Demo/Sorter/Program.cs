using System;

namespace Sorter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            Sorter<int> sorter = new Sorter<int>(type);
        }
    }
}
