using OpenQA.Selenium;
using Sitecore_UITest.ControlObjects;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Sitecore_UITest.PageObjects
{
    public class ViewCarListingPage : PageBase
    {
        private IWebDriver driver = null;
        private Actions actions = null;

        public ViewCarListingPage(IWebDriver d)
        {
            driver = d;
            actions = new Actions(d);
        }

        //########### Element Definition #############
        private By CarListing = By.XPath("//body/main[1]/div[4]/div[1]/ol[1]/li[2]");
        private By SellerInformation = By.XPath("//h2[contains(text(),'Seller Information')]");

        //######### Function Definition #################

        public bool ClickOnCarListingImage(int column)
        {
            var carList = By.XPath($"/html/body/main/div[4]/div/div/div/div/section/article[{column}]/div/header/div[1]/a/img");
            return actions.ClickElement(carList);
        }

        public decimal GetCarPrice(int column)
        {
            var pricelistingColumn = By.XPath($"/html/body/main/div[2]/div/div/article[{column}]/div[2]/div[2]/div[2]/div[1]/div[2]");
            var price = ParseCurrencytoNumber(actions.GetTextFromElement(pricelistingColumn));
            Debug.WriteLine(price);
            return price;
        }

        public string GetListingLabelCategory(int column)
        {
            var labelCategory = By.XPath($"//body[1]/main[1]/div[5]/div[1]/div[1]/div[1]/div[1]/section[1]/article[{column}]/div[1]/header[1]/div[2]/div[1]/span[1]");
            return actions.GetTextFromElement(labelCategory);
        }

        public bool IsCarListingPageLoaded()
        {
            return actions.IsElementVisible(CarListing);
        }

        public bool IsCarDetailsPageLoaded()
        {
            return actions.IsElementVisible(SellerInformation);
        }

        public decimal ParseCurrencytoNumber(string input)
        {
            return decimal.Parse(Regex.Replace(input, @"[^\d.]", ""));
        }
    }
}
