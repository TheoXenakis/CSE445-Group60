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

    //Co-Authors


[Creation Date]: 4/10/25

[Description]:
    Login Page for users to login and create accounts.

*/


/*
[Boiler Code]:

  - {Setting Cookies}

    //Successful login, set a local Cookie to true
      HttpCookie successfulLogin = new HttpCookie("staffLoggedIn");

    //Set a time limit for the Cookie: 3 hours
      successfulLogin.Expires = DateTime.Now.AddHours(3);

    //Add the Cookie to the local environment among the aspx pages
      Response.Cookies.Add(successfulLogin);

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
            HttpCookie loginCookie = Request.Cookies["memberLoggedIn"];

            if (loginCookie != null)
            {
                string type = loginCookie["Type"];

                if (type == "Staff")
                {
                    Response.Redirect("StaffPage.aspx");
                }
                else 
                {
                    Response.Redirect("MemberPage.aspx");
                }
            }
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
            //[Service]: DataBase Services
            var serviceClient1 = new ServiceReference2.Service1Client();
            var serviceClient2 = new ServiceReference1.ServiceClient("BasicHttpsBinding_IService");

            // Attempt a Login to the user account using the services

            if (TextBox1.Text.Length > 0 && TextBox2.Text.Length > 0) {

                string encryptedPassword = serviceClient2.Encrypt(TextBox2.Text);

                if (serviceClient1.userLogin(TextBox1.Text, encryptedPassword))
                {
                    Label1.Text = "Login successful";

                    string userType = serviceClient1.getUserType(TextBox1.Text);

                    HttpCookie loginCookie = new HttpCookie("memberLoggedIn")
                    {
                        ["LoggedIn"] = "true",
                        ["Username"] = TextBox1.Text,
                        ["Type"] = userType,
                        Expires = DateTime.Now.AddHours(12)
                    };

                    Response.Cookies.Add(loginCookie);

                    // Redirect to member page page
                    Label1.Text = "Logged in!";

                    switch (userType) 
                    {
                        case "User":
                            Response.Redirect("MemberPage.aspx");
                            break;
                        case "Staff":
                            Response.Redirect("StaffPage.aspx");
                            break;
                        default:
                            Response.Redirect("MemberPage.aspx");
                            break;
                    }

                    
                }
                else 
                {
                    Label1.Text = "Login unsuccessful, please try again.";
                }
            }
            else
            {
                Label1.Text = "Don't leave the text boxes blank";
            }
        }



        //--------------------------------------------------------------------------------------
    }
}