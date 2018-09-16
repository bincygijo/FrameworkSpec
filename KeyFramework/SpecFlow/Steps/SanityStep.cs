using KeyFramework.Config;
using KeyFramework.Global;
using KeyFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static KeyFramework.Global.CommonMethods;

namespace KeyFramework.SpecFlow.Steps
{
    [Binding]
    public class SanityStep:Global.Base
    {
       [Given(@"I have logged into Key application page")]
        public void GivenIHaveLoggedIntoKeyApplicationPage()
        {
            test = extent.StartTest("Validating Dashboard");
            //Adding screenshot in extendReport
            string screenShotPath = CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Login");
            Base.test.Log(LogStatus.Pass, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath));

            Driver.driver.Navigate().Refresh();

        }

        [Then(@"I should see properties dashboard page")]
        public void ThenIShouldSeePropertiesDashboardPage()
        {
            //Creating object for property class 
            test = extent.StartTest("Dashboard opened");
         
            //Adding screenshot in extendReport
            string screenShotPath = CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Owner");
            Base.test.Log(LogStatus.Pass, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath));
        }



       [When(@"I click Market Place I can see all the jobs and apply jobs")]
        public void WhenIClickMarketPlaceICanSeeAllTheJobsAndApplyJobs()
        {
            test = extent.StartTest("Validating Marketplace");
            MarketPlace ObjMar = new MarketPlace();
            ObjMar.ApplyJob();
        }

        [When(@"I fill all the mandatory details on apply job application")]
        public void WhenIFillAllTheMandatoryDetailsOnApplyJobApplication(Table table)
        {
            MarketPlace details = table.CreateInstance<MarketPlace>();
            var MarketDetails = MarketPlace.ToDictionary(table);

            //Enter Amount
            Driver.driver.FindElement(By.XPath("//*[@id='applyDetail']/div/div[4]/form/div[1]/div[1]/input")).SendKeys(MarketDetails["Amount"]);
            Thread.Sleep(2000);

            //Enter Note
            Driver.driver.FindElement(By.XPath("//*[@id='applyDetail']/div/div[4]/form/div[2]/div[1]/textarea")).SendKeys(MarketDetails["Note"]);
            Thread.Sleep(2000);
                       
        }

        [Then(@"I click submit button page navigate to marketplace page with successful message")]
        public void ThenIClickSubmitButtonPageNavigateToMarketplacePageWithSuccessfulMessage()
        {
            //click submit button
            Driver.driver.FindElement(By.XPath("//div[@class='field text-center']/button[1]")).Click();
            Thread.Sleep(2000);

            //Adding screenshot in extendReport
            string screenShotPath1 = CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Marketplace");
            Base.test.Log(LogStatus.Pass, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath1));
        }

        

        //[Then(@"I fill all the details on the page")]
        //public void ThenIFillAllTheDetailsOnThePage(Table table)
        //{
        //    MarketPlace details = table.CreateInstance<MarketPlace>();
        //    var MarketDetails = MarketPlace.ToDictionary(table);

        //    //Google Autofilling Address//Search Address
        //    Driver.driver.FindElement(By.XPath("//*[@id='autocomplete']")).SendKeys(MarketDetails["SearchAddress"]);
        //    Thread.Sleep(2000);
        //    new Actions(Driver.driver).SendKeys(Keys.ArrowDown).Perform();
        //    Thread.Sleep(5000);
        //    new Actions(Driver.driver).SendKeys(Keys.Enter).Perform();
        //    Thread.Sleep(5000);

           
            

        //}




    }
}
