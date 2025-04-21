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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface TotalAndTaxServiceInterface
    {
        [OperationContract]
        float CalculateTotal(ArrayList prices); // Calculates total sum given arraylist of prices (for cart)

        [OperationContract]
        float CalculateTax(float subtotal, float taxRate); // Calcuates post-tax total given tax rate and subtotal
    }
}
