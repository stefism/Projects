using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int numberOfCommands = int.Parse(Console.ReadLine());

            Article article = new Article();

            article.Title = input[0];
            article.Content = input[1];
            article.Author = input[2];

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                if (command[0] == "Edit")
                {
                    article.Edit(command[1]);
                }

                else if (command[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }

                else if (command[0] == "Rename")
                {
                    article.Rename(command[1]);
                }
            }

            Console.WriteLine(article.ToString());
        }
    }

    class Article
    {
        public string Title;
        public string Content;
        public string Author;

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
