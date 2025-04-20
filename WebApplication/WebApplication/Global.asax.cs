using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;


//Author: Theo Xenakis

//Co-Author: John Bostater
//   [Additon]: Cookies
// Co-Author: Roen Wainscoat
//   [Addition]: Logout function


namespace WebApplication
{
    public class Global : HttpApplication
    {
        // Visitor counter (application-wide)
        private static int _activeVisitors = 0;

        // Request tracking (last 100 requests)
        private static readonly List<string> _recentRequests = new List<string>();
        private static readonly object _lockObject = new object();

        protected void Application_Start(object sender, EventArgs e)
        {
            // Initialize application-wide counters
            HttpContext.Current.Application["TotalRequests"] = 0;
            HttpContext.Current.Application["ActiveVisitors"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
          //Initialize Cookies that do not exist or have not been already set here
            //[To Do - John]:
            /*
                - Have checks for Cookies as to whether they are null to initialize new ones if necessary

                - Example:

                Check for
                    "userLogin" = null         (Default Value)    
                    "accountUsername" = null   (Default Value)    
                    "accountPassword" = null   (Default Value)    
                    "accountType" = null       (Default Value)    
            
                If not Null, then these values exist already and do not need to be intialized 
                (i.e. set to their default values)
            
            */         
         
          //Check of Cookies
            //HttpCookie userLogin = Request.Cookies["userLoggedIn"];


          //Initialization of Cookies that Do not exist
           // if(){
              //Description here..
                //Code here..
            //}


            // Update visitor counter
            System.Threading.Interlocked.Increment(ref _activeVisitors);
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application["ActiveVisitors"] = _activeVisitors;
            HttpContext.Current.Application.UnLock();

            // Existing dark mode cookie check
            HttpCookie darkModeCookie = Request.Cookies["DarkMode"];
            if (darkModeCookie != null)
            {
                Session["DarkMode"] = darkModeCookie.Value == "true";
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Track total requests
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application["TotalRequests"] = (int)HttpContext.Current.Application["TotalRequests"] + 1;
            HttpContext.Current.Application.UnLock();

            // Log request (last 100)
            var requestInfo = $"{DateTime.UtcNow:HH:mm:ss} | {Request.HttpMethod} {Request.Url.AbsolutePath}";
            lock (_lockObject)
            {
                if (_recentRequests.Count >= 100) _recentRequests.RemoveAt(0);
                _recentRequests.Add(requestInfo);
            }

            // Existing dark mode handling
            HttpCookie darkModeCookie = Request.Cookies["DarkMode"];
            if (darkModeCookie != null)
            {
                HttpContext.Current.Items["DarkMode"] = darkModeCookie.Value == "true";
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Unitialize Cookies here to log the user out
            if (Request.Cookies["memberLoggedIn"] != null)
            {
                // Expire the cookie
                HttpCookie loginCookie = new HttpCookie("memberLoggedIn")
                {
                    Expires = DateTime.Now.AddDays(-1), // New expiration date is in the past
                    ["LoggedIn"] = string.Empty,
                    ["Username"] = string.Empty,
                    ["Type"] = string.Empty,
                };

                Response.Cookies.Add(loginCookie);
            }


            // Update visitor counter
            System.Threading.Interlocked.Decrement(ref _activeVisitors);
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application["ActiveVisitors"] = _activeVisitors;
            HttpContext.Current.Application.UnLock();
        }

        // Helper methods to access statistics
        public static int GetActiveVisitors()
        {
            return _activeVisitors;
        }

        public static int GetTotalRequests()
        {
            return (HttpContext.Current.Application["TotalRequests"] as int?) ?? 0;
        }

        public static List<string> GetRecentRequests()
        {
            lock (_lockObject)
            {
                return new List<string>(_recentRequests);
            }
        }

    }
}