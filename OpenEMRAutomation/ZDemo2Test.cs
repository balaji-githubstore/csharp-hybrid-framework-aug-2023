using AventStack.ExtentReports;
using DocumentFormat.OpenXml.Bibliography;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.OpenEMRAutomation
{
    [TestFixture("edge")]
    [TestFixture("ch")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ZDemo2Test
    {
        IWebDriver driver;
        string browser;

        public ZDemo2Test(string browser)
        {
            this.browser = browser;
        }


        [SetUp]
        public void SetUp()
        {
            if (browser.ToLower().Equals("edge"))
            {
                driver = new EdgeDriver(@"C:\Users\Balaji_Dinakaran\.cache\selenium\msedgedriver\win64\116.0.1938.69");
            }
            else
            {
                driver = new ChromeDriver(@"C:\Users\Balaji_Dinakaran\.cache\selenium\chromedriver\win64\116.0.5845.96");
            }
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
        public void M1()
        {
            Thread.Sleep(3000);
            Console.WriteLine(driver.Title);
        }

        [Test]
        public void M2()
        {
            Console.WriteLine(driver.Url);
        }
    }
}
