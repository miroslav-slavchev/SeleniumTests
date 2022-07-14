using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PureSeleniumTests
{
    internal class WaitTests2 : BaseTests
    {
        protected override string Url => @"https://the-internet.herokuapp.com/dynamic_loading/2";

        [Test]
        public void WaitElementToBeRendered()
        {
            IWebElement startButton = Driver.FindElement(By.CssSelector("#start button"));
            startButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement finishHeading = Driver.FindElement(By.Id("finish"));

            Assert.AreEqual("Hello World!", finishHeading.Text);
        }
    }
}
