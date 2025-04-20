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

    //Co-Author


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
          //[Account Info]:
          //  - Username      {TextBox1}
          //  - Password      {TextBox2}   [Encrypted]
          //  - Account-Type  {TextBox3}   [Member, Staff]


          //[Service]: Encryption & Decryption  {External} 
            var serviceClient = new ServiceReference1.ServiceClient("BasicHttpsBinding_IService");

         
          //[Service]: DataBase  {Local}
            var serviceClient1 = new ServiceReference2.Service1Client();


          //[Service]: Captcha  {External}
            //Theo Xenakis


//DEBUG 
//Label2.Text = serviceClient1.userLogin("SampleUser");

          //[Note]: 
          // Later on this if-branch can be changed to a regex for username & Password Requirements

//Uncomment to 
///*
          //Create an Account
            if(    (TextBox1.Text.Length >= 4 && TextBox1.Text.Length <= 16)  //Username
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

                    Response.Redirect("LoginPage.aspx");

                    //Set local Cookies for the user's information: userName, password, accountType
                    //Code here..


                    //[IMPLEMENT]
                    //Create a timer that will redirect the user back to the login page & fill in their credentials for them!

                }
              //Unsuccessful Account Creation, account already exists
                else{Label2.Text = "Account Already Exists, please use another UserName";}
            }
          //Else, User Error Inform them to Fix & resubmit
            else{Label2.Text = "Error in form submission ";}
//*/
        }
      //---------------------------------------------------------------
    }
}