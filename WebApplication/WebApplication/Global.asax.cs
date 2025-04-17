using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

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