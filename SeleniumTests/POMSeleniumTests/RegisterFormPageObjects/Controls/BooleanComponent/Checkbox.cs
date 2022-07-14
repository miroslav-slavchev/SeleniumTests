using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.BooleanComponent
{
    public class Checkbox : BooleanComponent
    {
        public Checkbox(IWebElement searchContext) : base(searchContext)
        {
        }

        public override void Select()
        {
            if (Selected == false)
            {
                Input.Click();
            }
        }

        public void Deselect()
        {
            if (Selected)
            {
                Input.Click();
            }
        }
    }
}
