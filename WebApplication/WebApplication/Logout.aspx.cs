using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) // Log the user out on page load and redirect to Default after logout
        {
            ExpireCookie("memberLoggedIn"); // Expire all possible cookies so we can use this for type=Member and type=Staff
            ExpireCookie("accountUsername");
            ExpireCookie("staffLoggedIn");
            ExpireCookie("accountType");

            Session.Clear(); // Remove the ASP session
            Session.Abandon();

            Response.Redirect("Default.aspx"); // Redirect to Default.aspx
        }

        private void ExpireCookie(string cookieName) // Simple method to set the cookie expiration in the past
        {
            if (Request.Cookies[cookieName] != null)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Expires = DateTime.Now.AddDays(-1); // Set expiration to the past so it gets removed immediately
                Response.Cookies.Add(cookie);
            }
        }
    }
}