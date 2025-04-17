using System;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Initialize application-wide settings (runs once on startup)
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Runs once per USER SESSION!
            // Check for existing dark mode cookie and set session variable
            HttpCookie darkModeCookie = Request.Cookies["DarkMode"];
            if (darkModeCookie != null)
            {
                Session["DarkMode"] = darkModeCookie.Value == "true";
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //RUNS FOR EVERY PAGE REQUEST!
            HttpCookie darkModeCookie = Request.Cookies["DarkMode"];
            if (darkModeCookie != null)
            {
                // Store in HttpContext for easy access during page rendering
                HttpContext.Current.Items["DarkMode"] = darkModeCookie.Value == "true";
            }
        }


        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //Handled when establishing user identity
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Handled when unhandled exception occurs (throw debug message to user)
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //When the session expires (only works in InProc mode)
            //clean up session specific resources
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //Handled when application shuts down
            //Cleans up app resources
        }
    }
}