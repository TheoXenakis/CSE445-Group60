using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/*
[Author]: John Bostater

[Creation Date]: 4/19/25

[Description]:
    TryItPage for the functionality of the database: [Account Creation] [Log into Account]
*/



namespace WebApplication
{
    public partial class TryItDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //[Button]: Create an Account
        protected void Button2_Click(object sender, EventArgs e){Response.Redirect("CreateAccount.aspx");}


        //[Button]: Log into Account
        protected void Button5_Click(object sender, EventArgs e){Response.Redirect("LoginPage.aspx");}
    }
}