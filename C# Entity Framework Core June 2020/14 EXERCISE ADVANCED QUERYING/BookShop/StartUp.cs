namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.ConstrainedExecution;
    using System.Text;

    public class StartUp
    {
        private static StringBuilder sb = new StringBuilder();

        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            int input = int.Parse(Console.ReadLine());
            //string output = GetBooksByAgeRestriction(db, input);
            //string output = GetGoldenBooks(db);
            string output = GetBooksNotReleasedIn(db, input);

             Console.WriteLine(output);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        //04. Not Released In
        {
            List<string> books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title).ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks100(BookShopContext context)
        //02. Golden Books_100_100
        {
            List<string> books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title).ToList();            

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        //02. Golden Books_50_100
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title }).ToList();

            foreach (var item in books)
            {
                sb.AppendLine(item.Title);
            }            

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        //01. Age Restriction
        {
            //var ageRestriction = Enum.Parse<AgeRestriction>(command, ignoreCase: true);

            List<string> bookTitles = context.Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                //.Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title )
                .OrderBy(bt => bt)
                .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }
    }
}
