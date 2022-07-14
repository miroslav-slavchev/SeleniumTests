using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PureSeleniumTests
{
    internal class BellatrixTEsts : BaseTests
    {
        protected override string Url => @"http://demos.bellatrix.solutions/";

        [Test]
        public void BuyFalcon9Test()
        {
            AddFalcon9ToCart();
            ViewCart();
            ProceedCheckout();
            EnterBillingDetails();
            PlaceOrder();
            ValidateOrderReceivedData();
        }

        private void AddFalcon9ToCart()
        {
            IWebElement addFalcon9ToCartButton = Driver.FindElement(By.CssSelector("li.product a[data-product_id='28']"));
            addFalcon9ToCartButton.Click();
        }

        private void ViewCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(6));
            IWebElement viewCart = wait.Until(ExpectedConditions.ElementExists(By.ClassName("added_to_cart")));
            viewCart.Click();
        }

        private void ProceedCheckout()
        {
            IWebElement proceedToCheckout = Driver.FindElement(By.ClassName("checkout-button"));
            proceedToCheckout.Click();
        }
        private void EnterBillingDetails()
        {
            GetTextInput("first_name").EnterTextInputValue("John");
            GetTextInput("last_name").EnterTextInputValue("Doe");
            GetTextInput("company").EnterTextInputValue("Test Company");
            GetSelectInput("country").SelectByText("Ireland");
            GetTextInput("address_1").EnterTextInputValue("Test Address 1");
            GetTextInput("address_2").EnterTextInputValue("Test Address 2");
            GetTextInput("city").EnterTextInputValue("Sofia");
            GetSelectInput("state").SelectByText("Cavan");
            GetTextInput("phone").EnterTextInputValue("111222333");
            GetTextInput("email").EnterTextInputValue("test@email.com");
            WaitLoadingToFinish(5);
        }

        private void PlaceOrder()
        {
            IWebElement checkoutButton = Driver.FindElement(By.Id("place_order"));
            checkoutButton.Click();
            WaitLoadingToFinish(10);
        }

        private void WaitLoadingToFinish(int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutInSeconds));
            var element = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.blockUI")));
            wait.Until(ExpectedConditions.StalenessOf(element));
        }

        private void ValidateOrderReceivedData()
        {
            ValidateMessage();
            ValidateOrderNumber();
            ValidateDate();
            ValidateTotal();
            ValidateMethod();
        }

        private void ValidateMessage()
        {
            IWebElement message = Driver.FindElement(By.CssSelector("p.woocommerce-notice--success"));
            Assert.AreEqual("Thank you. Your order has been received.", message.Text);
        }

        private void ValidateOrderNumber()
        {
            string actualOrderNumber = GetOrderReceivedData("order");
            bool isValidInt = int.TryParse(actualOrderNumber, out int n);
            Assert.IsTrue(isValidInt);
        }

        private void ValidateDate()
        {
            string actualDate = GetOrderReceivedData("date");
            string expectedDate = GenerateExpectedDate();
            Assert.AreEqual(expectedDate, actualDate);
        }

        private void ValidateTotal()
        {
            string actualTotal = GetOrderReceivedData("total");
            Assert.AreEqual("50.00€", actualTotal);
        }

        private void ValidateMethod()
        {
            string actualpaymentMethod = GetOrderReceivedData("method");
            Assert.AreEqual("Direct bank transfer", actualpaymentMethod);
        }

        private string GenerateExpectedDate()
        {
            string todayDay = DateTime.Now.Day.ToString();
            string todayMonth = DateTime.Now.ToString("MMMM");
            string todayYear = DateTime.Now.Year.ToString();
            return todayMonth + " " + todayDay + ", " + todayYear;
        }

        private TextInput GetTextInput(string locatorName)
        {
            var element = Driver.FindElement(By.Id("billing_" + locatorName));
            return new TextInput(element);
        }

        private SelectInput GetSelectInput(string locatorName)
        {
            var element = Driver.FindElement(By.Id("select2-billing_" + locatorName + "-container"));
            return new SelectInput(Driver, element);
        }

        private string GetOrderReceivedData(string locatorName)
        {
            var element = Driver.FindElement(By.CssSelector("ul.order_details li[class$='" + locatorName + "'] strong"));
            return element.Text;
        }
    }

    public class TextInput
    {
        private IWebElement _webElement;

        public TextInput(IWebElement webElement)
        {
            _webElement = webElement;
        }

        public void EnterTextInputValue(string textValue)
        {
            _webElement.SendKeys(textValue);
        }
    }

    public class SelectInput
    {
        private IWebElement _webElement;
        private IWebDriver _driver;
        public SelectInput(IWebDriver driver, IWebElement webElement)
        {
            _driver = driver;
            _webElement = webElement;
        }

        public void SelectByText(string optionText)
        {
            _webElement.Click();
            IWebElement dropDown = _driver.FindElement(By.ClassName("select2-dropdown"));
            List<IWebElement> options = dropDown.FindElements(By.TagName("li")).ToList();
            IWebElement optionElement = options.Where(option => option.Text == optionText).First();
            Actions actions = new Actions(_driver);
            actions.MoveToElement(optionElement).Click().Perform();
        }
    }
}
