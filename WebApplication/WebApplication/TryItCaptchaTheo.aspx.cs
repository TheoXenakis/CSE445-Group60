using System;
using System.Diagnostics; // Add this for debugging
using System.IO; // Add this for stream operations
using System.Web.UI;
using WebApplication.CaptchaService;

//Author: John Bostater

//Co-Author: Theo Xenakis


namespace WebApplication
{
    public partial class TryItCaptchaTheo : System.Web.UI.Page
    {
        //-------------------------GENERATE CAPTCHA IMAGE FUNCTION--------------------------//
        protected void gen_Image_Click(object sender, EventArgs e)
        {
            using (var client = new CaptchaService.ServiceClient("BasicHttpsBinding_IService1"))
            {
                try
                {
                    // Get verification string
                    string length = "5"; //by default 5
                    if (string.IsNullOrEmpty(TextBox3.Text))
                    {
                        Debug.WriteLine("TextBox is empty, settig to default: 5");
                        length = "5";

                    }
                    else
                    {
                        length = TextBox3.Text; //set the length
                    }
                    string verifierStr = client.GetVerifierString(length);
                    Debug.WriteLine("Verifier String:", verifierStr);
                    TextBox4.Text = verifierStr;

                    // Get image stream
                    var imageStream = client.GetImage(verifierStr);

                    // Convert stream to base64
                    using (var memoryStream = new MemoryStream())
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        while ((bytesRead = imageStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            memoryStream.Write(buffer, 0, bytesRead);
                        }

                        string base64String = Convert.ToBase64String(memoryStream.ToArray());

                        // Display image (uses PNG NOT JPEG aghhhhhhhhhh)
                        Image1.ImageUrl = "data:image/png;base64," + base64String;
                        Image1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    TextBox4.Text = $"Error: {ex.GetType().Name} - {ex.Message}";
                    Image1.Visible = false;
                }
            }
        }
        //------------------------VALIDATE CAPTCHA GUESS WITH CORRECT VALUE--------------------------//
        protected void subCaptchaGuess(object sender, EventArgs e)
        {
            captchaResult.Visible = true;
            using (var client = new CaptchaService.ServiceClient("BasicHttpsBinding_IService1"))
            {
                try
                {
                    //check if invalid
                    if (answerBox.Text == null || answerBox.Text.Length == 0 || answerBox.Text != TextBox4.Text)
                    {
                        Debug.WriteLine("Answer does not match Captcha or Text Field is empty");
                        captchaResult.Text = "Answer does not match Captcha or Text Field is empty";
                    }
                    else
                    //match captcha, update textbox as such
                    {
                        Debug.WriteLine("Answer matches Captcha");
                        captchaResult.Text = "Answer matches Captcha";
                    }
                }
                catch (Exception ex)
                {
                    TextBox4.Text = $"Error: {ex.GetType().Name} - {ex.Message}";
                }
            }
        }
    }
}