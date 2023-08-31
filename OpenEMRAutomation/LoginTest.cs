using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;
using OpenQA.Selenium.Support.UI;
using Unisys.OpenEMRAutomation.Utilities;
using Unisys.OpenEMRAutomation.Pages;

namespace Unisys.OpenEMRAutomation
{
    public class LoginTest : AutomationWrapper
    {
        [Test, TestCaseSource(typeof(DataUtils),nameof(DataUtils.ValidLoginDataExcel))]
        public void ValidLoginTest(string username, string password, string language, string expectedTitle)
        {

            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);

            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.XPath("//select[@name='languageChoice']")));
            selectLanguage.SelectByText(language);
            driver.FindElement(By.Id("login-button")).Click();

            //wait for page load to complete 
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }

        [Test]
        [TestCase("saul", "saul123", "Danish", "Invalid username or password")]
       // [TestCase("kim", "kim123", "Dutch", "Invalid username or password")]
        public void InvalidLoginTest(string username, string password, string language, string expectedError)
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);


            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.XPath("//select[@name='languageChoice']")));
            selectLanguage.SelectByText(language);
            driver.FindElement(By.Id("login-button")).Click();

            string actualError = driver.FindElement(By.XPath("//p[contains(text(),'Invalid')]")).Text;

            Assert.That(actualError, Does.Contain(expectedError));
        }
    }
}
