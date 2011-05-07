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
            var profile = new FirefoxProfile();
            /*var firebugPath = Path.Combine(Environment.CurrentDirectory, "firebug-1.6.2.xpi");
            profile.AddExtension(firebugPath);*/

            RemoteWebDriver driver = new FirefoxDriver(profile);
            driver.Navigate().GoToUrl(@"http://www.hemnet.se/");

            driver.FindElement(By.Id("search_item_types_tomt")).Click();
            driver.FindElement(By.Id("search_item_types_villa")).Click();
            driver.FindElement(By.Id("search_item_types_fritidshus")).Click();

            // We must do the selection before interacting with the list, otherwise we will get an error
            var countyList = driver.FindElement(By.Id("search_municipality"));
            var countyLabel = countyList.FindElement(By.XPath("//label[contains(.,'Håbo kommun')]"));
            var countyInput = countyLabel.FindElement(By.TagName("input"));

            countyList.Click(); // We must make the "option" visible before clicking on it, otherwise it will fail
            countyInput.Click(); // Selecting the option

            driver.FindElementById("search_submit").Submit();

            var sortByList = new SelectElement(driver.FindElement(By.Id("search-results-sort-by")));
            sortByList.SelectByText("Inkommet");

            var sortOrderList = new SelectElement(driver.FindElement(By.Id("search-results-sort-order")));
            sortOrderList.SelectByText("Nyast först");

            driver.Close();
        }
    }
}
