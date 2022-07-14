using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.Controls
{
    public class TextInputControl : FormGroupControl
    {
        protected virtual IWebElement Input => SearchContext.FindElement(By.TagName("input"));

        public TextInputControl(IWebElement searchContext) : base(searchContext)
        {
        }

        public override dynamic ActualInputData => Input.GetAttribute("value");

        public override void SetData(dynamic data)
        {
            Input.SendKeys(data);
        }
    }
}
