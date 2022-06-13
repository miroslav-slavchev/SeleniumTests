using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class SwitchTests : BaseTests
    {
        protected override string Url => @"C:\Users\miros\Desktop\Frame\activeElement.html";

        [Test]
        [Description("Click button and validate that it's the active element.")]
        public void SwitchToButtonTest()
        {
            IWebElement button = Driver.FindElement(By.CssSelector("button"));
            button.Click();
            IWebElement resultParagraph = Driver.FindElement(By.CssSelector("#demo"));
            IWebElement activeElement = Driver.SwitchTo().ActiveElement();
            Assert.That(resultParagraph.Text, Is.EqualTo("BUTTON"));
            Assert.That(activeElement.Text, Is.EqualTo("A Button"));
        }
    }
}
