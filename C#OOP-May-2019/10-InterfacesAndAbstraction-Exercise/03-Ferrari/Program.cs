using System;

namespace _03_Ferrari
{
    public class Program
    {
        static void Main()
        {
            string driverName = Console.ReadLine();

            Icar ferrari = new Ferrari("Ferrari", "488-Spider", driverName);

            Console.WriteLine($"{ferrari.Model}/{ferrari.Brakes()}/{ferrari.Gas()}/{ferrari.DriverName}");
        }
    }
}
