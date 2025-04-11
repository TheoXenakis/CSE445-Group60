using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/*
[Authors]: 
    
    John Bostater

    //Co-Author


[Creation Date]: 4/10/25

[Description]:
    Page to create an account as a user.
*/


namespace WebApplication
{
    public partial class CreateAccount : System.Web.UI.Page
    {
      //Action-Event Handling
      //---------------------------------------------------------------

        //Executes upon the page loading
        protected void Page_Load(object sender, EventArgs e)
        {
          //Relevant code here...
        }


        //[Button]: Create an Account
        protected void Button1_Click(object sender, EventArgs e)
        {
          //Collect the Data from the fields to be sent in a message to the backend server/database
            //Text here..
        }


        //Utlilize the Encryption Connected Service (ServiceReference#) for encrypting/saving a users password to a backend database!!


        //---------------------------------------------------------------
    }
}