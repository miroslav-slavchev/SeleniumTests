using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PureSeleniumTests
{
    internal class BellatrixTеsts234 : BellatrixTEsts
    {

        [Test]
        public void SearchForFalcon()
        {
            IWebElement searchInput = Driver.FindElement(By.Id("woocommerce-product-search-field-0"));
            searchInput.SendKeys("Falcon");
            searchInput.SendKeys(Keys.Enter);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.UrlContains("Falcon"));

            List<IWebElement> products = Driver.FindElements(By.ClassName("product")).ToList();
            foreach (var product in products)
            {
                IWebElement title = product.FindElement(By.TagName("h2"));
                Assert.IsTrue(title.Text.Contains("Falcon"));
            }
        }

        [Test]
        public void SortByPrice()
        {
            IWebElement select = Driver.FindElement(By.ClassName("orderby"));
            SelectElement selectElement = new SelectElement(select);
            selectElement.SelectByText("Sort by price: low to high");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.UrlContains("price"));

            List<IWebElement> products = Driver.FindElements(By.ClassName("product")).ToList();
            List<double> prices = new List<double>();
            foreach (var product in products)
            {
                IWebElement price = product.FindElement(By.CssSelector("ins bdi"));
                string priceText = price.Text.Replace(",", "").Replace("€", "");
                double number = double.Parse(priceText);
                prices.Add(number);
            }

            List<double> sortedPrices = new List<double>(prices);
            sortedPrices.Sort();
            CollectionAssert.AreEqual(sortedPrices, prices);
        }

        [Test]
        public void ShowNResults()
        {
            IWebElement countElement = Driver.FindElement(By.ClassName("woocommerce-result-count"));
            string nText = countElement.Text.Split(" ")[2];
            int n = int.Parse(nText);
            List<IWebElement> products = Driver.FindElements(By.ClassName("product")).ToList();
            Assert.AreEqual(n, products.Count());
        }
    }
}
