// Services/IBookService.cs
using BookServiceApplication.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace BookServiceApplication.Services
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract]
        void AddBook(Book book);
    }
}