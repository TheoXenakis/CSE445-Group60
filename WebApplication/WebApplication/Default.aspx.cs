using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/*
[Authors]:

    John Bostater

    Theo Xenakis

    Roen Wainscoat

[Creation Date]: 4/9/25

[Description]:
  Action Event Handling for the Default or 'Main' page of the Web Application

  User's are able to navigate to the other web pages from here..
*/


namespace WebApplication
{
    public partial class Default : System.Web.UI.Page
    {

      //Action Event Handling
      //------------------------------------------------------------

        //Executes Upon Page Loading
        protected void Page_Load(object sender, EventArgs e)
        {
          //Code here...
        }


        //[Button]: Staff Page

        protected void Button1_Click(object sender, EventArgs e)
        {
          //If the user is NOT signed in, redirect them to a login page from here


          //Code here..

        }


        //[Button]: Member Page
        protected void Button2_Click(object sender, EventArgs e)
        {

          //If the user is NOT signed in, redirect them to a login page from here


          //Code here..
        }
        //------------------------------------------------------------
    }
}