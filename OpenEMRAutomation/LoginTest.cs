using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;
using OpenQA.Selenium.Support.UI;

namespace Unisys.OpenEMRAutomation
{
    public class LoginTest : AutomationWrapper
    {
        [Test]
        [TestCase("admin", "pass", "English (Indian)", "OpenEMR")]
        [TestCase("physician", "physician", "English (Indian)", "OpenEMR")]
        public void ValidLoginTest(string username, string password, string language, string expectedTitle)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
            driver.FindElement(By.Id("clearPass")).SendKeys(password);
            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.XPath("//select[@name='languageChoice']")));
            selectLanguage.SelectByText(language);
            driver.FindElement(By.Id("login-button")).Click();

            //wait for page load to complete 
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        [TestCase("saul", "saul123", "Danish", "Invalid username or password")]
        [TestCase("kim", "kim123", "Dutch", "Invalid username or password")]
        public void InvalidLoginTest(string username, string password, string language, string expectedError)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
            driver.FindElement(By.Id("clearPass")).SendKeys(password);
            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.XPath("//select[@name='languageChoice']")));
            selectLanguage.SelectByText(language);
            driver.FindElement(By.Id("login-button")).Click();

            string actualError = driver.FindElement(By.XPath("//p[contains(text(),'Invalid')]")).Text;

            Assert.That(actualError, Does.Contain(expectedError));
        }


    }
}
