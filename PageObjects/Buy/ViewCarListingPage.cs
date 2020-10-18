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
        private By CarPriceTitle = By.CssSelector("body.theme.theme--my.body__has-element-sticky-bottom.theme--listing-detail:nth-child(2) div.relative:nth-child(4) div.details div.container.container--details.cf article.listing.listing--details.article--details.relative.push--bottom.push--top.js--listing.cf div.grid:nth-child(5) div.grid__item.seven-tenths.lap-one-whole.palm-one-whole:nth-child(1) div.listing__section.listing__section--head.push-half--bottom:nth-child(1) div.grid div.grid__item.five-twelfths.lap-one-half.visuallyhidden--palm.text--right:nth-child(2) > div.listing__price.delta.weight--bold");

        //######### Function Definition #################

        public bool ClickOnCarListingImage(int column)
        {
            var carList = By.XPath($"/html/body/main/div[4]/div/div/div/div/section/article[{column}]/div/header/div[1]/a/img");
            return actions.ClickElement(carList);
        }

        public decimal GetCarPrice()
        {
            var price = ParseCurrencytoNumber(actions.GetTextFromElement(CarPriceTitle));
            Debug.WriteLine(price);
            return price;
        }

        public string GetListingLabelCategory(int column)
        {
            var labelCategory = By.XPath($"//body[1]/main[1]/div[4]/div[1]/div[1]/div[1]/div[1]/section[1]/article[{column}]/div[1]/header[1]/div[2]/div[1]");
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
