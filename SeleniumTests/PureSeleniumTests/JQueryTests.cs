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
    internal class JQueryTests : BaseTests
    {
        protected override string Url => @"https://jqueryui.com/";

        public void NavigateTo(string tabName)
        {
            Driver.FindElement(By.LinkText(tabName)).Click();
            Driver.SwitchTo().Frame(0);
        }


        [Test]
        public void Hover()
        {
            NavigateTo("Tooltip");

            int tooltipBefore = Driver.FindElements(By.CssSelector("div[role='tooltip'")).Count();

            IWebElement ageInput = Driver.FindElement(By.Id("age"));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(ageInput).Perform();

            int tooltipAfter = Driver.FindElements(By.CssSelector("div[role='tooltip'")).Count();

            Assert.That(tooltipBefore, Is.EqualTo(0));
            Assert.That(tooltipAfter, Is.EqualTo(1));
        }

        [Test]
        public void MulipleSelection()
        {
            NavigateTo("Selectable");

            List<IWebElement> items = Driver.FindElements(By.CssSelector("#selectable li")).ToList();

            Actions actions = new Actions(Driver);
            actions.KeyDown(Keys.LeftControl).Click(items[1]).Click(items[3]).Click(items[5]).KeyUp(Keys.LeftControl).Build().Perform();
            Assert.True(items[1].GetAttribute("class").Contains("ui-selected"));
            Assert.True(items[3].GetAttribute("class").Contains("ui-selected"));
            Assert.True(items[5].GetAttribute("class").Contains("ui-selected"));
        }

        [Test]
        public void DragAndDrop()
        {
            NavigateTo("Droppable");

            IWebElement sourceElement = Driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = Driver.FindElement(By.Id("droppable"));

            Actions actions = new Actions(Driver);
            actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);
        }

        [Test]
        public void Resize()
        {
            NavigateTo("Resizable");

            IWebElement resizibleHandle = Driver.FindElement(By.CssSelector("div.ui-icon-gripsmall-diagonal-se"));

            int xBefore = resizibleHandle.Location.X;
            int yBefore = resizibleHandle.Location.Y;

            Actions actions = new Actions(Driver);
            actions.ClickAndHold(resizibleHandle).MoveByOffset(100, 100).Perform();

            int xAfter = resizibleHandle.Location.X;
            int yAfter = resizibleHandle.Location.Y;

            Assert.That(xAfter, Is.GreaterThan(xBefore));
            Assert.That(yAfter, Is.GreaterThan(yBefore));
        }
    }
}
