using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects
{
    public abstract class PageObject
    {
        private IWebDriver Driver { get; set; }

        protected IWebElement SearchContext { get; private set; }

        public PageObject (IWebElement searchContext)
        {
            SearchContext = searchContext;
            Driver = ((WebElement)SearchContext).WrappedDriver;
        }

        protected Actions Actions => new(Driver);
    }
}
