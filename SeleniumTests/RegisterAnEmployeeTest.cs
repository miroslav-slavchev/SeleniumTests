using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    internal class RegisterAnEmployeeTest : BaseTests
    {
        protected override string Url => @"file:///C:/Users/miros/Desktop/Repo/HtmlDemo/register.html";

        [Test]
        [Description("Validate you can seccesffully register an user with data: John Doe")]
        public void RegisterAnEmployeeWithValidData()
        {
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("John");
            
            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Doe");
            
            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            registerButton.Click();

            Driver.SwitchTo().Alert().Accept();

            IWebElement firstParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(1)"));
            Assert.That(firstParagraph.Text, Does.Contain("Name: John Doe"));
        }
    }
}
