using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Selenium2Demo
{
    [TestFixture]
    public class HemnetSpecs
    {
        [Test]
        public void Yeah()
        {
            using (var page = OpenPage(@"http://www.hemnet.se/"))
            {
                page.FindElement(By.Id("search_item_types_tomt")).Click();
                page.FindElement(By.Id("search_item_types_villa")).Click();
                page.FindElement(By.Id("search_item_types_fritidshus")).Click();

                // We must do the selection before interacting with the list, otherwise we will get an error
                var countyList = page.FindElement(By.Id("search_municipality"));
                var countyLabel = countyList.FindElement(By.XPath("//label[contains(.,'Håbo kommun')]"));
                var countyInput = countyLabel.FindElement(By.TagName("input"));

                countyList.Click(); // We must make the "option" visible before clicking on it, otherwise it will fail
                countyInput.Click(); // Selecting the option

                page.FindElementById("search_submit").Submit();

                var sortByList = new SelectElement(page.FindElement(By.Id("search-results-sort-by")));
                sortByList.SelectByText("Inkommet");

                var sortOrderList = new SelectElement(page.FindElement(By.Id("search-results-sort-order")));
                sortOrderList.SelectByText("Nyast först");

                Assert.That("yeah", Is.EqualTo("yeah"));
            }
        }

        private RemoteWebDriver OpenPage(string url)
        {
            var profile = new FirefoxProfile();
            profile.AddExtension("firebug-1.6.2.xpi");
            profile.SetPreference("extensions.firebug.currentVersion", "9.99");
            RemoteWebDriver driver = new FirefoxDriver(profile);
            driver.Navigate().GoToUrl(url);
            return driver;
        }
    }
}
