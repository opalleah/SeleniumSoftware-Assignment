using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumSoftware
{
    [TestClass]
    public class TradeMeITSearch
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup()
        {
            // Initialize Chrome WebDriver
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            // Maximize the browser window
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TradeMeSearchITJobs()
        {
            try
            {
                // Navigate to Trade Me website
                driver.Navigate().GoToUrl("https://www.trademe.co.nz/a/");

                // Wait for the search input element to be clickable
                IWebElement searchInput = wait.Until(drv => drv.FindElement(By.Id("search")));
                searchInput.Click();
                // Type "IT jobs" into the search input
                searchInput.SendKeys("IT jobs");

                // Simulate pressing the Enter key (optional)
                searchInput.SendKeys(Keys.Enter);

            }
            finally
            {
               // driver.Quit();
            }
        }
    }
}
