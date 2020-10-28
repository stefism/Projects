using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            box.Add(3);
            box.Add(4);
            box.Add(2);
            Console.WriteLine(box.Count);
            Console.WriteLine(box.Remove());
        }
    }
}
