using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using Unisys.Utilities;

namespace Unisys.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver? driver;
        private static ExtentReports? extent;
        protected ExtentTest? test;
        public static string? projectPath;
        public static string? testDataPath;


        [OneTimeSetUp]
        public void Start()
        {
            if (extent == null)
            {
                //projectPath = Directory.GetCurrentDirectory();
                projectPath = TestContext.CurrentContext.TestDirectory;
                Console.WriteLine(projectPath);
                projectPath = projectPath.Remove(projectPath.IndexOf("bin"));
                testDataPath = projectPath + @"testdata\";

                ExtentHtmlReporter reporter = new ExtentHtmlReporter(projectPath + @"Report\index.html");
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
        }

        [OneTimeTearDown]
        public void End()
        {
            extent.Flush();
        }

        [SetUp]
        public void SetUp()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //local or grid
            string machine = JsonUtils.GetValueFromJson(testDataPath + "data.json", "machine");
            string browser = JsonUtils.GetValueFromJson(testDataPath + "data.json", "browser");

            string url = JsonUtils.GetValueFromJson(testDataPath+"data.json", "url");

            if (machine.Equals("grid"))
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
            }
            else
            {
                if (browser.ToLower().Equals("edge"))
                {
                    driver = new EdgeDriver(@"C:\Users\Balaji_Dinakaran\.cache\selenium\msedgedriver\win64\116.0.1938.69");
                }
                else
                {
                    driver = new ChromeDriver(@"C:\Users\Balaji_Dinakaran\.cache\selenium\chromedriver\win64\116.0.5845.96");
                }
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.Url = "https://demo.openemr.io/b/openemr";
            driver.Url = url;
        }

        [TearDown]
        public void TearDown()
        {

            string testName = TestContext.CurrentContext.Test.Name;

            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                test.Log(Status.Fail, stackTrace + errorMessage);

            }
            else if (status == TestStatus.Passed)
            {
                test.Log(Status.Pass, "Passed - Snapshot below:");
            }
            else if (status == TestStatus.Skipped)
            {
                test.Log(Status.Skip, "Skipped - " + testName);
            }

            driver.Quit();
        }
    }
}
