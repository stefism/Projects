using System;

namespace _11_WhileExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string seekBook = Console.ReadLine();
            int booksInLibrary = int.Parse(Console.ReadLine());
            int counter = 0;

            while (counter <= booksInLibrary)
            {
                counter++;
                string inputBooks = Console.ReadLine();
                
                if (inputBooks == seekBook)
                {
                    Console.WriteLine($"You checked {counter-1} books and found it.");
                    break;
                }

                if (counter == booksInLibrary)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
            }

            
        }
    }
}
