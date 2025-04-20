// Services/BookService.svc.cs
using BookServiceApplication.Models;
using System.Collections.Generic;

namespace BookServiceApplication.Services
{
    public class BookService : IBookService
    {
        // In a real application, you'd use a database
        // For now, we'll use a static list as an example
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