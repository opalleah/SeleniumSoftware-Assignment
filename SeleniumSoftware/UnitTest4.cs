using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumSoftware
{
    [TestClass]
    public class TradeMeResidentialSearch
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup()
        {
            // Initialize Chrome WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); // Maximize the browser window

            // Initialize WebDriverWait with a timeout of 3 seconds
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        [TestMethod]
        public void ClickSearchButton()
        {
            try
            {
                // Navigate to the specific page
                driver.Navigate().GoToUrl("https://www.trademe.co.nz/a/property/residential/sale");

                // Wait for the search button to be clickable
                IWebElement searchButton = wait.Until(drv => drv.FindElement(By.XPath("//button[@title='Search']")));

                // Click on the search button
                searchButton.Click();

                // Optionally, wait for some time or perform further actions
                System.Threading.Thread.Sleep(3000); // Example: wait for 3 seconds

                // Assertion or further actions can be added here
                Assert.IsTrue(driver.Url.Contains("/property/residential/sale"));
            }
            finally
            {
                //driver.Quit();
            }
        }
    }
}
