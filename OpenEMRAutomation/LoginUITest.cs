using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;
using Unisys.OpenEMRAutomation.Pages;

namespace Unisys.OpenEMRAutomation
{
    public class LoginUITest : AutomationWrapper
    {
        [Test]
        public void ValidateTitleTest()
        {
            string actualTitle = driver.Title;
            test.Log(Status.Info, "Actual title is " + actualTitle);
            Assert.That(actualTitle, Is.EqualTo("OpenEMR Login"));
        }

        [Test]
        public void ValidatePlaceholderTest()
        {
            LoginPage loginPage = new LoginPage(driver);

            Assert.That(loginPage.GetUsernamePlaceholder(), Is.EqualTo("Username"));
            Assert.That(loginPage.GetPasswordPlaceholder(), Is.EqualTo("Password"));
        }
    }
}
