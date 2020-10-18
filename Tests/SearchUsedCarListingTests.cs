using NUnit.Framework;
using FluentAssertions;

namespace Sitecore_UITest.Tests
{
    [TestFixture]

    public partial class  TestBase
    {
        [Test]
        public void TestVerifyUsedCarListing_MoreThan1000_Successful()
        {
            var listNumber = 0;
            mainPage.ClickCheckBox("Used");
            mainPage.ClickSearchButton();
            carListingPage.IsCarListingPageLoaded();
            pageBase.GetCurrentUrl().Should().BeEquivalentTo("https://www.carlist.my/used-cars-for-sale/malaysia");
   

            carListingPage.ClickOnCarListingImage(listNumber);
            carListingPage.IsCarDetailsPageLoaded();
            carListingPage.GetCarPrice(listNumber).Should().BeGreaterThan(1000);            
        }
    }
}
