using OpenQA.Selenium;
using Sitecore_UITest.ControlObjects;

namespace Sitecore_UITest.PageObjects

{
    public class MainPage : PageBase
    {
        private IWebDriver driver = null;
        private Actions actions = null;

        public MainPage(IWebDriver d)
        {
            driver = d;
            actions = new Actions(d);
        }

        //########### Element Definition #############
        private By SearchButton = By.XPath("/html/body/main/div[2]/div[2]/div[1]/div/div/div[2]/form/div[7]/button");

        // Checkbox
        private By AllConditionCheckBox = By.XPath("//body/main[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[2]/form[1]/div[1]/div[1]/label[1]");
        private By UsedCheckBox = By.XPath("//body/main[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[2]/form[1]/div[1]/div[2]/label[1]");

        //######### Function Definition #################

        public bool IsHomePageLoaded()
        {
            return actions.IsElementVisible(SearchButton);
        }

        public bool ClickSearchButton()
        {
            return actions.ClickElement(SearchButton);
        }

        public bool ClickCheckBox(string checkboxName)
        {
            if (checkboxName == "All Condition")
            {
                return actions.ClickElement(AllConditionCheckBox);
            }
            else if (checkboxName == "Used")
            {
                return actions.ClickElement(UsedCheckBox);
            }
            else
            {
                return false;
            }
        }
    }
}
