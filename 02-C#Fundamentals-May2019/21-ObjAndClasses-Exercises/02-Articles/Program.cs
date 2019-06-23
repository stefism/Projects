using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> article = Console.ReadLine().Split(", ").ToList();
            int numberOfEdits = int.Parse(Console.ReadLine());

            Articles articles = new Articles();

            articles.Title = article[0];
            articles.Content = article[1];
            articles.Author = article[2];

            for (int i = 0; i < numberOfEdits; i++)
            {
                List<string> command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string currentCommand = command[0];

                switch (currentCommand)
                {
                    case "Edit":
                        articles.Content = Articles.ChangeContent(command[1]);
                        break;

                    case "ChangeAuthor":
                        articles.Author = Articles.ChangeAuthor(command[1]);
                        break;

                    case "Rename":
                        articles.Title = Articles.RenameArticle(command[1]);
                        break;
                }
            }

            Console.WriteLine($"{articles.Title} - {articles.Content}: {articles.Author}");
        }
    }
    class Articles
    {
        public string Title;
        public string Content;
        public string Author;

        public static string ChangeContent(string newContent)
        {
            string content = newContent;
            return content;
        }
        public static string ChangeAuthor(string newAuthor)
        {
            string author = newAuthor;
            return author;
        }
        public static string RenameArticle(string article)
        {
            string newArticle = article;
            return newArticle;
        }
    }
}
