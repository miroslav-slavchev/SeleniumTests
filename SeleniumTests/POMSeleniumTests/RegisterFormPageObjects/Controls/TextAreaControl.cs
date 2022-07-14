using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.Controls
{
    public class TextAreaControl : TextInputControl
    {
        protected override IWebElement Input => SearchContext.FindElement(By.TagName("textarea"));

        public TextAreaControl(IWebElement searchContext) : base(searchContext)
        {
        }

        public void Resize(int x, int y)
        {
            var actions = Actions;
            actions.MoveToElement(
                SearchContext, SearchContext.Location.X + SearchContext.Size.Width,
                SearchContext.Location.Y + SearchContext.Size.Height)
                .ClickAndHold().MoveByOffset(x, y).Perform();
        }
    }
}
