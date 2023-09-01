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

namespace Unisys.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;
        private static ExtentReports extent;
        protected static ExtentTest test;
        public static string projectPath;


        [OneTimeSetUp]
        public void Start()
        {
            if (extent == null)
            {
                projectPath = Directory.GetCurrentDirectory();
                projectPath = projectPath.Remove(projectPath.IndexOf("bin"));

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

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.openemr.io/b/openemr";
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
