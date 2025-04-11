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


[Creation Date]: 4/9/25

[Description]:
  Action Event Handling for the Default or 'Main' page of the Web Application

  User's are able to navigate to the other web pages from here..
*/


namespace WebApplication
{
    public partial class Default : System.Web.UI.Page
    {
      //Action-Event Handling
      //--------------------------------------------------------------------------------------

        //Executes Upon the Page Loading
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //[Button]: Member Page 
        protected void Button1_Click(object sender, EventArgs e)
        {

          //Implement a statement for redirecting the user to 'LoginPage.aspx'
          //  If they are not already logged in
          //    Verify a user's login status via a call to Cookies?!?! (I think)

          //Gather the cookie to see if a user is signed in\
            HttpCookie userCookie = Request.Cookies["userLoggedIn"];

          //Check if the cookie DNE or is incorrect
            if(userCookie == null || userCookie.Value != "true"){
              //Redirect the user to the Login Page
                Response.Redirect("LoginPage.aspx");
            }

          //Redirect to the Member Page
            Response.Redirect("MemberPage.aspx");
        }


        //[Button]: Staff Page 
        protected void Button2_Click(object sender, EventArgs e)
        {

          //Redirect to the Staff Page
            Response.Redirect("StaffPage.aspx");


        }


      //--------------------------------------------------------------------------------------
    }
}