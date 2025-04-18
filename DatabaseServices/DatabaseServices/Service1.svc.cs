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


      /*[TODO]:

        - Set the "Hello!" text to the relevant text/template for the files [XSD & XML]!
      
        - //Here
      
      */


      //Global Variables
      //--------------------------------------------------------------------------------------------------

//[FIX THIS PATH]!!
        //Path to the XML file
          string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "userData.xml");
      //--------------------------------------------------------------------------------------------------


      //Method Definitions
      //-------------------------------------------------------------------------------
        
        //Store incoming user information to the XML file/Database
          public bool createUser(string userName, string userPassword, string accountType){

            //If the userName doesn't already exist, proceed
              if(!userNameExists(userName)){
                //Insert/Inject the user's information into the XML file!


                //Successful operation
                  return true;
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
                      string accountPassword = parsedUser.SelectSingleNode("Password").InnerText;
                      string accountType = parsedUser.SelectSingleNode("AccountType").InnerText;


                    //DEBUG!!
                      //Return the information as a string!! (TEMPORARY FOR DEBUG!!)
                      


                  }


              }
            //Error
              catch(Exception e){Console.WriteLine("Username Exists, Error!");}
              

            //Else, username does NOT exist
              return false;
          }


      //User Login
        public bool userLogin(string userName, string encryptedPassword){
          
          //Proceed if the username exists
            if(userNameExists(userName)){

              //Password Correctness check
                bool correctPassword = true;

              //Correct Password
               // if(){
                  //User Successfully logged in
                //    return true;
               // }

              //Incorrect password, proceeds until 'return false below'
            }


          //Unsucessful login
            return false;
        }
      //-------------------------------------------------------------------------------
    }
}
