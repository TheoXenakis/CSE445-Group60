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
              //Else, do nothing (allow the user to stay on the page)
            }
          //Cookie DNE & credentials are bad, redirect
            else{Response.Redirect("LoginPage.aspx");}
        }


      //----------------------------------------------------------------------------------
    }
}