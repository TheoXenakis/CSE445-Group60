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
          public bool createAccount(string userName, string userPassword, string accountType){

            //XML file exists, continue to add information
              if(File.Exists("userData.xml")){
                
  

              }
            //XML file DNE, create & add parameters
              else{

                //Write the contents into the new file(s) necessary for XML
                  try{
                    //Define the path for [XSD]
                      string xsdPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userData.xsd");
    

                    //Define the path for [XML]
                      string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userData.xml");
    

                    //Set-up/Write to the .XSD (Defines the XML document)
                    //  File.WriteAllText(xsdPath, "Hello!");


                    //Set-up/Write to the .XML  (Stores data)
                    //  File.WriteAllText(xmlPath, "Hello!");
                  }
                //Catch any Errors in creation
                  catch(Exception e){
                    //Print error  
                      Console.WriteLine("Error!");
                  
                    //Unsuccessful operation
                      return false;
                  }
              }


            //Successful Data Operation
              return true;
          }


        //See if a user exists within the XML file/Database
          public bool userNameExists(string userName){
            //Parse the XML file for the userName
              //if(){

              //}

              return false;

          }
      //-------------------------------------------------------------------------------
    }
}
