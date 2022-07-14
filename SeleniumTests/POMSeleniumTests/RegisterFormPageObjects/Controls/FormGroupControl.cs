using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.Controls
{
    public abstract class FormGroupControl : PageObject
    {
        private IWebElement NameElement => SearchContext.FindElement(By.TagName("label"));

        protected FormGroupControl(IWebElement searchContext) : base(searchContext)
        {
        }

        public string Name => NameElement.Text;

        public abstract dynamic ActualInputData { get; }

        public abstract void SetData(dynamic data);
    }
}
