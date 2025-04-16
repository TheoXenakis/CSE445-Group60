using System;
using System.Diagnostics; // Add this for debugging
using System.IO; // Add this for stream operations
using System.Web.UI;
using WebApplication.CaptchaService;

namespace WebApplication
{
    public partial class TryItPage : System.Web.UI.Page
    {
        protected void gen_Image_Click(object sender, EventArgs e)
        {
            using (var client = new CaptchaService.ServiceClient("BasicHttpsBinding_IService1"))
            {
                try
                {
                    // Get verification string
                    string length = "5"; // by default
                    if (string.IsNullOrEmpty(TextBox3.Text))
                    {
                        Debug.WriteLine("TextBox is empty, settig to default: 5");
                        length = "5";

                    }
                    else
                    {
                        length = TextBox3.Text;
                    }
                    string verifierStr = client.GetVerifierString(length);
                    Debug.WriteLine("Verifier String:", verifierStr);
                    TextBox4.Text = verifierStr;

                    // Get image stream
                    var imageStream = client.GetImage(verifierStr);

                    // Convert stream to base64 (without using Length)
                    using (var memoryStream = new MemoryStream())
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        while ((bytesRead = imageStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            memoryStream.Write(buffer, 0, bytesRead);
                        }

                        string base64String = Convert.ToBase64String(memoryStream.ToArray());

                        // Display image (use PNG instead of JPEG)
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
    }
}