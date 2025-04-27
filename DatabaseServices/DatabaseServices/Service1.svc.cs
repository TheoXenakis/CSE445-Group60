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
    Definitions for Methods of the WCF Service
        This File is responsible for the XML data management of the Usernames & Passwords of user accounts
*/


//Included Libraries
//------------------
  using System.Xml;
  using System.IO;
//------------------


namespace DatabaseServices
{
    public class Service1 : IService1
    {
      //[Note]:
      //   Create & Manage an XML file via the Methods Defined here..


      //Global Variables
      //--------------------------------------------------------------------------------------------------
        //Path to the XML file
          string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "userData.xml");
      //--------------------------------------------------------------------------------------------------


      //Method Definitions
      //-------------------------------------------------------------------------------
        
        //Store incoming user information to the XML file/Database
          public bool createUser(string userName, string userPassword, string userType, string userLoggedIn){

            //If the userName doesn't already exist, proceed
              if(!userNameExists(userName)){
                
                //Parse the XML file for the username, if it exists [True]
                  try{
                    //Create an XML Document Object
                      XmlDocument xmlDoc = new XmlDocument();

                    //Load the XML doc via the Path
                      xmlDoc.Load(xmlPath);

                    //Create a new 'User' element  
                      XmlElement newUser = xmlDoc.CreateElement("User");

                    //Set the attributes/data of the new Element                    
                    //-------------------------------------------------------------------------------------------------
                      //Username
                        XmlElement accountUsername = xmlDoc.CreateElement("Username");
                          //Set the data
                            accountUsername.InnerText = userName;

                      //Password
                        XmlElement accountPassword = xmlDoc.CreateElement("Password");
                          //Set the data
                            accountPassword.InnerText = userPassword;

                      //AccountType
                        XmlElement accountType = xmlDoc.CreateElement("AccountType");
                          //Set the data
                            accountType.InnerText = userType;

                      //Logged In
                        XmlElement accountLoggedIn = xmlDoc.CreateElement("LoggedIn");
                          //Set the data
                            accountLoggedIn.InnerText = userLoggedIn;

                      //Append Attributes to the New User
                        newUser.AppendChild(accountUsername);
                        newUser.AppendChild(accountPassword);
                        newUser.AppendChild(accountType);
                        newUser.AppendChild(accountLoggedIn);

                      //Root Node (Accounts; where user's are added)
                        XmlNode accountsNode = xmlDoc.DocumentElement;
                      
                      //Append the NewUser to the Root (Accounts)
                        accountsNode.AppendChild(newUser);                      
                    
                      //Save the changes to the XML file
                        xmlDoc.Save(xmlPath);
                    //-------------------------------------------------------------------------------------------------

                    //Successful operation
                      return true;
                  }
                //Error
                  catch(Exception e){Console.WriteLine("Username Exists, Error!");}
              }

            //Else, userName exists, do NOT proceed
              return false;
          }


        //See if a user exists within the XML file/Database
          public bool userNameExists(string userName){

            //Parse the XML file for the username, if it exists [True]
              try{
                //Create an XML Document Object
                  XmlDocument xmlDoc = new XmlDocument();

                //Load the XML doc via the Path
                  xmlDoc.Load(xmlPath);

                //Get a list of nodes from the XML document
                  XmlNodeList userNodes = xmlDoc.SelectNodes("/Accounts/User");


                //Parse Each 'User' until the corresponding username is hit
                  foreach(XmlNode parsedUser in userNodes){

                    //Collect the information from the selected user
                      string accountUsername = parsedUser.SelectSingleNode("Username").InnerText;

                    //Matching Username, return True!
                      if(accountUsername == userName){return true;}
                  }
              }
            //Error
              catch(Exception e){Console.WriteLine("Username Exists, Error!");}


            //Else, username does NOT exist
              return false;
          }


      //User Login
        public bool userLogin(string userName, string encryptedPassword)
        {
          //Proceed if the username exists
            if(userNameExists(userName)){

              //Parse the XML file for the username, if it exists [True]
                try{
                  //Create an XML Document Object
                    XmlDocument xmlDoc = new XmlDocument();

                  //Load the XML doc via the Path
                    xmlDoc.Load(xmlPath);

                  //Get a list of nodes from the XML document
                    XmlNodeList userNodes = xmlDoc.SelectNodes("/Accounts/User");


                  //Parse Each 'User' until the corresponding username is hit
                    foreach(XmlNode parsedUser in userNodes){

                      //Collect the information from the selected user
                        string accountUsername = parsedUser.SelectSingleNode("Username").InnerText;
                        string accountPassword = parsedUser.SelectSingleNode("Password").InnerText;
                        string accountLoggedIn = parsedUser.SelectSingleNode("LoggedIn").InnerText;

                      //Matching Username & Password, return True!
                        if(userName == accountUsername && accountPassword == encryptedPassword && accountLoggedIn == "false"){return true;}
                    }
                }
              //Error
                catch(Exception e){Console.WriteLine("Username Exists, Error!");}
            }


          //Unsucessful login
            return false;
        }

        // Add a method to store user purchase data
        public bool addUserPurchase(string userName, string bookTitle, decimal price, string purchaseDate)
        {
            // Only proceed if the username exists
            if (userNameExists(userName))
            {
                try
                {
                    // Create an XML Document Object
                    XmlDocument xmlDoc = new XmlDocument();

                    // Load the XML doc via the Path
                    xmlDoc.Load(xmlPath);

                    // Find the user node
                    XmlNode userNode = null;
                    XmlNodeList userNodes = xmlDoc.SelectNodes("/Accounts/User");

                    // Find the specific user
                    foreach (XmlNode parsedUser in userNodes)
                    {
                        string accountUsername = parsedUser.SelectSingleNode("Username").InnerText;
                        if (accountUsername == userName)
                        {
                            userNode = parsedUser;
                            break;
                        }
                    }

                    // If user found, add purchase data
                    if (userNode != null)
                    {
                        // Check if UserPurchases node exists, create if not
                        XmlNode purchasesNode = userNode.SelectSingleNode("UserPurchases");
                        if (purchasesNode == null)
                        {
                            purchasesNode = xmlDoc.CreateElement("UserPurchases");
                            userNode.AppendChild(purchasesNode);
                        }

                        // Create a new Purchase element
                        XmlElement newPurchase = xmlDoc.CreateElement("Purchase");

                        // Create and set the purchase details
                        XmlElement bookElement = xmlDoc.CreateElement("BookTitle");
                        bookElement.InnerText = bookTitle;

                        XmlElement priceElement = xmlDoc.CreateElement("Price");
                        priceElement.InnerText = price.ToString();

                        XmlElement dateElement = xmlDoc.CreateElement("PurchaseDate");
                        dateElement.InnerText = purchaseDate;

                        // Append details to the purchase
                        newPurchase.AppendChild(bookElement);
                        newPurchase.AppendChild(priceElement);
                        newPurchase.AppendChild(dateElement);

                        // Add the purchase to the user's purchases
                        purchasesNode.AppendChild(newPurchase);

                        // Save the changes to the XML file
                        xmlDoc.Save(xmlPath);

                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error adding purchase: {e.Message}");
                }
            }

            // If username doesn't exist or there was an error
            return false;
        }

        // Add a method to retrieve user purchase history
        public List<string[]> getUserPurchases(string userName)
        {
            List<string[]> purchases = new List<string[]>();

            if (userNameExists(userName))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlPath);

                    XmlNode userNode = null;
                    XmlNodeList userNodes = xmlDoc.SelectNodes("/Accounts/User");

                    // Find the specific user
                    foreach (XmlNode parsedUser in userNodes)
                    {
                        string accountUsername = parsedUser.SelectSingleNode("Username").InnerText;
                        if (accountUsername == userName)
                        {
                            userNode = parsedUser;
                            break;
                        }
                    }

                    if (userNode != null)
                    {
                        XmlNode purchasesNode = userNode.SelectSingleNode("UserPurchases");
                        if (purchasesNode != null)
                        {
                            XmlNodeList purchaseNodes = purchasesNode.SelectNodes("Purchase");
                            foreach (XmlNode purchase in purchaseNodes)
                            {
                                string title = purchase.SelectSingleNode("BookTitle").InnerText;
                                string price = purchase.SelectSingleNode("Price").InnerText;
                                string date = purchase.SelectSingleNode("PurchaseDate").InnerText;

                                purchases.Add(new string[] { title, price, date });
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error retrieving purchases: {e.Message}");
                }
            }

            return purchases;
        }

        public string getUserType(string userName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.Load(xmlPath);
                XmlNodeList userNodes = xmlDoc.SelectNodes("/Accounts/User");

                foreach (XmlNode parsedUser in userNodes)
                {
                    string accountUsername = parsedUser.SelectSingleNode("Username")?.InnerText;
                    string accountType = parsedUser.SelectSingleNode("AccountType")?.InnerText;

                    if (accountUsername == null || accountType == null)
                    {
                        continue;
                    }

                    if (accountUsername == userName)
                    {
                        return accountType;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            return "UserNotFoundError";
        }




        //DEBUG FUNCTION` [Delete before final version/before developments]
        public string debugFunct(){

           //Parse the XML file for the username, if it exists [True]
              try{
                //Create an XML Document Object
                  XmlDocument xmlDoc = new XmlDocument();

                //Load the XML doc via the Path
                  xmlDoc.Load(xmlPath);

                //Get a list of nodes from the XML document
                  XmlNodeList userNodes = xmlDoc.SelectNodes("/Accounts/User");


                //Parse Each 'User' until the corresponding username is hit
                  foreach(XmlNode parsedUser in userNodes){

                    //Collect the information from the selected user
                      string accountUsername = parsedUser.SelectSingleNode("Username").InnerText;
                      string accountPassword = parsedUser.SelectSingleNode("Password").InnerText;
                      string accountType = parsedUser.SelectSingleNode("AccountType").InnerText;


          //Print the user information (DEBUG!!)
              return (accountUsername + accountPassword + accountType);

                  }

              }
            //Error
              catch(Exception e){Console.WriteLine("Username Exists, Error!");}

          return "Error";
        }
      //-------------------------------------------------------------------------------
    }
}
