using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.OpenEMRAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void EnterUsername(string username)
        {
            _driver.FindElement(By.Id("authUser")).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(By.Id("clearPass")).SendKeys(password);
        }

        public void SelectLanguageByText(string language)
        {
            SelectElement selectLanguage = new SelectElement(_driver.FindElement(By.XPath("//select[@name='languageChoice']")));
            selectLanguage.SelectByText(language);
        }

        public void ClickOnLogin()
        {
            _driver.FindElement(By.Id("login-button")).Click();
        }

        public string GetInvalidErrorMessage()
        {
            return _driver.FindElement(By.XPath("//p[contains(text(),'Invalid')]")).Text;
        }
    }
}
