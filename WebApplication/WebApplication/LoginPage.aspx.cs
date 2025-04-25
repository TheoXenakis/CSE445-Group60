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
/*
            // Existing dark mode cookie check
            HttpCookie darkModeCookie = Request.Cookies["DarkMode"];
            if (darkModeCookie != null)
            {
                Session["DarkMode"] = darkModeCookie.Value == "true";
            }
*/

          //Request accountUsername & accountPassword Cookies to place into the Text-Fields they exist
            HttpCookie usernameCookie = Request.Cookies["accountUsername"];
            HttpCookie passwordCookie = Request.Cookies["accountPassword"];
        
          //Cookie Check
            if(usernameCookie != null && passwordCookie != null){
              //Place the user's information into the corresponding text fields
                TextBox1.Text = usernameCookie.Value;
                TextBox2.Text = passwordCookie.Value;
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
         
          //[Service]: Encryption & Decryption
            var serviceClient2 = new ServiceReference1.ServiceClient("BasicHttpsBinding_IService");

          //[Below has been Rewritten by John Bostater]

          //Successful Sign In, redirect to relevant page
            if(serviceClient1.userLogin(TextBox1.Text, serviceClient2.Encrypt(TextBox2.Text))){

              //Collect the user's type, redirect them to that page and update their relevant cookies
                string userType = serviceClient1.getUserType(TextBox1.Text);

              //Create a Cookie for the user's username (Displayed in Staff/Member page [Top-Right corner])
                HttpCookie accountUsername = new HttpCookie("accountUsername");
                  //Set the value & duration
                    accountUsername.Value = TextBox1.Text;
                    accountUsername.Expires = DateTime.MinValue;
                  
              //Add the Cookie to the page
                Response.Cookies.Add(accountUsername);

              //Redirect the user based on their Account Type
                switch(userType){

                  //Staff
                    case "Staff":
                      //Create a new Cookie for the relevant Account type
                        HttpCookie staffCookie = new HttpCookie("staffLoggedIn");
                          //Set value & duration
                            staffCookie.Value = "true";
                            staffCookie.Expires = DateTime.MinValue;

                      //Add the Cookie to the Application
                        Response.Cookies.Add(staffCookie); 

                      //Redirection
                        Response.Redirect("StaffPage.aspx");
                    break;

                  //Member
                    case "Member":
                      //Create a new Cookie for the relevant Account type
                        HttpCookie memberCookie = new HttpCookie("memberLoggedIn");
                          //Set value & duration
                            memberCookie.Value = "true";
                            memberCookie.Expires = DateTime.MinValue;

                      //Add the Cookie to the Application
                        Response.Cookies.Add(memberCookie); 

                      //Redirection
                        Response.Redirect("MemberPage.aspx");
                    break;
                }
            }
          //Else, Unsuccessful Sign in (inform user)
            Label1.Text = "Unsuccessful login, please check credentials.";
        }
      //--------------------------------------------------------------------------------------
    }
}