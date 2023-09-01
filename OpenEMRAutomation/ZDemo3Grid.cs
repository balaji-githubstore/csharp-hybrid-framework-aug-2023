using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZDemo.OpenEMRAutomation
{
    [Parallelizable(ParallelScope.All)]
    public class ZDemo3Grid
    {
        [Test]
        public void MM1()
        {
            ChromeOptions options = new ChromeOptions();

            IWebDriver driver = new RemoteWebDriver(new Uri("http://192.168.29.215:4444"), options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.openemr.io/b/openemr";
            Console.WriteLine(driver.Title);
            Thread.Sleep(3000);
            driver.Quit();
        }

        [Test]
        public void MM2()
        {
            ChromeOptions options = new ChromeOptions();

            IWebDriver driver = new RemoteWebDriver(new Uri("http://192.168.29.215:4444"), options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.openemr.io/b/openemr";
            Console.WriteLine(driver.Title);
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
