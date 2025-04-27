using System;
using System.Web.UI;

namespace WebApplication
{
    public partial class TryItGlobalFuncts : Page
    {
        protected void Page_Load(object sender, EventArgs e) //update the counter for requests
        {
            if (!IsPostBack)
            {
                UpdateCounts();
                BindRecentRequests();
            }
        }
        //Retreive information when refreshing
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateCounts();
            BindRecentRequests();
        }

        //Update active visitor and total request counts
        private void UpdateCounts()
        {
            try
            {
                txtActiveVisitors.Text = Global.GetActiveVisitors().ToString();
                txtTotalRequests.Text = Global.GetTotalRequests().ToString();
            }
            catch (Exception ex)
            {
                txtActiveVisitors.Text = "Error";
                txtTotalRequests.Text = "Error";

                //print for debugging purposes
                Console.WriteLine(ex.ToString());
            }
        }
        //Bind recent requests for display purposes
        private void BindRecentRequests()
        {
            try
            {
                var requests = Global.GetRecentRequests();
                gvRecentRequests.DataSource = requests;
                gvRecentRequests.DataBind();
            }
            catch (Exception ex)
            {
                gvRecentRequests.DataSource = null;
                gvRecentRequests.DataBind();


            }
        }
    }
}