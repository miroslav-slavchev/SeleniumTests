using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POMSeleniumTests.RegisterFormPageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests
{
    public class BootstrapRegisterFormTests : BaseTests
    {
        protected override string Url => @"file:///C:/Users/miros/Desktop/Repo/SeleniumTests/SeleniumTests/Htmls/BootStrapContextualRegister/register.html";

        [Test]
        public void EnterData()
        {
            SetData();
            Driver.SwitchTo().Alert().Accept();
            EditData();
        }

        private void SetData()
        {
            BootstrapRegisterForm bootstrapRegisterForm = new BootstrapRegisterForm(Driver.FindElement(By.ClassName("container")));
            RegisterFormSection personalInfo = bootstrapRegisterForm.GetSection("Personal information");
            personalInfo.GetControl("First Name:").SetData("John");
            personalInfo.GetControl("Last Name:").SetData("Doe");
            personalInfo.GetControl("Gender:").SetData("Male");

            RegisterFormSection jobInfo = bootstrapRegisterForm.GetSection("Job information and skills:");
            jobInfo.GetControl("Job title").SetData("Automation QA");
            jobInfo.GetControl("Favourite programming languages:").SetData(new string[] { "C#", "Java" });
            jobInfo.GetControl("Favourite automation tools:").SetData(new string[] { "Selenium", "Katalon" });
            jobInfo.GetControl("English (language proficiency):").SetData(40);
            jobInfo.GetControl("Career aspirations:").SetData("I Want to work with Selenium.");

            Assert.AreEqual("John", personalInfo.GetControl("First Name:").ActualInputData);
            Assert.AreEqual("Doe", personalInfo.GetControl("Last Name:").ActualInputData);
            Assert.AreEqual("Male", personalInfo.GetControl("Gender:").ActualInputData);

            Assert.AreEqual("Automation QA", jobInfo.GetControl("Job title").ActualInputData);
            CollectionAssert.AreEqual(new string[] { "C#", "Java" }, jobInfo.GetControl("Favourite programming languages:").ActualInputData);
            CollectionAssert.AreEqual(new string[] { "Selenium", "Katalon" }, jobInfo.GetControl("Favourite automation tools:").ActualInputData);
            Assert.AreEqual(40, jobInfo.GetControl("English (language proficiency):").ActualInputData);
            Assert.AreEqual("I Want to work with Selenium.", jobInfo.GetControl("Career aspirations:").ActualInputData);

            bootstrapRegisterForm.Register();
        }
       
        private void EditData()
        {
            Thread.Sleep(3000);
            BootstrapRegisterForm bootstrapRegisterForm = new BootstrapRegisterForm(Driver.FindElement(By.ClassName("container")));
            RegisterFormSection personalInfo = bootstrapRegisterForm.GetSection("Personal information");
            personalInfo.GetControl("First Name:").SetContextualData("Anna");
            personalInfo.GetControl("Last Name:").SetContextualData("Cook");
            personalInfo.GetControl("Gender:").SetContextualData("Female");

            RegisterFormSection jobInfo = bootstrapRegisterForm.GetSection("Job information and skills:");
            jobInfo.GetControl("Job title").SetContextualData("QA");
            jobInfo.GetControl("Favourite programming languages:").SetContextualData(new string[] { "Java" });
            jobInfo.GetControl("Favourite automation tools:").SetContextualData(new string[] { "Cypress", "Katalon" });
            jobInfo.GetControl("English (language proficiency):").SetContextualData(51);
            jobInfo.GetControl("Career aspirations:").SetContextualData("I Want to work with Cypress.");

            Assert.AreEqual("Anna", personalInfo.GetControl("First Name:").ActualInputData);
            Assert.AreEqual("Cook", personalInfo.GetControl("Last Name:").ActualInputData);
            Assert.AreEqual("Female", personalInfo.GetControl("Gender:").ActualInputData);

            Assert.AreEqual("Automation QA", jobInfo.GetControl("Job title").ActualInputData);
            CollectionAssert.AreEqual(new string[] { "Java" }, jobInfo.GetControl("Favourite programming languages:").ActualInputData);
            CollectionAssert.AreEqual(new string[] { "Cypress", "Katalon" }, jobInfo.GetControl("Favourite automation tools:").ActualInputData);
            Assert.AreEqual(45, jobInfo.GetControl("English (language proficiency):").ActualInputData);
            Assert.AreEqual("I Want to work with Cypress.", jobInfo.GetControl("Career aspirations:").ActualInputData);

            bootstrapRegisterForm.Register();
        }
    }
}
