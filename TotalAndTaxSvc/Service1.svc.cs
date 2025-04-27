using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TotalAndTaxSvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TotalAndTaxService : TotalAndTaxServiceInterface
    {
        public float CalculateTotal(ArrayList prices) // Takes in an ArrayList of prices and returns the sum of them
        {
            float total = 0; // Starts the total at zero

            foreach (var item in prices) // Iterate through the prices
            {
                if (item is float || item is double || item is int || item is decimal) // Type validation
                {
                    total += Convert.ToSingle(item);
                }
                else
                {
                    throw new ArgumentException("All elements in the ArrayList must be numeric.");
                }
            }

            return total; // Return the calculated total
        }

        public float CalculateTax(float subtotal, float taxRate) // Takes 2 floats, subtotal and tax rate and turns the subtotal into the regular total (with tax)
        {
            float totalWithTax; // Initialize variables
            totalWithTax = subtotal;

            float tax = subtotal * taxRate; // Apply the tax

            totalWithTax += tax; // Add the tax to the subtotal

            return totalWithTax; // Return the post-tax total
        }
    }
}
