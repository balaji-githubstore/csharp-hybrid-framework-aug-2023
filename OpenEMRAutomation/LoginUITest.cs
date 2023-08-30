using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.OpenEMRAutomation
{
    public class LoginUITest
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.openemr.io/b/openemr";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ValidateTitleTest()
        {
            string actualTitle = driver.Title;
            Assert.That(actualTitle, Is.EqualTo("OpenEMR Login"));
        }

        [Test]
        public void ValidatePlaceholderTest()
        {
            string actualUsernamePlaceholder = driver.FindElement(By.Id("authUser")).GetAttribute("placeholder");
            Assert.That(actualUsernamePlaceholder, Is.EqualTo("Username"));
        }
    }
}
