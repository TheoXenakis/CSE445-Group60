using BookApplication.Models;
using BookApplication.Services;
using System;

//Theo Xenakis

namespace BookApplication
{
    public partial class BookManager : System.Web.UI.Page
    {

        //Added to stop issues do not remove them idk why it needs these but it does
        protected global::System.Web.UI.WebControls.TextBox TextBoxTitle;
        protected global::System.Web.UI.WebControls.TextBox TextBoxAuthor;
        protected global::System.Web.UI.WebControls.GridView GridViewBooks;
        protected global::System.Web.UI.WebControls.Button ButtonAddBook;

        //Service reference
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

            //Add the book using service
            _bookService.AddBook(newBook);

            //Clear the form
            TextBoxTitle.Text = string.Empty;
            TextBoxAuthor.Text = string.Empty;

            //Refresh the grid
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