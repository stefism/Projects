using System;

namespace NameProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstname = Console.ReadLine();
            string lastname = Console.ReadLine();
            string age = Console.ReadLine();
            string town = Console.ReadLine();

            Console.WriteLine($"You are {firstname} {lastname}, a {age}-years old person from {town}.");


            //Console.WriteLine("Моето име е " + name);
            //Console.WriteLine("2 Моето име е {0} {1} {2}", name, NameCats1, NameCats2);

            //Console.WriteLine($"3 Моето име е {name} и харесвам котката {NameCats1} и котката {NameCats2}");
        }
    }
}
