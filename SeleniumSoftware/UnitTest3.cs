using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSoftware
{
    [TestClass]
    public class TradeMeExternalLinks
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            // Initialize Chrome WebDriver
            driver = new ChromeDriver();

            // Maximize the browser window
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void ListExternalLinksOnTradeMe()
        {
            // Navigate to Trade Me website
            driver.Navigate().GoToUrl("https://www.trademe.co.nz/a/");

            // Find all <a> elements
            IReadOnlyCollection<IWebElement> allLinks = driver.FindElements(By.TagName("a"));

            // Initialize a list to store external links
            List<string> externalLinks = new List<string>();

            // Iterate through each <a> element
            foreach (IWebElement link in allLinks)
            {
                // Get the value of the href attribute
                string href = link.GetAttribute("href");

                // Check if the href attribute exists and if it is an external link
                if (!string.IsNullOrEmpty(href) && IsExternalLink(href))
                {
                    externalLinks.Add(href);
                }
            }

            // Print all external links found
            Console.WriteLine("External Links:");
            foreach (string link in externalLinks)
            {
                Console.WriteLine(link);
            }
        }

        private bool IsExternalLink(string url)
        {
            // Check if the URL starts with "http" or "https" and does not contain "trademe.co.nz"
            return url.StartsWith("http") && !url.Contains("trademe.co.nz");
        }
    }
}
