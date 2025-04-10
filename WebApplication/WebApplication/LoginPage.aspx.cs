﻿using System;
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
    Login Page for users to login and create accounts.
*/


namespace WebApplication
{
    public partial class LoginPage : System.Web.UI.Page
    {
      //Action-Event Handling
      //--------------------------------------------------------------------------------------

        //Executes Upon the Page Loading
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        //[Link]: to Create an Account
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
          //Redirect the User to the 'Create an Account' Page
            Response.Redirect("CreateAccount.aspx");
        }



        //[Button]: Log into Account 
        protected void Button1_Click(object sender, EventArgs e)
        {

          //[To Do]:
          //  Call upon backend service/database to verify the Account!


          //Code here...



          //Change the name of the cookie set based upon the account the user has made...


          //Successful login, set a local Cookie to true
            HttpCookie successfulLogin = new HttpCookie("staffLoggedIn");

          //Set a time limit for the Cookie: 3 hours
            successfulLogin.Expires = DateTime.Now.AddHours(3);

          //Add the Cookie to the local environment among the aspx pages
            Response.Cookies.Add(successfulLogin);

        
          //DEBUG!!\
            Console.WriteLine("Cookie Set!");


          //Notify the user of succesful login!
            Label1.Text = "Successful Login!";

          //Also, Update display item in corner of Default page to notify the user that they have successfully logged in 
            //Code here..
        }


      //--------------------------------------------------------------------------------------
    }
}