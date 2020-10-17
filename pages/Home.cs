using OpenQA.Selenium;
using SeleniumFramework.util;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SeleniumFramework.pages
{
    class Home
    {
        //########## Setup ############
        private IWebDriver driver = null;
        private Util util = null;
        public Home(IWebDriver d)
        {
            this.driver = d;
            util = new Util(d);
        }
        //########### Element Definition #############
        private By searchButton = By.XPath("/html/body/main/div[2]/div[2]/div[1]/div/div/div[2]/form/div[7]/button");
        private By carListing = By.XPath("//body/main[1]/div[4]/div[1]/ol[1]/li[2]");
        private By sellerComment = By.XPath("//*[@id='listing_7165726']/div[2]/div[3]/div[2]/div[1]/div/div[1]/h2");

        // Checkbox
        private By allConditionCheckBox = By.XPath("//body/main[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[2]/form[1]/div[1]/div[1]/label[1]");
        private By usedCheckBox = By.XPath("//body/main[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[2]/form[1]/div[1]/div[2]/label[1]");

        //######### Function Definition #################

        public bool clickOnCarListingImage(int column)
        {
            var carList = By.XPath($"//body[1]/main[1]/div[4]/div[1]/div[1]/div[1]/div[1]/section[1]/article[{column}]/div[1]/header[1]/div[1]/a[1]/img[1]");
            return util.ClickElement(carList);
        }

        public decimal getCarPrice(int column)
        {
            var pricelistingColumn = By.XPath($"/html/body/main/div[2]/div/div/article[{column}]/div[2]/div[1]/div[1]/div/div[2]/div[2]");
            var price = parseCurrencytoNumber(util.GetTextFromElement(pricelistingColumn));
            Debug.WriteLine(price);
            return price;
        }

        public bool clickCheckBox(string checkboxName)
        {
            if (checkboxName == "All Condition")
            {
                return util.ClickElement(allConditionCheckBox);
            }
            else if (checkboxName == "Used")
            {
                return util.ClickElement(usedCheckBox);
            }
            else
            {
                return false;
            }
        }

        public bool isHomePageLoaded()
        {
            return util.IsElementVisible(searchButton);
        }
       
        public bool isCarListingPageLoaded()
        {
            return util.IsElementVisible(carListing);
        }

        public bool isCarDetailsPageLoaded()
        {
            return util.IsElementVisible(sellerComment);
        }

        public bool clickSearchButton()
        {
            return util.ClickElement(searchButton);
        }

        public void openUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.FullScreen();
        }

        public decimal parseCurrencytoNumber(string input)
        {
            return decimal.Parse(Regex.Replace(input, @"[^\d.]", ""));
        }
    }
}
