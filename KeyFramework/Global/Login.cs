using KeyFramework.Config;
using KeyFramework.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KeyFramework.Global.CommonMethods;

namespace KeyFramework.Global
{
     class Login
    {
        public static int LoginBase = Int32.Parse(KeyResource.Login);
      
        public void LoginSuccessfull()
        {

            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Login");

            // Navigating to Login page using value from Excel
            // Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(LoginBase, "Url"));

            // Sending the username 

            // Driver.Textbox(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"), ExcelLib.ReadData(2, "InputValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"), ExcelLib.ReadData(LoginBase, "Email"));
            Driver.wait(500);

            // Sending the password
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"), ExcelLib.ReadData(LoginBase, "Password"));
            //Driver.Textbox(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"), ExcelLib.ReadData(3, "InputValue"));

            // Clicking on the login button

            // Driver.ActionButton(Driver.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "LocatorValue"));
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "LocatorValue"));
            //Thread.Sleep(2000);


        }

    }
}
