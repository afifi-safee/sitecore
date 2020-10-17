using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumFramework.pages;
using FluentAssertions;
using System.Diagnostics;

namespace SeleniumFramework.tests
{
    [TestFixture]

    class testClass
    {
        IWebDriver driver = null;
        GettingStarted gettingStarted = null;
        Home home = null;
        public static void Main(string[] args)
        {

        }
       
        [OneTimeSetUp]
        public void initialize()
        {
            driver = new ChromeDriver();
            gettingStarted = new GettingStarted(driver);
            home = new Home(driver);
        }

        [Test]
        public void TestVerifyUsedCarListing_RefreshPage_Successful()
        {
            home.openUrl("https://www.carlist.my/");
            home.isHomePageLoaded().Should().BeTrue();
            home.clickCheckBox("Used");
            home.clickSearchButton();
            home.isCarListingPageLoaded();
            home.clickOnCarListingImage(1);
            home.isCarDetailsPageLoaded();
            home.getCarPrice(1).Should().BeGreaterThan(1000);            
        }

        [OneTimeTearDown]
        public void cleanUp()
        {
            driver.Quit();
        }
    }
}
