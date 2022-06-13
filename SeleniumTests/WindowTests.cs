using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class WindowTests : BaseTests
    {
        protected override string Url => @"http://the-internet.herokuapp.com/windows";

        [Test]
        [Description("Switch to window and validate its content.")]
        public void WindowsTest()
        {
            List<string> handlesBeforeClick = Driver.WindowHandles.ToList();
            IWebElement btn = Driver.FindElement(By.CssSelector("a[href*='windows']"));
            btn.Click();
            List<string> handlesAfterClick = Driver.WindowHandles.ToList();
            Assert.That(handlesAfterClick.Count, Is.GreaterThan(handlesBeforeClick.Count));

            Driver.SwitchTo().Window(handlesAfterClick.Last());

            IWebElement heading = Driver.FindElement(By.TagName("h3"));
            Assert.That(Driver.Title, Is.EqualTo("New Window"));
            Assert.That(heading.Text, Is.EqualTo("New Window"));

            Driver.SwitchTo().Window(handlesAfterClick.First());
            Assert.That(Driver.Title, Is.EqualTo("The Internet"));

            Driver.SwitchTo().Window(handlesAfterClick.Last());
            Driver.Close();

            List<string> handlesAfterClose = Driver.WindowHandles.ToList();
            Assert.That(handlesAfterClose.Count, Is.EqualTo(handlesBeforeClick.Count));
        }
    }
}
