﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;

namespace Unisys.OpenEMRAutomation.Pages
{
    public class MainPage : WebDriverKeywords
    {
        private By _patientLocator = By.XPath("//div[text()='Patient']");

        private IWebDriver _driver;
        public MainPage(IWebDriver driver):base(driver)
        {
            this._driver = driver;
        }

        public string GetMainPageTitle
        {
            get { return _driver.Title; }
        }

        public void ClickOnPatientMenu()
        {
            _driver.FindElement(_patientLocator).Click();
        }
    }
}
