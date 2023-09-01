using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.OpenEMRAutomation
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture("edge")]
    [TestFixture("ch")]
    public class ZDemo4Grid
    {
        //string hubUrl;
        string browser;
        IWebDriver driver;
        public ZDemo4Grid(string browser)
        {
            this.browser = browser;
        }

        [SetUp]
        public void SetUp()
        {
            DriverOptions options = null;
            if (browser.ToLower().Equals("edge"))
            {
                options = new EdgeOptions();
            }
            else
            {
                options = new ChromeOptions();
            }

            driver = new RemoteWebDriver(new Uri("http://192.168.29.215:4444"), options);
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
        public void MM1()
        {
           
            Console.WriteLine(driver.Title);
            Thread.Sleep(3000);
            driver.Quit();
        }

        [Test]
        public void MM2()
        {
            Console.WriteLine(driver.Title);
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
