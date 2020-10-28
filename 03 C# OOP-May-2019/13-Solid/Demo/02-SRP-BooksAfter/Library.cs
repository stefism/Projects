using System;
using System.Collections.Generic;
using System.Text;

namespace  _01_SRP_BooksAfter
{
    public class Library
    {
        private List<Book> books;

        public Library(List<Book> books)
        {
            this.books = books;
        }

        public int FindBook(string title)
        {
            return 42;
        }
    }
}
