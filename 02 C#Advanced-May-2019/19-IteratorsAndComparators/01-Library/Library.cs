using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> booksList;

        public Library(params Book[] books)
        {
            booksList = new List<Book>(books);
            booksList.Sort();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(booksList);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose() { }
            public bool MoveNext() => ++currentIndex < books.Count;
            public void Reset() => currentIndex = -1;
            public Book Current => books[currentIndex];
            object IEnumerator.Current => Current;
        }
    }
}
