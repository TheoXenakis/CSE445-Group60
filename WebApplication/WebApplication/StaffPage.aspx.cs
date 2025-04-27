using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.BookServiceReference;


namespace WebApplication
{
    public partial class StaffPage : System.Web.UI.Page
    {
        private BookServiceClient _bookService = new BookServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if the user is logged in, redirect to login page if necessary
            if (Request.Cookies["staffLoggedIn"]?.Value != "true")
                Response.Redirect("LoginPage.aspx");

            //Display username
            Label3.Text = Request.Cookies["accountUsername"]?.Value;

            //Book data binding
            if (!IsPostBack)
                BindBooksData();
        }

        //Binds data from all books from the books service to the gridview for display purposes
        private void BindBooksData()
        {
            gvBooks.DataSource = _bookService.GetAllBooks();
            gvBooks.DataBind();
        }

        //Button to add the book to the book list
        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            //Check data fields in the book
            if (!string.IsNullOrEmpty(txtTitle.Text) &&
                !string.IsNullOrEmpty(txtAuthor.Text) &&
                !string.IsNullOrEmpty(txtYear.Text) &&
                !string.IsNullOrEmpty(txtGenre.Text) &&
                !string.IsNullOrEmpty(txtPrice.Text))
            {
                //create new book object with necessary properties
                var newBook = new Book
                {
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Year = txtYear.Text,
                    Genre = txtGenre.Text,
                    Price = txtPrice.Text
                };
                //add the book and handle user feedback
                _bookService.AddBook(newBook);
                ClearForm();
                BindBooksData();
                ShowNotification("Book added successfully!", isError: false);
            }
            else
            {
                ShowNotification("All fields are required!", isError: true); //handle invalid fields
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

        //Helper function to clear the fields of the form
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
            //add if necessary
        }
        //Button to log the user out of their account
        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }

    }
}