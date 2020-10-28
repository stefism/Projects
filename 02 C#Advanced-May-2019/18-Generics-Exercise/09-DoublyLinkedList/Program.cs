using System;

namespace _09_DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<double> list = new DoublyLinkedList<double>();

            list.AddFirst(2.05);
            list.AddFirst(4.05);
            list.AddFirst(6.15);
            list.AddFirst(8.55);
            list.AddFirst(12.43);

            Console.WriteLine(list.Contains(2.04));

        }
    }
}
