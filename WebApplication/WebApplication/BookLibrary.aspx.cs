using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class BookLibrary : System.Web.UI.Page
    {
        // private BookService _bookService = new BookService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Author", typeof(string));
                dt.Columns.Add("Add to Cart", typeof(string));

                dt.Rows.Add(1, "Sample Book 1", "Author A");
                dt.Rows.Add(2, "Sample Book 2", "Author B");
                dt.Rows.Add(3, "Sample Book 3", "Author C");

                // Bind the data table to the gridview
                GridViewBooks.DataSource = dt;
                GridViewBooks.DataBind();

                //LoadBooks();
            }
        }

        protected void GridViewBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);

                // Add the book to the cart
                AddToCart(bookId);

                Response.Write("<script>alert('Book added to cart!');</script>");
            }
            else if (e.CommandName == "RemoveFromCart")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);

                // Remove the book from the cart
                RemoveFromCart(bookId);

                Response.Write("<script>alert('Book removed from cart!');</script>");
            }
        }

        private void AddToCart(int bookId)
        {
            List<int> cart = Session["ShoppingCart"] as List<int> ?? new List<int>();
            cart.Add(bookId);
            Session["ShoppingCart"] = cart;
        }

        private void RemoveFromCart(int bookId)
        {
            // Get the cart from session
            List<int> cart = Session["ShoppingCart"] as List<int>;

            // If the cart exists and contains book, remove
            if (cart != null)
            {
                cart.Remove(bookId);
                Session["ShoppingCart"] = cart;
            }
        }

        private void LoadBooks()
        {
            //var books = _bookService.GetAllBooks();

            //GridViewLibraryBooks.DataSource = books;
            //GridViewLibraryBooks.DataBind();
        }
    }
}
