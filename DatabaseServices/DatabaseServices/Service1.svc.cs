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


      //Method Definitions
      //-------------------------------------------------------------------------------
        
        //Store incoming user information to the XML file/Database
          public bool storeUserInfo(string userName, string userPassword){

            //XML file exists, continue to add information
              if(File.Exists("userData.xml")){
                //

                //Successful Data operation
                  return true;
              }
            //XML file DNE, create & add parameters
              else{
                //Templated content of the XML file
                  //Code here...


                //Create the new file
                  File.WriteAllText("userData.xml", "It works!!");


                //Successful Data operation
                  return true;
              }

            //Other Error has occured
              return false;
          }


        //See if a user exists within the XML file/Database
          public bool userExists(string userName){
            //Parse the XML file for the userName
              //if(){

              //}

              return false;

          }
      //-------------------------------------------------------------------------------
    }
}
