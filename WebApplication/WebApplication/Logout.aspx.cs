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
        protected void Page_Load(object sender, EventArgs e)
        {
            ExpireCookie("memberLoggedIn");
            ExpireCookie("accountUsername");
            ExpireCookie("staffLoggedIn");
            ExpireCookie("accountType");

            Session.Clear();
            Session.Abandon();

            Response.Redirect("Default.aspx");
        }

        private void ExpireCookie(string cookieName)
        {
            if (Request.Cookies[cookieName] != null)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Expires = DateTime.Now.AddDays(-1); // Set expiration to the past
                Response.Cookies.Add(cookie);
            }
        }
    }
}