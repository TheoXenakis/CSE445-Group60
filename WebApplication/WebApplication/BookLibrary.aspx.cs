using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;

namespace WebApplication
{
    public partial class BookLibrary : System.Web.UI.Page
    {
        private const string CART_COOKIE_NAME = "BookCart";

        BookServiceReference.BookServiceClient bookServiceClient = new BookServiceReference.BookServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBooksFromSvc();
            }
        }

        private void LoadSampleBooks() // Loads a sample set of books (useful for debugging mostly)
        {
            System.Data.DataTable dt = new System.Data.DataTable(); // Get this stuff from Theo's service

            dt.Columns.Add("Id", typeof(int)); // Builds new data table in the format on BookLibrary.aspx
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Author", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));

            dt.Rows.Add(1, "Sample Book 1", "Author A", 10.00);
            dt.Rows.Add(2, "Sample Book 2", "Author B", 15.00);
            dt.Rows.Add(3, "Sample Book 3", "Author C", 30.00);

            GridViewBooks.DataSource = dt; // Bind the data table to have it show
            GridViewBooks.DataBind();
        }
        private void LoadBooksFromSvc() // Loads books from BookService
        {
            try
            {
                var books = bookServiceClient.GetAllBooks(); // Calls Book Service to get the books

                System.Data.DataTable dt = new System.Data.DataTable(); // Similar to load sample books, builds book table using new data from Book Manager
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Author", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));

                foreach (var book in books)
                {
                    dt.Rows.Add(book.Id, book.Title, book.Author, book.Price);
                }

                GridViewBooks.DataSource = dt; // Binds the data table (make it interactive on page)
                GridViewBooks.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading books from service: " + ex.Message); // Handle/log errors
            }
        }

        protected void GridViewBooks_RowCommand(object sender, GridViewCommandEventArgs e) // Handles row commands for book table
        {
            if (e.CommandName == "AddToCart") // Add to cart command
            {
                int bookId = Convert.ToInt32(e.CommandArgument); // Reference the book by its ID

                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                string title = HttpUtility.HtmlDecode(row.Cells[1].Text);

                decimal price = 0;

                DataRowView drv = row.DataItem as DataRowView;

                if (drv != null && drv["Price"] != null) // Grabs price from row
                {
                    price = Convert.ToDecimal(drv["Price"]);
                }
                else
                {
                    string priceText = HttpUtility.HtmlDecode(row.Cells[3].Text);

                    priceText = priceText.Replace("$", "").Replace(",", "").Trim(); // Decodes price from the $x.xx format

                    if (!Decimal.TryParse(priceText,
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out price))
                    {
                        price = 0; // Default price is $0.00 if the parsing fails for whatever reason
                    }
                }

                AddToCart(bookId, title, price); // Calls the add to cart method with the book attributes
            }
        }

        private void AddToCart(int bookId, string title, decimal price) // Add to cart method
        {
            List<SimpleCartItem> cart = GetCartFromCookies(); // Calls method to retrieve the cart from user's cookies

            SimpleCartItem existingItem = cart.Find(item => item.Id == bookId);

            if (existingItem != null)
            {
                existingItem.Quantity++; // For handling when a user has clicked "add to cart" more than once on a single item
            }
            else
            {
                cart.Add(new SimpleCartItem
                {
                    Id = bookId,
                    Title = title,
                    Price = price,
                    Quantity = 1
                }); // Otherwise we just create a new cart item with qty=1
            }

            SaveCartToCookies(cart); // Commit new cart to user's memory
        }

        private List<SimpleCartItem> GetCartFromCookies() // Gets the cart from user's cookies for use in the program
        {
            HttpCookie cartCookie = Request.Cookies[CART_COOKIE_NAME];
            if (cartCookie != null && !string.IsNullOrEmpty(cartCookie.Value)) // If cookie exists
            {
                try
                {
                    string decodedValue = HttpUtility.UrlDecode(cartCookie.Value);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Deserialize<List<SimpleCartItem>>(decodedValue);
                }
                catch
                {
                    return new List<SimpleCartItem>(); // If cookie doesn't exist, return an empty cart
                }
            }

            return new List<SimpleCartItem>();
        }

        private void SaveCartToCookies(List<SimpleCartItem> cart) // For committing a new cart type item to memory in a cookie
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string cartJson = serializer.Serialize(cart);

            HttpCookie cartCookie = new HttpCookie(CART_COOKIE_NAME); // Builds new cart cookie
            cartCookie.Value = HttpUtility.UrlEncode(cartJson); // Puts new data into it
            cartCookie.Expires = DateTime.Now.AddDays(1); // Set cart cookie expiration to 1 day

            Response.Cookies.Add(cartCookie); // Commits new cart to memory
        }

        protected void ViewCartBtn_Click(object sender, EventArgs e) // Handles when "View Cart" button is clicked
        {
            Response.Redirect("Cart.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e) // Handles when "Logout" button is clicked
        {
            Response.Redirect("Logout.aspx");
        }
        protected void Back_Clicked(object sender, EventArgs e) // Handles when "Back" button is clicked
        {
            Response.Redirect("MemberPage.aspx");
        }
    }

    [Serializable]
    public class SimpleCartItem // Simple data structure for cart item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}