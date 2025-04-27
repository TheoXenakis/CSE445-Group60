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

        private void LoadSampleBooks()
        {
            System.Data.DataTable dt = new System.Data.DataTable(); // Get this stuff from Theo's service

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Author", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));

            dt.Rows.Add(1, "Sample Book 1", "Author A", 10.00);
            dt.Rows.Add(2, "Sample Book 2", "Author B", 15.00);
            dt.Rows.Add(3, "Sample Book 3", "Author C", 30.00);

            GridViewBooks.DataSource = dt;
            GridViewBooks.DataBind();
        }
        private void LoadBooksFromSvc()
        {
            System.Diagnostics.Debug.WriteLine("Entered LoadBookFromSVC");
            try
            {
                var books = bookServiceClient.GetAllBooks();

                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Author", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));

                foreach (var book in books)
                {
                    dt.Rows.Add(book.Id, book.Title, book.Author, book.Price);
                }

                GridViewBooks.DataSource = dt;
                GridViewBooks.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading books from service: " + ex.Message);
            }
        }

        protected void GridViewBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                string title = HttpUtility.HtmlDecode(row.Cells[1].Text);

                decimal price = 0;

                DataRowView drv = row.DataItem as DataRowView;
                if (drv != null && drv["Price"] != null)
                {
                    price = Convert.ToDecimal(drv["Price"]);
                }
                else
                {
                    string priceText = HttpUtility.HtmlDecode(row.Cells[3].Text);

                    priceText = priceText.Replace("$", "").Replace(",", "").Trim();

                    if (!Decimal.TryParse(priceText,
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out price))
                    {
                        price = 0; // Default price if parsing fails
                    }
                }

                AddToCart(bookId, title, price);
            }
        }

        private void AddToCart(int bookId, string title, decimal price)
        {
            List<SimpleCartItem> cart = GetCartFromCookies();

            SimpleCartItem existingItem = cart.Find(item => item.Id == bookId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new SimpleCartItem
                {
                    Id = bookId,
                    Title = title,
                    Price = price,
                    Quantity = 1
                });
            }

            SaveCartToCookies(cart);
        }

        private List<SimpleCartItem> GetCartFromCookies()
        {
            HttpCookie cartCookie = Request.Cookies[CART_COOKIE_NAME];
            if (cartCookie != null && !string.IsNullOrEmpty(cartCookie.Value))
            {
                try
                {
                    string decodedValue = HttpUtility.UrlDecode(cartCookie.Value);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Deserialize<List<SimpleCartItem>>(decodedValue);
                }
                catch
                {
                    return new List<SimpleCartItem>();
                }
            }
            return new List<SimpleCartItem>();
        }

        private void SaveCartToCookies(List<SimpleCartItem> cart)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string cartJson = serializer.Serialize(cart);

            HttpCookie cartCookie = new HttpCookie(CART_COOKIE_NAME);
            cartCookie.Value = HttpUtility.UrlEncode(cartJson);
            cartCookie.Expires = DateTime.Now.AddDays(1); // Set cart cookie expiration to 1 day

            Response.Cookies.Add(cartCookie);
        }

        protected void ViewCartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }
        protected void Back_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("MemberPage.aspx");
        }
    }

    [Serializable]
    public class SimpleCartItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}