using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Page to display confirmation to user that their purchase has been completed

namespace WebApplication
{
    public partial class PurchaseComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Button to allow the user to continue shopping (redirect to BookLibrary)
        protected void ButtonContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookLibrary.aspx");
        }

        //Button to allow users to view their purchased books
        protected void ButtonViewPurchases_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyPurchases.aspx");
        }
    }
}