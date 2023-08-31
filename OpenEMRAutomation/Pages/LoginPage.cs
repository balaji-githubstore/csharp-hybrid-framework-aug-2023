using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
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

        public void SelectLanguageByText()
        {

        }

        public void ClickOnLogin()
        {

        }

        //will start at 4:10 PM IST
    }
}
