using BookServiceApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookServiceApplication.Services
{
    public class BookService : IBookService
    {
        //Static List for now (update to database)
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
        public void RemoveBook(int id)
        {
            var bookToRemove = _books.Find(b => b.Id == id);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }
        }
    }
}