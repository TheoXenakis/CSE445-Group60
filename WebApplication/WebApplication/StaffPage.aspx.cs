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
    Staff Page along with the relevant functionality
*/


namespace WebApplication
{
    public partial class StaffPage : System.Web.UI.Page
    {
      //Global Variables
      //------------------------
        string userName = "Default Name";
      //------------------------


      //Action-Event Handling
      //---------------------------------------------------------------------------------------------------

        //Executes upon page loading
        protected void Page_Load(object sender, EventArgs e)
        {
          //Check for the cookie, if it DNE redirect the user to the Login Page
            if(Request.Cookies["staffLoggedIn"] != null){
              
              //False value, redirect 
                if(Request.Cookies["staffLoggedIn"].Value == "false"){Response.Redirect("LoginPage.aspx");}

              //Else, display the username of the staff member via a Cookie
                Label3.Text = Request.Cookies["accountUsername"].Value;
            }
          //Cookie DNE & credentials are bad, redirect
            else{Response.Redirect("LoginPage.aspx");}
        }


        //[Button]: Add & Manage books in the Library/Store
        protected void Button1_Click(object sender, EventArgs e)
        {

        }


      //---------------------------------------------------------------------------------------------------
    }
}