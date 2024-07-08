using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumSoftware
{
    [TestClass]
    public class TaupoWeather
    {
        [TestMethod]
        public void TestMethod1()
        {
           
            IWebDriver driver = new ChromeDriver();
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            try
            {
                driver.Navigate().GoToUrl("https://www.google.co.nz");

                // Wait for the search box element to be present and visible
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement searchBox = wait.Until(drv => drv.FindElement(By.Name("q"))); // Renamed parameter to 'drv'

                // Perform the search
                searchBox.SendKeys("Taupo weather");
                searchBox.SendKeys(Keys.Enter);

            }
            finally
            {
                //driver.Quit();
            }
        }
    }
}