using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Sitecore_UITest.PageObjects;
using FluentAssertions;

namespace Sitecore_UITest.Tests
{
    [TestFixture]

    public partial class TestBase
    {
        IWebDriver driver = null;
        PageBase pageBase = null;
        MainPage mainPage = null;
        ViewCarListingPage carListingPage = null;
        
        public static void Main(string[] args)
        {

        }
       
        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            pageBase = new PageBase(driver);
            mainPage = new MainPage(driver);
            carListingPage = new ViewCarListingPage(driver);
            pageBase.OpenUrl("https://www.carlist.my/");
            mainPage.IsHomePageLoaded().Should().BeTrue();
        }

        [TearDown]
        public void cleanUp()
        {
            driver.Quit();
        }
    }
}
