using BookApplication.Models;
using System.Collections.Generic;

namespace BookApplication.Services
{
    public class BookService : IBookService
    {
        //Uses static list for now (connect with database later)

        private static List<Book> _books = new List<Book>();
        private static int _nextId = 1;

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public void AddBook(Book book)
        {
            // Assign an ID if not provided
            if (book.Id <= 0)
            {
                book.Id = _nextId++;
            }

            _books.Add(book);
        }
    }
}