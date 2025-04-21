using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class TryItTotalTaxRoen : System.Web.UI.Page
    {
        protected void calcTotal(object sender, EventArgs e)
        {
            try
            {
                var pricesInput = txtPrices.Text.Split(',');
                ArrayList pricesList = new ArrayList();

                foreach (var price in pricesInput)
                {
                    if (float.TryParse(price.Trim(), out float parsedPrice))
                    {
                        pricesList.Add(parsedPrice);
                    }
                    else
                    {
                        lblTotal.Text = "Error, invalid price";
                        return;
                    }
                }

                object[] prices = pricesList.ToArray();
                TotalAndTaxSvcRef.TotalAndTaxServiceInterfaceClient service = new TotalAndTaxSvcRef.TotalAndTaxServiceInterfaceClient();
                float total = service.CalculateTotal(prices);

                lblTotal.Text = "$" + total.ToString("F2");
            }
            catch (Exception ex)
            {
                lblTotal.Text = "Error: " + ex.Message;
            }
        }

        protected void calcTax(object sender, EventArgs e)
        {
            try
            {
                if (!float.TryParse(txtSubtotal.Text.Trim(), out float subtotal))
                {
                    lblTotalWithTax.Text = "Invalid subtotal.";
                    return;
                }

                if (!float.TryParse(txtTaxRate.Text.Trim(), out float taxRate))
                {
                    lblTotalWithTax.Text = "Invalid tax rate.";
                    return;
                }

                TotalAndTaxSvcRef.TotalAndTaxServiceInterfaceClient service = new TotalAndTaxSvcRef.TotalAndTaxServiceInterfaceClient();
                float totalWithTax = service.CalculateTax(subtotal, taxRate);

                lblTotalWithTax.Text = "$" + totalWithTax.ToString("F2");
            }
            catch (Exception ex)
            {
                lblTotalWithTax.Text = "Error: " + ex.Message;
            }
        }
    }
}