using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    public class Tests
    {
        IWebDriver _driver;
        [Test]
        public void TestGithub()
        {
            // create a new ChromeDriver instance
            IWebDriver _driver = new ChromeDriver();

            // navigate to Github login
            _driver.Navigate().GoToUrl("https://github.com/login");


            // enter Github username and password and click "Sign in" button
            IWebElement usernameField = _driver.FindElement(By.Id("login_field"));
            usernameField.SendKeys("gautam sushan");
            IWebElement passwordField = _driver.FindElement(By.Id("password"));
            passwordField.SendKeys("***");
            IWebElement submitButton = _driver.FindElement(By.CssSelector("input[type='submit']"));
            submitButton.Click();

            // wait for 5 seconds and then close the browser
            System.Threading.Thread.Sleep(5000);
            _driver.Quit();
        }
    }
}
