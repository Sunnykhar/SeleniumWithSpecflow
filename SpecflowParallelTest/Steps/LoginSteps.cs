﻿using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SpecflowParallelTest.Pages;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowParallelTest.Steps
{
    [Binding]
    public class LoginSteps
    {

        private RemoteWebDriver _driver;

        public LoginSteps(RemoteWebDriver driver) => _driver = driver;


        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            _driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
        }

        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            //_driver.FindElement(By.Name("UserName")).SendKeys((String)data.UserName);
            //_driver.FindElement(By.Name("Password")).SendKeys((String)data.Password);

            LoginPage page = new LoginPage(_driver);
            page.EnterUserNameAndPassword("admin", "Admin");
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Login")).Submit();
            Thread.Sleep(2000);
        }

        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            var element = _driver.FindElement(By.XPath("//h1[contains(text(),'Execute Automation Selenium')]"));

            //An way to assert multiple properties of single test
            Assert.Multiple(() =>
            {
                Assert.That(element.Text, Is.Null, "Header text not found !!!");
                Assert.That(element.Text, Is.Null, "Header text not found !!!");
            });
        }

        public void unused()
        {

        }

        public void unused1()
        {
            int a;

        }

    }
}
