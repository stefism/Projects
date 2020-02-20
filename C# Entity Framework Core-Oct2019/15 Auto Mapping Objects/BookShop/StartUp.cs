namespace BookShop
{
    using Data;
    using System;
    using Initializer;
    using System.Linq;
    using BookShop.Models;
    using BookShop.Models.Enums;
    using System.Text;
    using System.Collections.Generic;
    using System.Globalization;
    using BookShop.Data.ViewModels;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Author, opt =>
                opt.MapFrom(src => 
                $"{src.Author.FirstName} {src.Author.LastName}"));
            });

            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                var book = db.Books.First();

                var bookDto = Mapper.Map<BookDTO>(book);
            }
        }

        public static int RemoveBooks(BookShopContext context) // 15
        {
            var booksWithLessThan4200Copies = context.Books
                .Where(b => b.Copies < 4200).ToList();

            int removedBooks = booksWithLessThan4200Copies.Count();

            context.RemoveRange(booksWithLessThan4200Copies);

            context.SaveChanges();

            return removedBooks;
        }

        public static void IncreasePrices(BookShopContext context) // 14
        {
            var bookBefore2010 = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in bookBefore2010)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context) // 13
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new { c.Name })
                .OrderBy(c => c.Name).ToList();

            foreach (var category in categories)
            {
                var books = context.BooksCategories
                    .Where(bc => bc.Category.Name == category.Name)
                    .OrderByDescending(bc => bc.Book.ReleaseDate.Value)
                    .Select(bc => new
                    {
                        BookTitle = bc.Book.Title,
                        BookYear = bc.Book.ReleaseDate.Value.Year
                    })
                    .Take(3).ToList();

                sb.AppendLine($"--{category.Name}");

                foreach (var book in books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context) // 12
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new { c.Name })
                .ToList();

            var categoriesProfit = new Dictionary<string, decimal>();

            foreach (var category in categories)
            {
                var books = context.BooksCategories
                    .Where(bc => bc.Category.Name == category.Name)
                    .Select(bc => new
                    {
                        BookCopies = bc.Book.Copies,
                        BookPrice = bc.Book.Price
                    }).ToList();

                decimal totalSum = 0;

                foreach (var book in books)
                {
                    totalSum += book.BookCopies * book.BookPrice;
                }

                categoriesProfit.Add(category.Name, totalSum);
            }

            categoriesProfit = categoriesProfit
                .OrderByDescending(c => c.Value)
                .ThenBy(c => c.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in categoriesProfit)
            {
                sb.AppendLine($"{item.Key} ${item.Value:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string CountCopiesByAuthor(BookShopContext context) // 11
        {
            string authorName = string.Empty;

            var result = context.Authors
                .Select(a => new
                {
                    Author = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(b => b.Copies)
                .ToList(); // Когато имаме SUM явно входа е през колекцията за да можем да сумираме.

            StringBuilder sb = new StringBuilder();

            result.ForEach(b => sb.AppendLine($"{b.Author} - {b.Copies}"));

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck) // 10
        {
            var result = context.Books
                .Select(b => new { b.Title })
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input) // 09
        {
            var result = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    BookName = b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                }).ToList();

            StringBuilder sb = new StringBuilder();

            result.ForEach(b => sb.AppendLine($"{b.BookName} ({b.AuthorName})"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory_DS(BookShopContext context, string input)
        {
            string[] categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower()).ToArray();

            var result = context.Books
                .Where(b => b.BookCategories.Select(bc => new { bc.Category.Name })
                .Any(bc => categories.Contains(bc.Name.ToLower())))
                .Select(b => b.Title).OrderBy(b => b).ToList();

            return string.Join(Environment.NewLine, result);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input) // 08
        {
            var result = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new { b.Title }).OrderBy(b => b.Title).ToList();

            StringBuilder sb = new StringBuilder();

            result.ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input) // 07
        {
            var result = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    Name = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.Name).ToList();

            StringBuilder sb = new StringBuilder();

            result.ForEach(a => sb.AppendLine(a.Name));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date) // 06
        {
            //DateTime inputDate = DateTime.Parse(date);

            DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var result = context.Books
                .Where(b => b.ReleaseDate < inputDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                }).ToList();

            StringBuilder sb = new StringBuilder();

            result.ForEach(b => sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input) // 05
        {
            //List<string> categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


            //string[] categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(c => c.ToLower()).ToArray();

            var result = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => new { BookTitle = bc.Book.Title })
                .OrderBy(bc => bc.BookTitle)
                .ToHashSet();

            StringBuilder sb = new StringBuilder();

            result.ToList().ForEach(b => sb.AppendLine(b.BookTitle));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year) // 04
        {
            var result = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title })
                .ToList();

            StringBuilder sb = new StringBuilder();

            result.ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByPrice(BookShopContext context) // 03
        {
            var result = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .ToList();

            StringBuilder sb = new StringBuilder();

            result.ForEach(b => sb.AppendLine($"{b.Title} - ${b.Price:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context) // 02
        {
            var result = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title }).ToList();

            StringBuilder sb = new StringBuilder();

            result.ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command) // 01
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.AgeRestriction.ToString().ToLower()
                == command.ToLower())
                .Select(b => new { b.Title })
                .OrderBy(b => b.Title).ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction_me(BookShopContext context, string command)
        {
            Enum ageRestrict = AgeRestriction.None;

            if (command == "minor")
            {
                ageRestrict = AgeRestriction.Minor;
            }
            else if (command == "teen")
            {
                ageRestrict = AgeRestriction.Teen;
            }
            else if (command == "adult")
            {
                ageRestrict = AgeRestriction.Adult;
            }

            var result = context.Books.Select(b => new
            {
                b.Title,
                b.AgeRestriction
            })
                .Where(b => b.AgeRestriction.ToString() == ageRestrict.ToString())
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var title in result)
            {
                sb.AppendLine(title.Title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
