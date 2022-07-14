using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.BooleanComponent
{
    public abstract class BooleanComponent : PageObject
    {
        protected IWebElement Input => SearchContext.FindElement(By.TagName("input"));

        public BooleanComponent(IWebElement searchContext) : base(searchContext)
        {
        }

        public string Label => SearchContext.Text;

        public bool Selected => Input.Selected;

        public abstract void Select();
    }
}
