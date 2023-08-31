using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;

namespace Unisys.OpenEMRAutomation.Pages
{
    public class MessagesPage : WebDriverKeywords
    {
        private IWebDriver _driver;

        public MessagesPage(IWebDriver driver):base(driver)
        {
            this._driver = driver;
        }
    }
}
