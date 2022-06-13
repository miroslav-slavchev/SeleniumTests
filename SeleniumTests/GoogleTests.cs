using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class GoogleTests : BaseTests
    {
        protected override string Url => @"https://www.google.com/";

        [Test]
        [Description("Search Selenium in Google")]
        public void FirstGoogleTest()
        {
            IWebElement acceptButton = Driver.FindElement(By.CssSelector("#L2AGLb"));
            acceptButton.Click();

            IWebElement searchInput = Driver.FindElement(By.Name("q"));
            searchInput.SendKeys("Selenium Wikipedia");
            
            Thread.Sleep(2000); // Wait 2 seconds

            IWebElement searchButton = Driver.FindElement(By.Name("btnK"));
            searchButton.Click();

            Thread.Sleep(3000); // Wait 3 seconds
            var firstResult = Driver.FindElement(By.CssSelector("h3"));
            Assert.That(firstResult.Text, Is.EqualTo("Selenium - Wikipedia")); // True
        }
    }
}
