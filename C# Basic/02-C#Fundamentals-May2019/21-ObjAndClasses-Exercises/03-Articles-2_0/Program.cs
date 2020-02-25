using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Articles_2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Articles> articles = new List<Articles>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                List<string> currentArticle = Console.ReadLine().Split(", ").ToList();

                Articles article = new Articles(currentArticle[0], currentArticle[1], currentArticle[2]);

                articles.Add(article);
            }

            string orderBy = Console.ReadLine();

            switch (orderBy)
            {
                case "title":
                    articles = articles.OrderBy(a => a.Title).ToList();
                    break;

                case "content":
                    articles = articles.OrderBy(a => a.Content).ToList();
                    break;

                case "author":
                    articles = articles.OrderBy(a => a.Author).ToList();
                    break;
            }

            articles.ForEach(a => Console.WriteLine(a));
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

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
