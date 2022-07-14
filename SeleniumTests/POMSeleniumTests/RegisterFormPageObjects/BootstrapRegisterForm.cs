using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects
{
    internal class BootstrapRegisterForm : PageObject
    {
        private List<IWebElement> SectionElements => SearchContext.FindElements(By.ClassName("section")).ToList();
        private IWebElement RegisterButton => SearchContext.FindElement(By.Id("submit"));
        private IWebElement ClearButton => SearchContext.FindElement(By.Id("clear"));

        public BootstrapRegisterForm(IWebElement searchContext) : base(searchContext)
        {
        }
        public List<RegisterFormSection> Sections => SectionElements.Select(section => new RegisterFormSection(section)).ToList();

        public RegisterFormSection GetSection(string name) => Sections.Where(section => section.Name == name).First();

        public void Register() => RegisterButton.Click();

        public void Clear() => ClearButton.Click();
    }
}
