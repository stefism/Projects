using System;

namespace _09_CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection add = new AddCollection();
            AddRemoveCollection addRemove = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split();

            AddToCollection(input, add);
            AddToCollection(input, addRemove);
            AddToCollection(input, myList);

            int numberOfRemove = int.Parse(Console.ReadLine());

            Remove(numberOfRemove, addRemove);
            Remove(numberOfRemove, myList);
        }

        static void AddToCollection(string[] input, IAddable collection)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(collection.Add(input[i]) + " ");
            }

            Console.WriteLine();
        }

        static void Remove(int numberOfRemoves, IAddable collection)
        {
            for (int i = 0; i < numberOfRemoves; i++)
            {
                Console.Write(collection.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}
