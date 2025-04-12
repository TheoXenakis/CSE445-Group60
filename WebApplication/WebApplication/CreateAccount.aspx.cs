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
          //Create a Service Client to call upon the Encryption services
            var serviceClient = new ServiceReference1.ServiceClient("BasicHttpsBinding_IService");

          //[Note]: 
          // Later on this can be changed to a regex for username & Password Requirements


          //Make sure all of the text fields have minimum character requirement & are all filled
            if(    (TextBox1.Text.Length >= 3 && TextBox1.Text.Length <= 16)
                && (TextBox2.Text.Length >= 3 && TextBox2.Text.Length <= 16)
                && (TextBox3.Text.Length >= 3 && TextBox3.Text.Length <= 16)
                && (TextBox2.Text == TextBox3.Text) //Confirm Password Check
            ){
              //Collect the Data from the fields to be sent in a message to the backend server/database
                //Text here..

              //[ENCRYPT PASSWORDS FOR STORAGE ON THE BACKEND!!, DO NOT SAVE RAW PASSWORDS TO THE BACKEND DB!!]
              //  [PASSWORD VERIFICATION WILL BE DONE BY PASSING PLAINTEXT INTO 'Encrypt' function & making sure the result is the same as what is stored on the backend DB]


              //Set up a backend service for storing and logging the files into a backend 

            }            
          //Else, User Error Inform them to Fix & resubmit
            else{

            }

        }


        //Utlilize the Encryption Connected Service (ServiceReference#) for encrypting/saving a users password to a backend database!!


      //---------------------------------------------------------------
    }
}