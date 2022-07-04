using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    internal class WaitDynamicControls : BaseTests
    {
        protected override string Url => @"http://the-internet.herokuapp.com/dynamic_controls";

        [Test]
        public void ElementStaleness()
        {
            IWebElement checkbox = Driver.FindElement(By.Id("checkbox"));

            IWebElement swapButton = Driver.FindElement(By.CssSelector("button[onclick='swapCheckbox()']"));
            swapButton.Click();

            WebDriverWait webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            webDriverWait.Until(ExpectedConditions.StalenessOf(checkbox));

            IWebElement message = Driver.FindElement(By.Id("message"));

            Assert.IsTrue(message.Displayed);
            Assert.AreEqual("It's gone!", message.Text);
        }

        [Test]
        public void ElementExists()
        {
            IWebElement checkbox = Driver.FindElement(By.Id("checkbox"));

            IWebElement swapButton = Driver.FindElement(By.CssSelector("button[onclick='swapCheckbox()']"));
            swapButton.Click();

            WebDriverWait webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            webDriverWait.Until(ExpectedConditions.StalenessOf(checkbox));

            swapButton.Click();
            checkbox = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id("checkbox")));

            Assert.IsTrue(checkbox.Displayed);
        }
    }
}
