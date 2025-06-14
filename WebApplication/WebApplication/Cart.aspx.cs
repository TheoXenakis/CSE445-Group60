﻿using System;
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
        ServiceReference2.Service1Client dbSvc2 = new ServiceReference2.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartItems(); // Load cart on page load
            }

            // Calculate total and tax on page load
            CART_SUBTOTAL = CalcTotals();
            CART_TOTAL = CalcTaxTotal(CART_SUBTOTAL);
        }

        private double CalcTotals() // Calls TotalAndTaxSvc to calculate cart subtotal and final total (with tax)
        {
            try
            {
                List<SimpleCartItem> cart = GetCartFromCookies(); // Retrieves cart

                if (cart == null || cart.Count == 0) // If cart is empty
                {
                    CartTotalLabel.Text = "0.00";
                    return 0.00;
                }

                List<float> pricesList = new List<float>();

                foreach (SimpleCartItem item in cart) // Build prices list to send to cart service
                {
                    float itemPrice = Convert.ToSingle(item.Price);
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        pricesList.Add(itemPrice);
                    }
                }

                object[] prices = Array.ConvertAll(pricesList.ToArray(), item => (object)item);

                float total = totalTaxSvc.CalculateTotal(prices); // Calls service to calculate the totals

                CartTotalLabel.Text = total.ToString("F2"); // Show floating point precision to 2 decimal places

                return (double)total; // Also return the total so we can use it later in execution (not currently needed but helpful for future)
            }
            catch (Exception ex)
            {
                CartTotalLabel.Text = "Error: " + ex.Message;
                return 0.00; // Else put $0.00 as total and return error
            }
        }

        private double CalcTaxTotal(double subtotal) // Calls tax service to calculate post-tax total
        {
            try
            {
                float taxTotal = totalTaxSvc.CalculateTax((float)subtotal, (float)0.04712); // 4.712% tax rate
                CartTaxTotalLabel.Text = taxTotal.ToString("F2"); // Updates UI
                return taxTotal; // Also return the total so we can use it later in execution (not currently needed but helpful for future)
            }
            catch (Exception ex)
            {
                CartTaxTotalLabel.Text = "Error: " + ex.Message;
                return 0.00; // Else put $0.00 as total and return error
            }

        }

        protected void BuyNowButton_Click(object sender, EventArgs e)
        {
            ProcessPurchase();
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

        private void ProcessPurchase()
        {
            try
            {
                string userName = Request.Cookies["accountUsername"]?.Value;

                if (string.IsNullOrEmpty(userName))
                {
                    Response.Redirect("LoginPage.aspx");
                    return;
                }

                List<SimpleCartItem> cart = GetCartFromCookies();

                if (cart == null || cart.Count == 0)
                {
                    return;
                }

                bool allPurchasesSuccessful = true;

                foreach (SimpleCartItem item in cart)
                {
                    string purchaseDate = DateTime.Now.ToString("yyyy-MM-dd");

                    for (int i = 0; i < item.Quantity; i++)
                    {
                        bool purchaseSuccess = dbSvc2.addUserPurchase(
                            userName,
                            item.Title,
                            Convert.ToDecimal(item.Price),
                            purchaseDate
                        );

                        if (!purchaseSuccess)
                        {
                            allPurchasesSuccessful = false;
                            System.Diagnostics.Debug.WriteLine($"Failed to store purchase for {item.Title}");
                        }
                    }
                }

                if (allPurchasesSuccessful)
                {
                    // Clear cart by expiring the cookie
                    HttpCookie cartCookie = new HttpCookie(CART_COOKIE_NAME);
                    cartCookie.Expires = DateTime.Now.AddDays(-1); // Set expiration in the past
                    Response.Cookies.Add(cartCookie);

                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                        "alert('Purchase completed successfully!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                        "alert('There was an issue processing your purchase. Please try again.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    $"alert('Error processing purchase: {ex.Message}');", true);
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