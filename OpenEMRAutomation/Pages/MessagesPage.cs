using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.OpenEMRAutomation.Pages
{
    public class MessagesPage
    {
        private IWebDriver _driver;

        public MessagesPage(IWebDriver driver)
        {
            this._driver = driver;
        }
    }
}
