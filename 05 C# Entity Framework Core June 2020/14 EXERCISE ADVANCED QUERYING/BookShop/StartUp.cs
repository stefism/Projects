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
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine(); 
            //int input = int.Parse(Console.ReadLine());
            //string output = GetBooksByAgeRestriction(db, input);
            //string output = GetGoldenBooks(db);
            //string output = GetBooksByPrice(db);
            //string output = GetBooksNotReleasedIn(db, input);
            //string output = GetBooksReleasedBefore(db, input);
            //string output = GetAuthorNamesEndingIn(db, input);
            //string output = GetBookTitlesContaining(db, input);
            //string output = GetBooksByAuthor(db, input);
            //var output = CountBooks(db, input);
            //string output = CountCopiesByAuthor(db);
            //string output = GetTotalProfitByCategory(db);
            //string output = GetMostRecentBooks(db);
            var removedBooks = RemoveBooks(db);

            //Console.WriteLine(output);
        }

        public static int RemoveBooks(BookShopContext context)
        //15. Remove Books
        {
            var BookInMap = context.BooksCategories
                .Where(bc => bc.Book.Copies < 4200)
                .ToList();

            foreach (var book in BookInMap)
            {
                context.Remove(book);
            }

            var books = context.Books
                .Where(b => b.Copies < 4200).ToList();

            context.SaveChanges();

            int booksCount = books.Count();

            foreach (var book in books)
            {
                context.Remove(book);
            }

            context.SaveChanges();

            return booksCount;
        }

        public static void IncreasePrices(BookShopContext context)
        //14. Increase Prices
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            books.ForEach(b => b.Price = b.Price + 5);

            context.SaveChanges();
        }

        public static void IncreasePrices_no(BookShopContext context)
        //14. Increase Prices
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .Update(b => new Book { Price = b.Price + 5 });

            context.SaveChanges();          
        }

        public static string GetMostRecentBooks(BookShopContext context)
        //13. Most Recent Books
        {
            var output = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate
                    }).OrderByDescending(cb => cb.ReleaseDate).Take(3)
                }).OrderBy(c => c.Name).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in output)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    BooksSum = c.CategoryBooks
                    .Select(b => new
                    {
                        CurrentSum = b.Book.Price * b.Book.Copies
                    }).Sum(bs => bs.CurrentSum)
                }).OrderByDescending(b => b.BooksSum).ThenBy(b => b.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            totalProfit.ForEach(x => sb.AppendLine($"{x.Name} ${x.BooksSum:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory33ot100(BookShopContext context)
        //12. Profit by Category
        {
            var totalProfit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .Select(b => new
                    {
                        b.Book.Price,
                        b.Book.Copies
                    })
                }).ToList();

            Dictionary<string, decimal> books = new Dictionary<string, decimal>();

            foreach (var book in totalProfit)
            {
                string name = book.Name;
                decimal total = 0;

                foreach (var item in book.Books)
                {
                    decimal sum = item.Price * item.Copies;
                    total += sum;
                }

                books.Add(name, total);
            }

            books = books
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            StringBuilder sb = new StringBuilder();

            foreach (var item in books)
            {
                sb.AppendLine($"{item.Key} ${item.Value:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        //11. Total Book Copies
        {
            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    BooksCopies = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.BooksCopies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            authors.ForEach(a => sb.AppendLine($"{a.FirstName} {a.LastName} - {a.BooksCopies}"));

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        //10. Count Books
        {
            int booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title).Count();

            return booksCount;
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
                .Select(b => b.Title)
                .OrderBy(bt => bt)
                .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }
    }
}
