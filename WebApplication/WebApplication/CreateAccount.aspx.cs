using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/*
[Authors]: 
    
    John Bostater
   
    Roen Wainscoat
      // [Addition] : Implemented User Control by adding Captcha challenge to the Create Account Page


[Creation Date]: 4/10/25

[Description]:
    Page to create an account as a user.
*/


namespace WebApplication
{
    public partial class CreateAccount : System.Web.UI.Page
    {
      //Global Flag for redirection to Login Page
        bool successfulAccountCreation = false;
        string vfString; // String to hold correct captcha answer

        //Action-Event Handling
        //---------------------------------------------------------------

        //Executes upon the page loading
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only generate a new CAPTCHA if this is the first time page loaded
            if (!IsPostBack)
            {
                var captchaSvcClient = new CaptchaService.ServiceClient();
                string vfString = captchaSvcClient.GetVerifierString("5");

                using (var imageStream = captchaSvcClient.GetImage(vfString))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        imageStream.CopyTo(memoryStream);
                        byte[] imageBytes = memoryStream.ToArray();

                        Session["CaptchaVerifier"] = vfString;

                        string base64Image = Convert.ToBase64String(imageBytes);
                        capImage.ImageUrl = "data:image/png;base64," + base64Image;
                    }
                }
            }
        }



        //[Button]: Create an Account
        protected void Button1_Click(object sender, EventArgs e)
        {
          //[Account Info]:
          //  - Username      {TextBox1}
          //  - Password      {TextBox2}   [Encrypted]
          //  - Account-Type  {TextBox3}   [Member, Staff]


          //[Service]: Encryption & Decryption  {External} 
            var serviceClient = new ServiceReference1.ServiceClient("BasicHttpsBinding_IService");

         
          //[Service]: DataBase  {Local}
            var serviceClient1 = new ServiceReference2.Service1Client();


            //[Service]: Captcha  {External}
            // Service implemented by Theo Xenakis
            // Functionality in CreateAccount implemented by Roen Wainscoat [user control]

            string sessionVerifier = Session["CaptchaVerifier"] as string;

            if (string.IsNullOrEmpty(sessionVerifier))
            {
                Label2.Text = "CAPTCHA verification error. Please refresh the page and try again.";
                return;
            }


            //[Note]: 
            // Later on this if-branch can be changed to a regex for username & Password Requirements
          
            //Create an Account
            if (    (TextBox1.Text.Length >= 4 && TextBox1.Text.Length <= 16)  //Username
                && (TextBox2.Text.Length >= 4 && TextBox2.Text.Length <= 16)  //Password
                && (TextBox3.Text.Length >= 4 && TextBox3.Text.Length <= 16)  //Confirm Password
                && (TextBox2.Text == TextBox3.Text)                //Confirm Password Check
                && !(serviceClient1.userNameExists(TextBox1.Text)) //Account Does Not Already Exist
                && (RadioButtonList1.SelectedItem.Text != "")  //Select Account Check
            ){
              //Collect the Data from the fields to be sent in a message to the backend server/database
                string username = TextBox1.Text;

              //Encrypt the password the user has entered
                string encryptedPassword = serviceClient.Encrypt(TextBox2.Text);

              //[Account Creation] Place result into bool
                bool accountCreation = serviceClient1.createUser(username, encryptedPassword, RadioButtonList1.SelectedItem.Text, "false");

              //Successful Account Creation
                if(accountCreation){
                  //Notify the user
                    Label2.Text = "Account Succesfully Created, Proceed to the Login Page";


                  //Create Cookies & Set them to be used in "LoginPage.aspx" for entering the user's credentials for them
                  //  [Therefore they only have to press "Submit" to proceed to their Account Type's page]

                  //[Username Cookie]
                    HttpCookie usernameCookie = new HttpCookie("accountUsername");
                      //Set the cookies value
                        usernameCookie.Value = username;
                        //Set cookie to expire in 1 second
                          usernameCookie.Expires = DateTime.Now.AddSeconds(1);

                  //[Password Cookie]
                    HttpCookie passwordCookie = new HttpCookie("accountPassword");
                      //Set the cookies value
                        passwordCookie.Value = TextBox2.Text;
                        //Set cookie to expire in 1 seconds
                          passwordCookie.Expires = DateTime.Now.AddSeconds(1);

                  //Add the Cookies to the Application
                    Response.Cookies.Add(usernameCookie);
                    Response.Cookies.Add(passwordCookie);

                  //Redirect the user to the Login Page
                    Response.Redirect("LoginPage.aspx");
                }
              //Unsuccessful Account Creation, account already exists
                else{Label2.Text = "Account Already Exists, please use another username";}
            }
          //Else, User Error Inform them to Fix & resubmit
            else{Label2.Text = "Error in form submission ";}
        }
      //---------------------------------------------------------------
    }
}