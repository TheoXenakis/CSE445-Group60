// Services/IBookService.cs
using BookApplication.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace BookApplication.Services
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