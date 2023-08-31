using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.Base
{
    public class WebDriverKeywords
    {
        private IWebDriver _driver;

        public WebDriverKeywords(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void SendTextByLocator(By locator, string text)
        {
            _driver.FindElement(locator).SendKeys(text);
        }

        public void ClickByLocator(By locator)
        {
            _driver.FindElement(locator).Click();
        }

        public void SelectDropdownTextByLocator(By locator,string optionText)
        {
            SelectElement selectLanguage = new SelectElement(_driver.FindElement(locator));
            selectLanguage.SelectByText(optionText);
        }
        //other keywords for get text, get attribute value, switchtab
    }
}
