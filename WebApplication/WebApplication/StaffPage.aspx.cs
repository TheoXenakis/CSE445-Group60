using System;
using System.Web.UI;
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
            // Fixed validation logic (use AND instead of OR)
            if (!string.IsNullOrEmpty(txtTitle.Text) &&
                !string.IsNullOrEmpty(txtAuthor.Text) &&
                !string.IsNullOrEmpty(txtYear.Text) &&
                !string.IsNullOrEmpty(txtGenre.Text) &&
                !string.IsNullOrEmpty(txtPrice.Text))
            {
                var newBook = new Book
                {
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Year = txtYear.Text,
                    Genre = txtGenre.Text,
                    Price = txtPrice.Text
                };

                _bookService.AddBook(newBook);
                ClearForm();
                BindBooksData();
                ShowNotification("Book added successfully!", isError: false);
            }
            else
            {
                ShowNotification("All fields are required!", isError: true);
            }
        }

        //Method for displaying Success or Error Notificaiton
        private void ShowNotification(string message, bool isError)
        {
            lblNotification.Text = message;
            lblNotification.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            lblNotification.Visible = true;

            //Hide after 3 seconds
            ScriptManager.RegisterStartupScript(this, GetType(), "hideNotification",
                "setTimeout(function(){ document.getElementById('" + lblNotification.ClientID + "').style.display = 'none'; }, 3000);",
                true);
        }

        //Handle Deleting Books
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
            txtPrice.Text = string.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Original button logic preserved
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }

    }
}