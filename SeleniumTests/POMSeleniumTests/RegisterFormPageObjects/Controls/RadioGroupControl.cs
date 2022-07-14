using OpenQA.Selenium;
using SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.BooleanComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.Controls
{
    public class RadioGroupControl : FormGroupControl
    {
        private List<RadioButton> RadioButtons => SearchContext.FindElements(By.ClassName("radio-inline")).Select(button => new RadioButton(button)).ToList();

        public RadioGroupControl(IWebElement searchContext) : base(searchContext)
        {
        }

        public override dynamic ActualInputData => RadioButtons.Where(radio => radio.Selected).First().Label;

        public override void SetData(dynamic data)
        {
            RadioButtons.Where(radio => radio.Label == data).First().Select();
        }
    }
}
