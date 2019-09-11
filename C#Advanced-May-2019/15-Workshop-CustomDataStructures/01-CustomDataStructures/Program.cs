﻿using System;

namespace CustomClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.AddFirst(1);
            doublyLinkedList.AddFirst(2);
            doublyLinkedList.AddFirst(3);

            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddLast(5);
            doublyLinkedList.AddLast(6);

            doublyLinkedList.Print(Console.WriteLine);

            Console.WriteLine(doublyLinkedList.Count);
        }
    }
}
