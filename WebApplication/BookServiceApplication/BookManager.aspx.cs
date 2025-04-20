using BookServiceApplication.Models;
using BookServiceApplication.Services;
using System;

//Author: Theo Xenakis

namespace BookServiceApplication
{
    public partial class BookManager : System.Web.UI.Page
    {
        //Service Reference
        private BookService _bookService = new BookService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Load books when page is first loaded
                BindBooksData();
            }
        }

        protected void ButtonAddBook_Click(object sender, EventArgs e)
        {
            //Create a new book from form data
            Book newBook = new Book
            {
                Title = TextBoxTitle.Text,
                Author = TextBoxAuthor.Text
            };

            //Add book via service
            _bookService.AddBook(newBook);

            //Clear entries
            TextBoxTitle.Text = string.Empty;
            TextBoxAuthor.Text = string.Empty;

            //Refresh
            BindBooksData();
        }

        private void BindBooksData()
        {
            //Get books from service and bind to GridView
            GridViewBooks.DataSource = _bookService.GetAllBooks();
            GridViewBooks.DataBind();
        }
    }
}