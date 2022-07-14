using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PureSeleniumTests
{
    internal class WaitTests : BaseTests
    {
        protected override string Url => @"http://the-internet.herokuapp.com/dynamic_loading/1";

        [Test]
        public void WaitLoadingBarToDisappearImplicit()
        {
            IWebElement startButton = Driver.FindElement(By.CssSelector("#start button"));
            startButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement finish = Driver.FindElement(By.CssSelector("#finish h4"));

            Assert.IsTrue(finish.Displayed);
            Assert.AreEqual("Hello World!", finish.Text);
        }

        [Test]
        public void WaitLoadingBarToDisappear()
        {
            IWebElement startButton = Driver.FindElement(By.CssSelector("#start button"));
            startButton.Click();

            WebDriverWait webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#loading")));

            IWebElement finish = Driver.FindElement(By.CssSelector("#finish h4"));
            Assert.IsTrue(finish.Displayed);
            Assert.AreEqual("Hello World!", finish.Text);
        }

        [Test]
        public void WaitLoadingBarToDisappearDefaultWait()
        {
            IWebElement startButton = Driver.FindElement(By.CssSelector("#start button"));
            startButton.Click();

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(Driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "The searched element is not found!";
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#loading")));

            IWebElement finish = Driver.FindElement(By.CssSelector("#finish h4"));
            Assert.IsTrue(finish.Displayed);
            Assert.AreEqual("Hello World!", finish.Text);
        }


        [Test]
        public void WaitFinishHeadingToBeVisible()
        {
            IWebElement startButton = Driver.FindElement(By.CssSelector("#start button"));
            startButton.Click();

            WebDriverWait webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement finish = webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#finish h4")));

            Assert.IsTrue(finish.Displayed);
            Assert.AreEqual("Hello World!", finish.Text);
        }
    }
}
