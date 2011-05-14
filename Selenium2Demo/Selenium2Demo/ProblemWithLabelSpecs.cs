using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Selenium2Demo
{
    [TestFixture]
    class ProblemWithLabelSpecs
    {
        private RemoteWebDriver driver;

        [Test]
        public void Should_be_able_to_read_text_from_label_when_content_is_more_than_just_text()
        {
            var pagePath = Path.Combine(Environment.CurrentDirectory, "markup.html");

            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(pagePath);

            var container = driver.FindElement(By.ClassName("some-class"));
            var labels = container.FindElements(By.TagName("label"));

            // This works:
            Assert.That(labels[0].GetAttribute("class"), Is.EqualTo("some-other-class"));

            // But not this:
            Assert.That(labels[0].Text, Is.EqualTo("Alla kommuner"));
        }

        [TearDown]
        public void After()
        {
            if(driver != null)
            {
                driver.Close();
            }
        }
    }
}
