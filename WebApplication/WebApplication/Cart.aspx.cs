using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace WebApplication
{
    public partial class Cart : System.Web.UI.Page
    {
        private const string CART_COOKIE_NAME = "BookCart";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartItems();
            }
        }

        private void LoadCartItems()
        {
            List<SimpleCartItem> cart = GetCartFromCookies();

            if (cart != null && cart.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Columns.Add("Quantity", typeof(int));

                foreach (SimpleCartItem item in cart)
                {
                    dt.Rows.Add(item.Id, item.Title, item.Price, item.Quantity);
                }

                GridViewCart.DataSource = dt;
                GridViewCart.DataBind();

                if (GridViewCart.FooterRow != null)
                {
                    GridViewCart.FooterRow.Cells[0].Text = "Total Items:";
                    GridViewCart.FooterRow.Cells[3].Text = cart.Count.ToString();
                }
            }
            else
            {
                GridViewCart.DataSource = null;
                GridViewCart.DataBind();

                ButtonCheckout.Enabled = false;
                ButtonClearCart.Enabled = false;
            }
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
            cartCookie.Expires = DateTime.Now.AddDays(1); // Set expiration to 1 day

            Response.Cookies.Add(cartCookie);
        }

        protected void GridViewCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveItem")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);

                RemoveFromCart(bookId);

                GridViewCart.EditIndex = -1;

                LoadCartItems();
            }
        }

        private void RemoveFromCart(int bookId)
        {
            List<SimpleCartItem> cart = GetCartFromCookies();

            if (cart != null)
            {
                SimpleCartItem itemToRemove = cart.Find(item => item.Id == bookId);

                if (itemToRemove != null)
                {
                    cart.Remove(itemToRemove);

                    SaveCartToCookies(cart);
                }
            }
        }

        protected void ButtonContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookLibrary.aspx");
        }

        protected void ButtonClearCart_Click(object sender, EventArgs e)
        {
            HttpCookie cartCookie = new HttpCookie(CART_COOKIE_NAME);
            cartCookie.Expires = DateTime.Now.AddDays(-1); // Set expiration in the past
            Response.Cookies.Add(cartCookie);

            LoadCartItems();
        }

        protected void ButtonCheckout_Click(object sender, EventArgs e)
        {
            List<SimpleCartItem> cart = GetCartFromCookies();

            if (cart != null && cart.Count > 0)
            {
                Response.Redirect("Checkout.aspx");
            }
        }
    }
}