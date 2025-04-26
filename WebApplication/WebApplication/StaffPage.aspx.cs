using System;
using System.Web.UI.WebControls;
using WebApplication.BookServiceReference; // Service reference namespace
//using BookServiceApplication.Models; // Original model namespace

namespace WebApplication
{
    public partial class StaffPage : System.Web.UI.Page
    {
        // Existing global variables remain unchanged
        private BookServiceClient _bookService = new BookServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Existing auth check remains first
            if (Request.Cookies["staffLoggedIn"]?.Value != "true")
                Response.Redirect("LoginPage.aspx");

            // Existing username display
            Label3.Text = Request.Cookies["accountUsername"]?.Value;

            // New book data binding
            if (!IsPostBack)
                BindBooksData();
        }

        private void BindBooksData()
        {
            gvBooks.DataSource = _bookService.GetAllBooks();
            gvBooks.DataBind();
        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            var newBook = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Year = txtYear.Text,
                Genre = txtGenre.Text
            };

            _bookService.AddBook(newBook);
            ClearForm();
            BindBooksData();
        }

        protected void gvBooks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bookId = (int)gvBooks.DataKeys[e.RowIndex].Value;
            _bookService.RemoveBook(bookId);
            BindBooksData();
        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtYear.Text = string.Empty;
            txtGenre.Text = string.Empty;
        }

        // Existing button handlers remain unchanged
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Original button logic preserved
        }
    }
}