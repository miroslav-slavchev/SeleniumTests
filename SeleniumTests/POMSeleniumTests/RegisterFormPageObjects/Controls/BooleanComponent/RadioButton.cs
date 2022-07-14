using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.BooleanComponent
{
    public class RadioButton : BooleanComponent
    {
        public RadioButton(IWebElement searchContext) : base(searchContext)
        {
        }

        public override void Select() => Input.Click();
    }
}
