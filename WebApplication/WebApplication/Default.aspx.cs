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
        protected void Button1_Click(object sender, EventArgs e) { Response.Redirect("MemberPage.aspx"); }

        //[Button]: Staff Page 
        protected void Button2_Click(object sender, EventArgs e) { Response.Redirect("StaffPage.aspx"); }

        //[Link]: John's (1st) TryItPage Link  {Remove for Final Web Application}
        protected void LinkButton1_Click(object sender, EventArgs e) { Response.Redirect("TryItEncryptionJohn.aspx"); }

        //[Link]: John's (2nd) TryItPage Link   {Remove for Final Web Application}
        protected void LinkButton3_Click(object sender, EventArgs e) { Response.Redirect("TryItDatabaseJohn.aspx"); }

        //[Link]: Theo's TryItPage Link - Book Service
        protected void BookServiceBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44321/BookManager.aspx");
        }

      //--------------------------------------------------------------------------------------
    }
}