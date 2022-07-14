using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PureSeleniumTests
{
    internal class RegisterFormTests : BaseTests
    {
        protected override string Url => @"file:///C:/Users/miros/Desktop/Repo/SeleniumTests/SeleniumTests/Htmls/Register/register.html";

        [Test]
        public void FindByIdTest()
        {
            IWebElement button = Driver.FindElement(By.Id("submit"));
            Assert.That(button.Text, Is.EqualTo("Register"));
        }

        [Test]
        public void FindByNameTest()
        {
            List<IWebElement> checkBoxes = Driver.FindElements(By.Name("checkBox")).ToList();

            foreach (var checkBox in checkBoxes)
            {
                checkBox.Click();
                Assert.IsTrue(checkBox.Selected);
            }
        }

        [Test]
        public void FindByTagName()
        {
            IWebElement div = Driver.FindElement(By.TagName("div"));
            IWebElement p = div.FindElement(By.TagName("p"));

            Assert.That(p.Text, Is.EqualTo("Please select your job title:"));
        }


        [Test]
        public void RegisterAnUser()
        {
            IWebElement firstName = Driver.FindElement(By.Id("fname"));
            firstName.SendKeys("John");

            IWebElement lastName = Driver.FindElement(By.Id("lname"));
            lastName.SendKeys("Doe");

            Driver.FindElement(By.TagName("body")).Click(); //focus

            IWebElement registerButton = Driver.FindElement(By.ClassName("blue-button"));
            registerButton.Click();

            Driver.SwitchTo().Alert().Accept();
            IWebElement body = Driver.FindElement(By.CssSelector("body"));
            string text = body.Text;
            Assert.IsTrue(text.Contains("Currently working as QA"));
        }

        [Test]
        public void SelectRadio()
        {
            IWebElement maleRadioInput = Driver.FindElement(By.CssSelector("input[id='male']"));
            Assert.IsTrue(maleRadioInput.Selected);

            IWebElement femaleRadioLabel = Driver.FindElement(By.CssSelector("label[for='female']"));
            femaleRadioLabel.Click();
            IWebElement femaleRadioInput = Driver.FindElement(By.CssSelector("input[id='female']"));
            bool selected = femaleRadioInput.Selected;
            Assert.IsTrue(selected);

            Assert.IsFalse(maleRadioInput.Selected);
        }


        [Test]
        public void RegisterAnUserInvalidData()
        {
            IWebElement firstName = Driver.FindElement(By.Id("fname"));
            firstName.SendKeys("John");

            IWebElement lastName = Driver.FindElement(By.Id("lname"));
            lastName.SendKeys("Doe");

            firstName.Clear();
            lastName.Clear();

            IWebElement registerButton = Driver.FindElement(By.ClassName("blue-button"));
            registerButton.Click();
            Assert.IsFalse(AlertIsPresent());
        }

        private bool AlertIsPresent() => TryGetAlert() != null;


        private IAlert TryGetAlert()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                return alert;
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        }

        [Test]
        public void RelativeByTest()
        {
            IWebElement jsInput = Driver.FindElement(By.Id("js"));
            IWebElement jsLabel = Driver.FindElement(RelativeBy.WithLocator(By.TagName("label")).RightOf(jsInput));
            Assert.That(jsLabel.Text, Is.EqualTo("JavaScript"));
        }

        [Test]
        public void ButtonEnabled()
        {
            IWebElement button = Driver.FindElement(By.Id("submit"));
            Assert.IsFalse(button.Enabled);

            IWebElement firstName = Driver.FindElement(By.Id("fname"));
            firstName.SendKeys("John");

            Assert.IsFalse(button.Enabled);

            IWebElement lastName = Driver.FindElement(By.Id("lname"));
            lastName.SendKeys("Doe");
            Driver.FindElement(By.TagName("body")).Click(); //focus

            Assert.IsTrue(button.Enabled);

            firstName.SendKeys(Keys.Control + "a");
            firstName.SendKeys(Keys.Backspace);
            Driver.FindElement(By.TagName("body")).Click(); //focus
            Assert.IsFalse(button.Enabled);
        }

        [Test]
        public void DisplayedTest()
        {
            IWebElement tooltip = Driver.FindElement(By.ClassName("tooltiptext"));
            Assert.IsFalse(tooltip.Displayed);

            IWebElement button = Driver.FindElement(By.Id("btnArea"));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(button).Perform();
            Assert.IsTrue(tooltip.Displayed);
        }

        [Test]
        public void AtrTest()
        {
            IWebElement firstName = Driver.FindElement(By.Id("fname"));
            firstName.SendKeys("John");

        }
    }
}
