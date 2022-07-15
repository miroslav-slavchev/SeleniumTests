using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.Controls
{
    public class SliderControl : FormGroupControl
    {
        private IWebElement Input => SearchContext.FindElement(By.TagName("input"));

        public SliderControl(IWebElement searchContext) : base(searchContext)
        {
        }

        public override dynamic ActualInputData => int.Parse(Input.GetAttribute("value"));

        public override void SetData(dynamic data)
        {
            Actions.MoveToElement(Input, 0, 0).Click().Perform();
            int inputx = (int)data;
            int currentX = int.Parse(Input.GetAttribute("value"));
            int moveBy = GetDirection(inputx, currentX);
            int value = int.Parse(Input.GetAttribute("value"));
            int currentPoint = 0;

            while (value != inputx)
            {
                Actions.MoveToElement(Input, currentPoint, 0).ClickAndHold().MoveByOffset(moveBy, 0).Release().Perform();
                currentPoint += moveBy;
                value = int.Parse(Input.GetAttribute("value"));
            }
        }

        private static int GetDirection(int inputx, int currentX)
        {
            int moveBy;
            if (inputx > currentX)
            {
                moveBy = 1;
            }
            else if (inputx < currentX)
            {
                moveBy = -1;
            }
            else
            {
                moveBy = 0;
            }

            return moveBy;
        }
    }
}
