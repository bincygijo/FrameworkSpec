using KeyFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static KeyFramework.Global.CommonMethods;

namespace KeyFramework.Pages
{
    class MarketPlace
    {
        public string BusinessName { get; set; }
        public string PhoneNumber { get; set; }
        public string SearchAddress { get; set; }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var MarketDetails = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                MarketDetails.Add(row[0], row[1]);
            }
            return MarketDetails;
        }

        internal void ApplyJob()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Marketplace");

            try
            {
                //Navigate to Market place
                Driver.ActionButton(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"));
                Thread.Sleep(2000);

                //Search Job
              //*...................................//
              //Searching data and click apply button-- pagination
                var i = 2;
                while (true)
                {
                    for (int j = 1; j < 10; j++)
                    {
                        var Title = Driver.driver.FindElement(By.XPath("//*[@id='mainPage']/div[4]/div[3]/div[2]/a")).Text;
                                                                                          
                        if (Title == "this is title 7")
                        {
                            Console.WriteLine("title" + Title);
                            var action = Driver.driver.FindElement(By.XPath("//*[@id='mainPage']/div[4]/div[8]/div[3]/div/div/button"));
                             action.Click();
                            return;
                         
                           
                        }
                   

                    }
                  Driver.driver.FindElement(By.XPath("//div[@class='pagedList text-center']//li[@class='PagedList-skipToNext']/a")).Click();
                  i++;

                    
                    //*..........................//

                   }
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, e.Message);
            }

            
              



        }
    }



   
}
