using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Sitecore_UITest.ControlObjects
{
    public class Actions
    {
        private IWebDriver driver = null;
        public Actions(IWebDriver d)
        {
            driver = d;
        }

        public IWebElement WaitForElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        public bool ClickElement(By locator)
        {
            bool returnValue = false;
            try
            {
                WaitForElementVisible(locator).Click();
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + e.Message + locator + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        public string GetTextFromElement(By locator)
        {
            string returnValue = "";
            try
            {
                returnValue = WaitForElementVisible(locator).Text;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
            }
            return returnValue;
        }

        public bool IsElementVisible(By locator)
        {
            bool returnValue = false;
            try
            {
                returnValue=WaitForElementVisible(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue=false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }
    }
}
