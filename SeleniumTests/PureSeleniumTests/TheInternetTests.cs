using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PureSeleniumTests
{
    internal class TheInternetTests : BaseTests
    {
        protected override string Url => "http://the-internet.herokuapp.com/";

        [Test]
        public void LocatorsTestLinkText()
        {
            IWebElement navigateAlertsPage = Driver.FindElement(By.LinkText("JavaScript Alerts"));
            IWebElement navigateAlertsPage2 = Driver.FindElement(By.PartialLinkText("Alerts"));
            Assert.That(navigateAlertsPage.Text, Is.EqualTo("JavaScript Alerts"));
            Assert.That(navigateAlertsPage2.Text, Is.EqualTo("JavaScript Alerts"));
        }
    }
}
