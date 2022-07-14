using OpenQA.Selenium;
using SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.BooleanComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.Controls
{
    public class CheckboxGroupControl : FormGroupControl
    {
        private List<Checkbox> Checkboxes => SearchContext.FindElements(By.ClassName("checkbox-inline")).Select(button => new Checkbox(button)).ToList();

        public CheckboxGroupControl(IWebElement searchContext) : base(searchContext)
        {
        }

        public override dynamic ActualInputData => Checkboxes.Where(checkbox => checkbox.Selected).Select(checkbox => checkbox.Label).ToArray();

        public override void SetData(dynamic data)
        {
            List<string> items = new List<string>(data);
            Checkboxes.Where(checkbox => items.Contains(checkbox.Label)).ToList().ForEach(checkbox => checkbox.Select());
        }
    }
}
