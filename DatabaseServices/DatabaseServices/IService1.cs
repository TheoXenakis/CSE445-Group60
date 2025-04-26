using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


/*
[Authors]: 
    
    John Bostater
    Roen Wainscoat

    //Co-Author


[Creation Date]: 4/12/25

[Description]:
    Forward Declartions of the Methods offered by the WCF Service Application
*/


//Included Libraries
//------------------
  using System.Xml;
  using System.IO;
//------------------


namespace DatabaseServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
      //Forward Declarations
      //-----------------------------------------------------------------------------------------------

        [OperationContract]
        bool createUser(string userName, string userPassword, string userType, string userLoggedIn);


        [OperationContract]
        bool userNameExists(string userName);


        [OperationContract]
        bool userLogin(string userName, string encryptedPassword);

        [OperationContract]
        string getUserType(string userName);

        [OperationContract]
        bool addUserPurchase(string userName, string bookTitle, decimal price, string purchaseDate);

        [OperationContract]
        List<string[]> getUserPurchases(string userName);

      //DEBUG FUNCTION!!  [Remove for final version/after developments]
        [OperationContract]
        string debugFunct();
      //-----------------------------------------------------------------------------------------------
    }
}
