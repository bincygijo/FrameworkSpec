using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyFramework.Pages
{
    class Crossbrowser
    {
        public void CheckCrossBrowser()
        {
            IWebDriver driver;
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("browserName", "iPhone");
            capability.SetCapability("device", "iPhone 7");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "10.3");
            capability.SetCapability("browserstack.user", "sarasavio1");
            capability.SetCapability("browserstack.key", "J5EC46zJzRx1yww7HkxQ");

            driver = new RemoteWebDriver(
              new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
            driver.Navigate().GoToUrl("http://www.google.com");
            Console.WriteLine(driver.Title);

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Browserstack");
            query.Submit();
            Console.WriteLine(driver.Title);

            driver.Quit();
        }
    }
}
