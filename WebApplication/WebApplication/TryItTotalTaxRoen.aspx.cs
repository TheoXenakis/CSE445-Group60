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
        protected void calcTotal(object sender, EventArgs e) // Calls method to calculate total
        {
            try
            {
                var pricesInput = txtPrices.Text.Split(','); // Parse comma separated prices list
                ArrayList pricesList = new ArrayList(); // Build into new ArrayList

                foreach (var price in pricesInput)
                {
                    if (float.TryParse(price.Trim(), out float parsedPrice))
                    {
                        pricesList.Add(parsedPrice); // Adds float parsed price
                    }
                    else
                    {
                        lblTotal.Text = "Error, invalid price"; // If it cannot be parsed we give an error
                        return;
                    }
                }

                object[] prices = pricesList.ToArray();
                TotalAndTaxSR.TotalAndTaxServiceInterfaceClient service = new TotalAndTaxSR.TotalAndTaxServiceInterfaceClient(); // Call the service
                float total = service.CalculateTotal(prices);

                lblTotal.Text = "$" + total.ToString("F2"); // Display the result
            }
            catch (Exception ex)
            {
                lblTotal.Text = "Error: " + ex.Message; // Return any exception
            }
        }

        protected void calcTax(object sender, EventArgs e) // Method to calculate tax
        {
            try
            {
                if (!float.TryParse(txtSubtotal.Text.Trim(), out float subtotal)) // Attempt to parse the subtotal (should be number)
                {
                    lblTotalWithTax.Text = "Invalid subtotal."; // If we can't we will give the user an error
                    return;
                }

                if (!float.TryParse(txtTaxRate.Text.Trim(), out float taxRate)) // Do the same for the tax rate
                {
                    lblTotalWithTax.Text = "Invalid tax rate.";
                    return;
                }

                TotalAndTaxSR.TotalAndTaxServiceInterfaceClient service = new TotalAndTaxSR.TotalAndTaxServiceInterfaceClient(); // Calls service to calculate post-tax total
                float totalWithTax = service.CalculateTax(subtotal, taxRate);

                lblTotalWithTax.Text = "$" + totalWithTax.ToString("F2"); // Show the total on the page
            }
            catch (Exception ex)
            {
                lblTotalWithTax.Text = "Error: " + ex.Message; // Display any errors
            }
        }
    }
}