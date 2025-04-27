using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/*
[Authors]: 

    John Bostater

    Roen Wainscoat


[Creation Date]: 4/10/25

[Description]:
    Member(s) Page along with the relevant functionality
*/


namespace WebApplication
{
    public partial class MemberPage : System.Web.UI.Page
    {
      //Action-Event Handling
      //----------------------------------------------------------------------------------
  
        //Executes upon the page loading
        protected void Page_Load(object sender, EventArgs e)
        {    
          //Check for the cookie, if it DNE redirect the user to the Login Page
            if(Request.Cookies["memberLoggedIn"] != null){

              //False value, redirect 
                if(Request.Cookies["memberLoggedIn"].Value == "false"){Response.Redirect("LoginPage.aspx");}
                          
              //Else, display the username of the staff member via a Cookie
                Label4.Text = Request.Cookies["accountUsername"].Value;
            }
          //Cookie DNE & credentials are bad, redirect
            else{Response.Redirect("LoginPage.aspx");}
        }


        //[Button]: View Library & Books for sale
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookLibrary.aspx");
        }


        //[Button]: View Books the user has purchased
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyPurchases.aspx");
        }
        protected void Logout_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }


        //----------------------------------------------------------------------------------
    }
}