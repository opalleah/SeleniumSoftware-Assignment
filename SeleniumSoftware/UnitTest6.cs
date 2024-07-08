using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumSoftware
{
    [TestClass]
    public class TradeMeInternalLinks
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup()
        {
            // Initialize Chrome WebDriver
            driver = new ChromeDriver();

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Initialize WebDriverWait with a timeout of 3 seconds
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        [TestMethod]
        public void TestInternalLinksContainingKeywords()
        {
            try
            {
                // Navigate to Trade Me website
                driver.Navigate().GoToUrl("https://www.trademe.co.nz/a/");

                // Wait for some time to ensure the page is fully loaded
                System.Threading.Thread.Sleep(2000); // 2 seconds

                // Find all <a> elements on the page
                IReadOnlyCollection<IWebElement> allLinks = driver.FindElements(By.TagName("a"));

                // List to store internal links containing 'property' or 'services'
                List<string> internalLinks = new List<string>();

                foreach (IWebElement link in allLinks)
                {
                    string href = link.GetAttribute("href");

                    // Check if link is not null, not empty, and starts with the base URL
                    if (!string.IsNullOrEmpty(href) && href.StartsWith("https://www.trademe.co.nz/"))
                    {
                        // Check if the link contains 'property' or 'services'
                        if (href.Contains("property") || href.Contains("services"))
                        {
                            internalLinks.Add(href);
                        }
                    }
                }

                // Output the internal links containing 'property' or 'services'
                Console.WriteLine("Internal links containing 'property' or 'services':");
                foreach (string link in internalLinks)
                {
                    Console.WriteLine(link);
                }
            }
            finally
            {
                //driver.Quit();
            }
        }
    }
}
