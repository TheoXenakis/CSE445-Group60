using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class PurchaseComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookLibrary.aspx");
        }

        protected void ButtonViewPurchases_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyPurchases.aspx");
        }
    }
}