using OpenQA.Selenium;
using Sitecore_UITest.ControlObjects;

namespace Sitecore_UITest.PageObjects
{
    public class PageBase
    {
        private IWebDriver driver = null;
        private Actions actions = null;

        //########### Element Definition #############

        //######### Function Definition #################

        public PageBase(IWebDriver d)
        {
            driver = d;
            actions = new Actions(d);
        }
       
        public PageBase() 
        { }

        public string GetCurrentUrl()
        {
            return driver.Url;
        }

        public void OpenUrl(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
    }
}
