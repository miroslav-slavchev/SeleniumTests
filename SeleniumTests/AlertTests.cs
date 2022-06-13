using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class AlertTests : BaseTests
    {
        protected override string Url => @"http://the-internet.herokuapp.com/javascript_alerts";

        [Test]
        public void ValidateTitle()
        {
            Assert.That(Driver.Title, Is.EqualTo("The Internet"));
        }

        [Test]
        [Description("Accept the alert and validate the result text.")]
        public void AcceptAlertTest()
        {
            IWebElement btn = Driver.FindElement(By.CssSelector("button[onclick='jsAlert()']"));

            btn.Click();

            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();

            IWebElement resultElement = Driver.FindElement(By.Id("result"));

            Assert.That(resultElement.Text, Is.EqualTo("You successfully clicked an alert"));
        }

        [Test]
        [Description("Dismiss the alert and validate the result text.")]
        public void DismissAlertTest()
        {
            IWebElement btn = Driver.FindElement(By.CssSelector("button[onclick='jsConfirm()']"));

            btn.Click();

            IAlert alert = Driver.SwitchTo().Alert();
            alert.Dismiss();

            IWebElement resultElement = Driver.FindElement(By.Id("result"));

            Assert.That(resultElement.Text, Is.EqualTo("You clicked: Cancel"));
        }

        [Test]
        [Description("Accept the alert prompot and validate the result text.")]
        public void AlertPropmtTest()
        {
            IWebElement btn = Driver.FindElement(By.CssSelector("button[onclick='jsPrompt()']"));

            btn.Click();

            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys("Hello World!");
            alert.Accept();

            IWebElement resultElement = Driver.FindElement(By.Id("result"));

            Assert.That(resultElement.Text, Is.EqualTo("You entered: Hello World!"));
        }
    }
}