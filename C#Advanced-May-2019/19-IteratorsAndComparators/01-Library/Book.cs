using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }
        public int Year { get; private set; }
        public List<string> Authors { get; private set; }

        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public int CompareTo(Book other)
        {
            int result = Year.CompareTo(other.Year);

            if (result == 0)
            {
                result = Title.CompareTo(other.Title);
            }

            return result;
            
            // С долното дава 90 от 100! Гърми на последния тест.

            //if (Year != other.Year)
            //{
            //    return Year - other.Year;
            //}

            //if (Title != other.Title)
            //{
            //    return Title.CompareTo(other.Title);
            //}

            //return 0;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
