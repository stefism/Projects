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

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //string restrition = Console.ReadLine().ToLower();

                //string result = GetBooksByAgeRestriction(db, restrition);

                //string result = GetGoldenBooks(db);

                int year = int.Parse(Console.ReadLine());

                //string result = GetBooksByPrice(db);

                string result = GetBooksNotReleasedIn(db, year);

                Console.WriteLine(result);
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input) // 05
        {
            List<string> categories = input.Split().ToList();

            var result = context.Categories
                .Where(C => C.Name.Split.co);
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
