using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PureSeleniumTests
{
    internal class TheInternetLinkText : BaseTests
    {
        protected override string Url => @"http://the-internet.herokuapp.com/";

        [Test]
        public void LocateAlerts()
        {
            var element = Driver.FindElement(By.PartialLinkText("Alerts"));
            Assert.That(element.Text, Is.EqualTo("JavaScript Alerts"));
        }
    }
}
