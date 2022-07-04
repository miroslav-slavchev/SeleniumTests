using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class Large : BaseTests
    {
        protected override string Url => @"http://the-internet.herokuapp.com/large";

        //.row-49 .column-49

        [Test]
        public void MoveTo4949()
        {
            IWebElement row49col49 = Driver.FindElement(By.CssSelector(".row-49 .column-49"));
            int xBefore = row49col49.Location.X;
            int yBefore = row49col49.Location.Y;

            Actions actions = new Actions(Driver);
            actions.MoveToElement(row49col49).Perform();
            int xAfter = row49col49.Location.X;
            int yAfter = row49col49.Location.Y;

            Assert.AreNotEqual(xBefore, xAfter);
            Assert.AreNotEqual(yBefore, yAfter);

            WebDriverWait wait = new(Driver,TimeSpan.MinValue);
        }
    }
}
