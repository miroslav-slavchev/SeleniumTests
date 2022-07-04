using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class RegisterAnEmployeeTest : BaseTests
    {
        protected override string Url => @"file:///C:/Users/miros/Desktop/Repo/SeleniumTests/SeleniumTests/Htmls/Register/register.html";

        [Test]
        public void LocatorsTestId()
        {
            IWebElement button = Driver.FindElement(By.Id("submit"));
            Assert.That(button.Text, Is.EqualTo("Register"));
        }

        [Test]
        public void LocatorsTestClass()
        {
            IWebElement clearButton = Driver.FindElement(By.ClassName("red-button"));
            // IWebElement clearButton = Driver.FindElement(By.CssSelector(".red-button.disabled-button"));
            Assert.That(clearButton.Text, Is.EqualTo("Clear"));
        }

        [Test]
        public void LocatorsTestName()
        {
            List<IWebElement> checkboxInputs = Driver.FindElements(By.Name("checkBox")).ToList();

            //Click all checkboxes
            foreach (IWebElement checkboxInput in checkboxInputs)
            {
                checkboxInput.Click();
                Assert.IsTrue(checkboxInput.Selected);
            }
        }

        [Test]
        public void LocatorsTestTagName()
        {
            IWebElement h2 = Driver.FindElement(By.TagName("h2"));
            Assert.That(h2.Text, Is.EqualTo("Register an employee:"));
        }

        [Test]
        public void LocatorsTestCssCombinatorSelector()
        {
            IWebElement p = Driver.FindElement(By.CssSelector("div p"));
            Assert.That(p.Text, Is.EqualTo("Please select your job title:"));

            List<IWebElement> options = Driver.FindElements(By.CssSelector("select option")).ToList();
            Assert.That(options[0].Text, Is.EqualTo("QA"));
            Assert.That(options[1].Text, Is.EqualTo("Automation QA"));
            Assert.That(options[2].Text, Is.EqualTo("Developer"));
            Assert.That(options[3].Text, Is.EqualTo("Designer"));
        }

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

        [Test]
        [Description("Validate you can seccesffully register an user with data: John Doe")]
        public void RegisterAnEmployeeWithValidDataViaContextMenu()
        {
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("John");

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Doe");

            IWebElement body = Driver.FindElement(By.TagName("body"));
            Actions actions = new Actions(Driver);
            actions.ContextClick(body).Perform();

            IWebElement contextMenu = Driver.FindElement(By.Id("contextMenu"));
            IWebElement contextRegisterButton = contextMenu.FindElement(By.Id("contextRegister"));
            contextRegisterButton.Click();

            Driver.SwitchTo().Alert().Accept();

            IWebElement firstParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(1)"));
            Assert.That(firstParagraph.Text, Does.Contain("Name: John Doe"));
        }

        [Test]
        [Description("Validate you can seccesffully register an user with data: John Doe")]
        public void RegisterAnEmployeeWithValidDataUsingActions()
        {
            Actions actions = new Actions(Driver);
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            actions.SendKeys(firstNameInputElement, "John").Perform();

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            actions.SendKeys(lastNameInputElement, "Doe").Perform();

            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            actions.Click(registerButton).Perform();

            Driver.SwitchTo().Alert().Accept();

            IWebElement firstParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(1)"));
            Assert.That(firstParagraph.Text, Does.Contain("Name: John Doe"));
        }

        [Test]
        [Description("Validate that no alert is present when you clear first name and last name.")]
        public void WebElementClearTest()
        {
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("John");

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Doe");

            firstNameInputElement.Clear();
            lastNameInputElement.Clear();

            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            registerButton.Click();

            Assert.IsFalse(IsAlertPresent());
        }

        [Test]
        public void RelativeByTest()
        {
            IWebElement javaScriptInput = Driver.FindElement(By.Id("js"));
            IWebElement javaScriptLabel = Driver.FindElement(RelativeBy.WithLocator(By.TagName("label")).RightOf(javaScriptInput));
            Assert.That(javaScriptLabel.Text, Is.EqualTo("JavaScript"));
        }

        [Test]
        public void MultipleRelativeByTest()
        {
            IWebElement cssLabel = Driver.FindElement(By.CssSelector("label[for='css']"));
            IWebElement htmlLabel = Driver.FindElement(By.CssSelector("label[for='html']"));
            IWebElement cssInput = Driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).RightOf(htmlLabel).LeftOf(cssLabel));
            cssInput.Click();
            Assert.That(cssInput.Selected, Is.True);
        }

        [Test]
        [Description("Register an user and validate results content:")]
        public void ValidateResultsContent()
        {
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("John");

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Doe");

            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            registerButton.Click();

            Driver.SwitchTo().Alert().Accept();
            List<IWebElement> elements = Driver.FindElements(By.CssSelector("body *")).ToList();
            Assert.AreEqual(elements.Count, 3);
            Assert.That(elements.Select(element => element.TagName).ToList(), Is.All.EqualTo("p"));
            Assert.AreEqual(elements[0].Text, "Name: John Doe, Gender:Male");
            Assert.AreEqual(elements[1].Text, "No favourite technologies");
            Assert.AreEqual(elements[2].Text, "Currently working as QA");
        }

        [Test]
        [Description("Register an user and validate results content:")]
        public void ValidateResultsBodyContent()
        {
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("John");

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Doe");

            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            registerButton.Click();

            Driver.SwitchTo().Alert().Accept();
            IWebElement body = Driver.FindElement(By.TagName("body"));
            string text = body.Text;
            Assert.That(text.Contains("Name: John Doe, Gender:Male"), Is.True);
        }

        [Test]
        public void SelectRadio()
        {
            IWebElement femaleRadioLabel = Driver.FindElement(By.CssSelector("label[for='female']"));
            femaleRadioLabel.Click();

            IWebElement femaleRadioInput = Driver.FindElement(By.CssSelector("input[id='female']"));
            Assert.IsTrue(femaleRadioInput.Selected);
        }

        [Test]
        public void SelectCheckbox()
        {
            IWebElement csCheckboxLabel = Driver.FindElement(By.CssSelector("label[for='java']"));
            csCheckboxLabel.Click();

            IWebElement csCheckboxInput = Driver.FindElement(By.CssSelector("input[id='java']"));
            Assert.IsTrue(csCheckboxInput.Selected);
        }

        [Test]
        [Description("Validate that the button is enabled only when first name and last name are entered.")]
        public void RegisterButtonEnabledTest()
        {
            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            Assert.IsFalse(registerButton.Enabled);

            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("John");

            Assert.IsFalse(registerButton.Enabled);

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Doe");
            Driver.FindElement(By.TagName("body")).Click(); // lose focus

            Assert.IsTrue(registerButton.Enabled);

            lastNameInputElement.Clear();
            Assert.IsFalse(registerButton.Enabled);
        }

        [Test]
        [Description("Ctrl + A Test")]
        public void ClearInputCtrlATest()
        {
            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            Assert.IsFalse(registerButton.Enabled);

            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("John");

            Assert.IsFalse(registerButton.Enabled);

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Doe");
            Driver.FindElement(By.TagName("body")).Click(); // lose focus
            Assert.IsTrue(registerButton.Enabled);

            lastNameInputElement.SendKeys(Keys.Control + "a");
            lastNameInputElement.SendKeys(Keys.Backspace);
            Driver.FindElement(By.TagName("body")).Click(); // lose focus
            Assert.IsFalse(registerButton.Enabled);
        }

        [Test]
        [Description("Validate that the tooltip is not displayed by default (and is only on hover).")]
        public void TooltipDisplayedTest()
        {
            IWebElement tooltip = Driver.FindElement(By.ClassName("tooltiptext"));
            Assert.IsFalse(tooltip.Displayed);

            //You can hover over an element with the Actions class
            Actions actions = new Actions(Driver);
            IWebElement btnToHover = Driver.FindElement(By.Id("btnArea"));
            actions.MoveToElement(btnToHover).Perform();
            Assert.IsTrue(tooltip.Displayed);
        }

        [Test]
        public void TextVsValueTest()
        {
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("John");

            Assert.That(firstNameInputElement.GetAttribute("value"), Is.EqualTo("John"));
            Assert.That(firstNameInputElement.Text, Is.EqualTo(""));

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Doe");

            Assert.That(lastNameInputElement.GetAttribute("value"), Is.EqualTo("Doe"));
            Assert.That(lastNameInputElement.Text, Is.EqualTo(""));
        }

        [Test]
        public void GetAttributesTest()
        {
            IWebElement maleRadioInput = Driver.FindElement(By.CssSelector("input[id='male']"));
            Assert.That(maleRadioInput.GetAttribute("checked"), Is.EqualTo("true"));
            Assert.That(maleRadioInput.GetAttribute("value"), Is.EqualTo("Male"));

            IWebElement femaleRadioInput = Driver.FindElement(By.CssSelector("input[id='female']"));
            femaleRadioInput.Click();
            Assert.That(femaleRadioInput.GetAttribute("checked"), Is.EqualTo("true"));
            Assert.That(maleRadioInput.GetAttribute("checked"), Is.Null);
        }

        [Test]
        public void ValidateButtonColor()
        {
            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            Assert.That(registerButton.GetCssValue("color"), Is.EqualTo("rgba(255, 255, 255, 1)"));
            Assert.That(registerButton.GetCssValue("background-color"), Is.EqualTo("rgba(65, 105, 225, 1)"));
            Assert.That(registerButton.GetCssValue("font-family"), Is.EqualTo("serif"));
        }

        [Test]
        public void SelectJobProperties()
        {
            IWebElement job = Driver.FindElement(By.Id("job"));
            SelectElement selectJob = new SelectElement(job);
            Assert.IsFalse(selectJob.IsMultiple);
            Assert.AreEqual(selectJob.Options.Count, 4);
            Assert.AreEqual(selectJob.SelectedOption.Text, "QA");
        }


        [Test]
        public void SelectJob()
        {
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("John");

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Doe");

            IWebElement job = Driver.FindElement(By.Id("job"));
            SelectElement selectJob = new SelectElement(job);
            selectJob.SelectByText("Developer");

            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            registerButton.Click();

            Driver.SwitchTo().Alert().Accept();

            IWebElement resultTextP3 = Driver.FindElement(By.CssSelector("body p:nth-child(3)"));
            Assert.AreEqual("Currently working as Developer", resultTextP3.Text);
        }

        [Test]
        public void DoubleClickHeading()
        {
            IWebElement heading = Driver.FindElement(By.TagName("h2"));

            heading.Click(); heading.Click();
            Assert.IsFalse(IsAlertPresent());

            Actions actions = new Actions(Driver);
            actions.DoubleClick(heading).Perform();
            Assert.IsTrue(IsAlertPresent());
        }

        private bool IsAlertPresent() => TryGetAlert() != null;

        private IAlert TryGetAlert()
        {
            try
            {
                return Driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        }
    }
}
