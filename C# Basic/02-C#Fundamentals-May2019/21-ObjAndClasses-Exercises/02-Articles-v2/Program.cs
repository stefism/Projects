using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Articles_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> article = Console.ReadLine().Split(", ").ToList();
            int numberOfEdits = int.Parse(Console.ReadLine());

            Articles articles = new Articles(article[0], article[1], article[2]);

            for (int i = 0; i < numberOfEdits; i++)
            {
                List<string> command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string currentCommand = command[0];

                switch (currentCommand)
                {
                    case "Edit":
                        articles.ChangeContent(command[1]);
                        break;

                    case "ChangeAuthor":
                        articles.ChangeAuthor(command[1]);
                        break;

                    case "Rename":
                        articles.RenameTitle(command[1]);
                        break;
                }
            }

            Console.WriteLine(articles);
        }
    }
    class Articles
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Articles(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }
        public void RenameTitle(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
