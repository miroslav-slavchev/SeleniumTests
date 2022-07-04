using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public abstract class BaseTests
    {
        protected abstract string  Url { get; }

        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Navigate().GoToUrl(Url);
            //Driver.Url = Url;
            //Driver.Manage().Window.Maximize();
        }

        [TearDown]
        [Order(2)]
        public void Quit()
        {
            Driver.Quit();
        }
    }
}
