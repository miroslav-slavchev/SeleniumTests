using OpenQA.Selenium;
using SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects
{
    internal class RegisterFormSection : PageObject
    {
        private IWebElement NameElement => SearchContext.FindElement(By.TagName("h4"));

        private List<IWebElement> ControlElements => SearchContext.FindElements(By.ClassName("form-group")).ToList();

        private FormGroupControlFactory FormGroupControlFactory => new FormGroupControlFactory(ControlElements);

        public RegisterFormSection(IWebElement searchContext) : base(searchContext)
        {
        }

        public string Name => NameElement.Text;

        public FormGroupControl GetControl(string name) => FormGroupControlFactory.GetControl(name);
    }
}
