using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/*
[Authors]: 

    John Bostater

    //Co-Authors


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
          //Implement a statement for redirecting the user to 'LoginPage.aspx'
          //  If they are not already logged in
          //    Verify a user's login status via a call to Cookies?!?! (I think)
          //Gather the cookie to see if a user is signed in\
          HttpCookie loginCookie = Request.Cookies["memberLoggedIn"];

          //Check if the cookie DNE or is incorrect
            if (loginCookie == null){
                //Redirect the user to the Login Page
                Response.Redirect("LoginPage.aspx");
            }

            Label1.Text = "Welcome to the Member Page, " + loginCookie["Username"];
            Label2.Text = "User Type: " + loginCookie["Type"];
        }


      //----------------------------------------------------------------------------------
    }
}