using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.Controls
{
    public class SelectControl : FormGroupControl
    {
        private IWebElement Select => SearchContext.FindElement(By.TagName("select"));
        private SelectElement SelectElement => new SelectElement(Select);

        public SelectControl(IWebElement searchContext) : base(searchContext)
        {
        }

        public override dynamic ActualInputData => SelectElement.SelectedOption.Text;

        public override void SetData(dynamic data)
        {
            SelectElement.SelectByText(data);
        }
    }
}
