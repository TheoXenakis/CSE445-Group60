using System;
using System.Web.UI;

namespace WebApplication
{
    public partial class TryItGlobalFuncts : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateCounts();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateCounts();
        }

        private void UpdateCounts()
        {
            try
            {
                // Get and display active visitors
                txtActiveVisitors.Text = Global.GetActiveVisitors().ToString();

                // Get and display total requests
                txtTotalRequests.Text = Global.GetTotalRequests().ToString();
            }
            catch (Exception ex)
            {
                txtActiveVisitors.Text = "Error";
                txtTotalRequests.Text = "Error";
            }
        }
    }
}