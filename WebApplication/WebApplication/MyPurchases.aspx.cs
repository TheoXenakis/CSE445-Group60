using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class MyPurchases : System.Web.UI.Page
    {
        ServiceReference2.Service1Client dbSvc2 = new ServiceReference2.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged in
            if (Request.Cookies["memberLoggedIn"] == null || Request.Cookies["memberLoggedIn"].Value != "true")
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                GetUserPurchases();
            }
        }

        private void GetUserPurchases()
        {
            try
            {
                // Get current username from cookie
                string userName = Request.Cookies["accountUsername"]?.Value;

                if (string.IsNullOrEmpty(userName))
                {
                    // If no username is found, display a message
                    GridViewPurchases.DataSource = null;
                    GridViewPurchases.DataBind();
                    return;
                }

                // Call the service to get user purchases
                string[][] purchasesArray = dbSvc2.getUserPurchases(userName);

                List<string[]> purchases = new List<string[]>(purchasesArray);

                if (purchases != null && purchases.Count > 0)
                {
                    // Create a DataTable to display the purchases
                    DataTable dt = new DataTable();
                    dt.Columns.Add("BookTitle", typeof(string));
                    dt.Columns.Add("Price", typeof(decimal));
                    dt.Columns.Add("PurchaseDate", typeof(string));

                    // Add purchases to the DataTable
                    foreach (string[] purchase in purchases)
                    {
                        decimal price = 0;
                        decimal.TryParse(purchase[1], out price);

                        dt.Rows.Add(purchase[0], price, purchase[2]);
                    }

                    // Bind the DataTable to the GridView
                    GridViewPurchases.DataSource = dt;
                    GridViewPurchases.DataBind();
                }
                else
                {
                    // No purchases found
                    GridViewPurchases.DataSource = null;
                    GridViewPurchases.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                GridViewPurchases.DataSource = null;
                GridViewPurchases.DataBind();

                // Optionally display an error message
                Response.Write("<script>alert('Error retrieving purchase history: " + ex.Message + "');</script>");
            }
        }

        protected void ButtonContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookLibrary.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }
    }
}
