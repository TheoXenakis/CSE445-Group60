using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections;

namespace WebApplication
{
    public partial class Cart : System.Web.UI.Page
    {
        private const string CART_COOKIE_NAME = "BookCart";
        private double CART_SUBTOTAL = 0.00;
        private double CART_TOTAL = 0.00;

        TotalAndTaxSR.TotalAndTaxServiceInterfaceClient totalTaxSvc = new TotalAndTaxSR.TotalAndTaxServiceInterfaceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartItems();
            }

            CART_SUBTOTAL = CalcTotals();
            CART_TOTAL = CalcTaxTotal(CART_SUBTOTAL);
        }

        private double CalcTotals()
        {
            try
            {
                List<SimpleCartItem> cart = GetCartFromCookies();

                if (cart == null || cart.Count == 0)
                {
                    CartTotalLabel.Text = "0.00";
                    return 0.00;
                }

                List<float> pricesList = new List<float>();
                foreach (SimpleCartItem item in cart)
                {
                    float itemPrice = Convert.ToSingle(item.Price);
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        pricesList.Add(itemPrice);
                    }
                }

                object[] prices = Array.ConvertAll(pricesList.ToArray(), item => (object)item);

                float total = totalTaxSvc.CalculateTotal(prices);

                CartTotalLabel.Text = total.ToString("F2");

                return (double)total;
            }
            catch (Exception ex)
            {
                CartTotalLabel.Text = "Error: " + ex.Message;
                return 0.00;
            }
        }

        private double CalcTaxTotal(double subtotal)
        {
            try
            {
                float taxTotal = totalTaxSvc.CalculateTax((float)subtotal, (float)0.04712);
                CartTaxTotalLabel.Text = taxTotal.ToString("F2");
                return taxTotal;
            }
            catch (Exception ex)
            {
                CartTaxTotalLabel.Text = "Error: " + ex.Message;
                return 0.00;
            }

        }

        protected void BuyNowButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseComplete.aspx");
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

                PurchaseBtn.Enabled = false;
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
                Response.Redirect(Request.RawUrl); // Refresh the page (so the user doesn't have to click remove twice)
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

            // Rebind immediately after updating cart
            LoadCartItems();
        }

        protected void ButtonContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookLibrary.aspx");
        }
    }
}