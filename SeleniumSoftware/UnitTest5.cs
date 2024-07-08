using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumSoftware
{
    [TestClass]
    public class CalculatorTests
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
        public void TestCalculatorOperations()
        {
            try
            {
                // Navigate to Calculator.net
                driver.Navigate().GoToUrl("http://www.calculator.net");

                // Click on the elements corresponding to 5, *, 5, =
                ClickButtonByClass("scinm", "5");
                ClickButtonByClass("sciop", "×"); // Multiplication symbol
                ClickButtonByClass("scinm", "5");
                ClickButtonByClass("scieq", "="); // Equals button

                // Retrieve the result and assert the calculation
                string resultText = GetCalculatorOutput();
                Assert.AreEqual("25", resultText.Trim());

                // Clear the calculator for the next operation
                ClickButtonByClass("scieq", "AC");

                // Perform the next operation: 50 - 50
                ClickButtonByClass("scinm", "5");
                ClickButtonByClass("sciop", "–"); // Minus symbol (adjusted from '-')
                ClickButtonByClass("scinm", "5");
                ClickButtonByClass("scieq", "="); // Equals button

                // Retrieve the result and assert the calculation
                resultText = GetCalculatorOutput();
                Assert.AreEqual("0", resultText.Trim());
            }
            finally
            {
                //driver.Quit();
            }
        }

        private string GetCalculatorOutput()
        {
            // Wait for the calculator output to be visible
            IWebElement outputElement = wait.Until(drv => drv.FindElement(By.Id("sciOutPut")));

            // Return the text of the output element
            return outputElement.Text.Trim();
        }

        private void ClickButtonByClass(string className, string buttonText)
        {
            // Construct the XPath for the button based on class name and button text
            string xpath = $"//span[contains(@class, '{className}') and normalize-space(text())='{buttonText}']";

            try
            {
                // Wait for the button to be clickable and click it
                IWebElement button = wait.Until(drv => drv.FindElement(By.XPath(xpath)));
                button.Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                // Handle timeout exception with custom message
                Console.WriteLine($"Timeout while waiting for element with XPath: {xpath}");
                throw;
            }
            catch (NoSuchElementException ex)
            {
                // Handle no such element exception with custom message
                Console.WriteLine($"Element not found with XPath: {xpath}");
                throw;
            }
        }
    }
}
