using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.OpenEMRAutomation.Pages
{
    public class MainPage
    {
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public string GetMainPageTitle
        {
            get { return _driver.Title; }
        }

        public void ClickOnPatientMenu()
        {
            _driver.FindElement(By.XPath("//div[text()='Patient']")).Click();
        }
    }
}
