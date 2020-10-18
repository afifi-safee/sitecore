using NUnit.Framework;
using FluentAssertions;
using System.Diagnostics;

namespace Sitecore_UITest.Tests
{
    [TestFixture]

    public partial class  TestBase
    {
        [Test]
        public void TestVerifyUsedCar_ListingPriceMoreThan1000_Successful()
        {
            var listNumber = 1;
            mainPage.ClickCheckBox("Used");
            mainPage.ClickSearchButton();
            carListingPage.IsCarListingPageLoaded();
            pageBase.GetCurrentUrl().Should().BeEquivalentTo("https://www.carlist.my/used-cars-for-sale/malaysia");
            
            //Workaround if first listing was sale item, need to select second listing. No price will be given for sale item
            for (var i =1; i<5; i++)
            {
                if (string.Equals(carListingPage.GetListingLabelCategory(i), "Featured"))
                {
                    listNumber = i;
                    break;
                }
            }
            carListingPage.ClickOnCarListingImage(listNumber);
            carListingPage.IsCarDetailsPageLoaded();
            carListingPage.GetCarPrice().Should().BeGreaterThan(1000);            
        }
    }
}
