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
        private By _usernameLocator = By.Id("authUser");
        private By _passwordLocator = By.Id("clearPass");
        private By _languageLocator = By.XPath("//select[@name='languageChoice']");
        private By _loginLocator = By.Id("login-button");
        private By _errorLocator = By.XPath("//p[contains(text(),'Invalid')]");


        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void EnterUsername(string username)
        {
            _driver.FindElement(_usernameLocator).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(_passwordLocator).SendKeys(password);
        }

        public void SelectLanguageByText(string language)
        {
            SelectElement selectLanguage = new SelectElement(_driver.FindElement(_languageLocator));
            selectLanguage.SelectByText(language);
        }

        public void ClickOnLogin()
        {
            _driver.FindElement(_loginLocator).Click();
        }

        public string GetInvalidErrorMessage()
        {
            return _driver.FindElement(_errorLocator).Text;
        }

        public string GetUsernamePlaceholder()
        {
            return _driver.FindElement(_usernameLocator).GetAttribute("placeholder");
        }

        public string GetPasswordPlaceholder()
        {
            return _driver.FindElement(_passwordLocator).GetAttribute("placeholder");
        }
    }
}
