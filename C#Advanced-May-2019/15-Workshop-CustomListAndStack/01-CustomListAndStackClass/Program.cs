using System;

namespace CustomClass
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            for (int i = 1; i < 10; i++)
            {
                list.Add(i);
            }

            list.Swap(2, 4);

            Console.WriteLine(list);
        }
    }
}
