using System;
using System.Diagnostics; // Add this for debugging
using System.IO; // Add this for stream operations
using System.Web.UI;
using WebApplication.CaptchaService;

//Author: John Bostater

//Co-Author: Theo Xenakis


namespace WebApplication
{
    public partial class TryItEncryptionJohn : System.Web.UI.Page
    {
        //[Button]: Encryption
        protected void Button1_Click(object sender, EventArgs e)
        {
          //Client for the Encryption Connected Service
            var serviceClient = new ServiceReference1.ServiceClient("BasicHttpsBinding_IService");

          //Make sure the Text box is not empty before proceeding
            if(TextBox1.Text.Length != 0){
                //Encrypt the text from 'Input' [TextBox1]
                    TextBox2.Text = serviceClient.Encrypt(TextBox1.Text);
            }
          //Else, Notify the user to enter text!
            else{
              //Notification
                TextBox1.Text = "Enter Text Here";
            }
        }


        //[Button]: Decryption
        protected void Button3_Click(object sender, EventArgs e)
        {
          //Client for the Decryption Connected Service
            var serviceClient = new ServiceReference1.ServiceClient("BasicHttpsBinding_IService");

          //Make sure the Text box is not empty before proceeding
            if(TextBox1.Text.Length != 0){
              //Decrypt the text from 'Input' [TextBox1]
                TextBox2.Text = serviceClient.Decrypt(TextBox1.Text);
            }
          //Else, Notify the user to enter text!
            else{
              //Notification
                TextBox1.Text = "Enter ENCRYPTED Text Here";
            }
        }

    }
}