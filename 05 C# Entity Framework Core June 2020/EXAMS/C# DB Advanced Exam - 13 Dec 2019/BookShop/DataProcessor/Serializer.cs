namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                    .OrderByDescending(ab => ab.Book.Price) // Евентуално да подредиме тука ако гърми.
                    .Select(ab => new 
                    {
                        BookName = ab.Book.Name,
                        BookPrice = ab.Book.Price.ToString("F2")
                    }) .ToArray()
                    //.OrderByDescending(b => b.BookPrice)
                }).ToArray()
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToArray();

            string json = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Take(10)
                .Select(b => new ExportBookDto
                {
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                    Pages = b.Pages
                }).ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ExportBookDto[]), new XmlRootAttribute("Books"));

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, books, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}