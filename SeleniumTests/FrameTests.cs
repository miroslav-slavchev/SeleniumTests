using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    internal class FrameTests : BaseTests
    {
        protected override string Url => "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_iframe_height_width";

        [Test]
        public void FindElementInFrame()
        {
            IWebElement codeArea = Driver.FindElement(By.Id("textareawrapper"));
            Assert.That(codeArea.Text.Contains("<!DOCTYPE html>"), Is.True);
            Assert.Throws<NoSuchElementException>(() =>
            { IWebElement codeArea = Driver.FindElement(By.TagName("h2")); });

            Driver = Driver.SwitchTo().Frame("iframeResult");
            IWebElement heading = Driver.FindElement(By.TagName("h2"));
            Assert.That(heading.Text, Is.EqualTo("HTML Iframes"));

            Driver = Driver.SwitchTo().Frame(Driver.FindElement(By.CssSelector("[title='Iframe Example']")));
            IWebElement innerHeading = Driver.FindElement(By.TagName("h1"));
            Assert.That(innerHeading.Text, Is.EqualTo("This page is displayed in an iframe"));
        }

        [Test]
        public void SwitchToDefaultContetnt()
        {
            Driver = Driver.SwitchTo().Frame("iframeResult");
            Assert.Throws<NoSuchElementException>(() => { IWebElement codeArea = Driver.FindElement(By.Id("textareawrapper")); });

            Driver = Driver.SwitchTo().DefaultContent();
            IWebElement codeArea = Driver.FindElement(By.Id("textareawrapper"));
            Assert.That(codeArea.Text.Contains("<!DOCTYPE html>"), Is.True);
        }

        [Test]
        public void SwitchToDefaultContentFail()
        {
            Driver = Driver.SwitchTo().Frame("iframeResult");
            Assert.DoesNotThrow(() => { IWebElement codeArea = Driver.FindElement(By.Id("textareawrapper")); });
        }

        [TearDown]
        [Order(1)]
        public void AddScreenshotOnTestFailure()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                var takeScreenshot = (ITakesScreenshot)Driver;
                var screenshot = takeScreenshot.GetScreenshot();
                string screenshotDirectoryName = "Screenshots";
                string screenshotFileName = TestContext.CurrentContext.Test.MethodName;
                string fileAbsolutePath = GetFilePath(screenshotDirectoryName, screenshotFileName);
                screenshot.SaveAsFile(fileAbsolutePath);
            }
        }

        private static string GetFilePath(string directoryName, string fileName)
        {
            string relativePath = $"\\{directoryName}";
            string baseDirPath = AppDomain.CurrentDomain.BaseDirectory;
            baseDirPath = baseDirPath.Replace("\\bin\\Debug\\net5.0\\", "");
            string directoryAbsolutePath = baseDirPath + relativePath + "\\";
            string fileFullName = fileName + ".png";
            string fileAbsolutePath = directoryAbsolutePath + fileFullName;
            return fileAbsolutePath;
        }
    }
}
