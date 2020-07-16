namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.ConstrainedExecution;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

          //string input = Console.ReadLine(); 
            int input = int.Parse(Console.ReadLine());
            //string output = GetBooksByAgeRestriction(db, input);
            //string output = GetGoldenBooks(db);
            //string output = GetBooksByPrice(db);
            //string output = GetBooksNotReleasedIn(db, input);
            //string output = GetBooksReleasedBefore(db, input);
            //string output = GetAuthorNamesEndingIn(db, input);
            //string output = GetBookTitlesContaining(db, input);
            //string output = GetBooksByAuthor(db, input);
            var output = CountBooks(db, input);

            Console.WriteLine(output);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        //10. Count Books
        {

        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        //09. Book Search by Author
        {
            var books = context.Books
                .Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                }).OrderBy(b => b.BookId).ToList();

            StringBuilder sb = new StringBuilder();

            books.ForEach(b => sb.AppendLine($"{b.Title} ({b.Author})"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        //08. Book Search
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new { b.Title })
                .OrderBy(b => b.Title).ToList();

            StringBuilder sb = new StringBuilder();

            books.ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        //07. Author Search
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { FullName = a.FirstName + " " + a.LastName })
                .OrderBy(a => a.FullName).ToList();

            StringBuilder sb = new StringBuilder();

            authors.ForEach(a => sb.AppendLine(a.FullName));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        //06. Released Before Date
        {
            //DateTime inputDate = DateTime.Parse(date);

            DateTime inputDate = DateTime.ParseExact
                (date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < inputDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new { b.Title, b.EditionType, b.Price })
                .ToList();

            StringBuilder sb = new StringBuilder();

            books.ForEach(b => sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        //05. Book Titles by Category
        {
            string[] categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Categories
                .Select(c => new
                {
                    c.Name,
                    BookTitle = c.CategoryBooks
                    .Select(cb => new { cb.Book.Title })
                }).Where(c => categories.Contains(c.Name.ToLower()))
                .ToList();
            
            List<string> booksTitles = new List<string>();

            foreach (var category in books)
            {
                foreach (var book in category.BookTitle)
                {
                    booksTitles.Add(book.Title);
                }               
            }

            return string.Join(Environment.NewLine, booksTitles.OrderBy(x => x));
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

        public static string GetBooksByPrice(BookShopContext context)
        //03. Books by Price
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Price, b.Title }).ToList();

            StringBuilder sb = new StringBuilder();

            books.ForEach(b => sb.AppendLine($"{b.Title} - ${b.Price:F2}"));

            return sb.ToString().TrimEnd();
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

            StringBuilder sb = new StringBuilder();

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
