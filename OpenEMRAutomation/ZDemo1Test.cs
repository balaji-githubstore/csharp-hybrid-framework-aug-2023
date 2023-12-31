﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ClosedXML.Excel;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZDemo.OpenEMRAutomation
{
    /// <summary>
    /// Will be deleted - not part of the framework
    /// 
    /// </summary>
    public class ZDemo1Test
    {
        public static object[] ValidData()
        {
            object[] data1 = new object[2]; //number of parameters
            data1[0] = "saul";
            data1[1] = "saul123";

            object[] data2 = new object[2];
            data2[0] = "peter";
            data2[1] = "peter123";

            object[] data3 = new object[2];
            data3[0] = "kim";
            data3[1] = "kim123";

            object[] allDataSet = new object[3]; //number of test case
            allDataSet[0] = data1;
            allDataSet[1] = data2;
            allDataSet[2] = data3;

            return allDataSet;
        }

        [Test, TestCaseSource(nameof(ValidData)), Ignore("Not required!!")]
        public void ValidTest(string username, string password)
        {
            Console.WriteLine("hello" + username + password);
        }

        [Test]
        public void ReadExcel1Test()
        {
            XLWorkbook book = new XLWorkbook(@"C:\Mine\Company\Unisys Aug 2023\AutomationSolution\OpenEMRAutomation\TestData\open_emr_data.xlsx");
            var sheet = book.Worksheet("ValidLoginTest");

            var range = sheet.RangeUsed();

            int rowCount = range.RowCount();
            int colCount = range.ColumnCount();

            Console.WriteLine(rowCount);
            Console.WriteLine(colCount);

            string cellValue = range.Cell(1, 1).GetString();
            Console.WriteLine(cellValue);

            //write logic to print all cell values

            book.Dispose();

        }

        [Test]
        public void ReadExcel2Test()
        {
            XLWorkbook book = new XLWorkbook(@"C:\Mine\Company\Unisys Aug 2023\AutomationSolution\OpenEMRAutomation\TestData\open_emr_data.xlsx");
            var sheet = book.Worksheet("ValidLoginTest");

            var range = sheet.RangeUsed();

            int rowCount = range.RowCount();
            int colCount = range.ColumnCount();

            Console.WriteLine(rowCount);
            Console.WriteLine(colCount);

            object[] allDataSet = new object[rowCount-1];

            //write logic to print all cell values
            for (int r = 2; r <= rowCount; r++)
            {
                object[] data = new object[colCount];

                for (int c = 1; c <= colCount; c++)
                {
                    data[c-1]= range.Cell(r, c).GetString(); 
                }
                allDataSet[r-2]= data;
            }

            book.Dispose();

        }

        [Test]
        public void ExtentReportDemo()
        {
            //[OneTimeSetUp]
            //only once in the beginning of the application starts 
            var extent = new ExtentReports();
            var spark = new ExtentHtmlReporter("Spark.html");
            extent.AttachReporter(spark);

            //before each test method - [SetUp]
            ExtentTest test = extent.CreateTest("MyFirstTest");

            //[Test]
            //any logs for the test method 
            test.Log(Status.Info, "Entered username as jack");


            //after each test method - [TearDown]
            test.Log(Status.Pass, "This is a logging event for MyFirstTest, and it passed!");


            //[OneTimeTearDown]
            //end of the application  
            extent.Flush();
        }

        [Test]
        public void JsonRead()
        {
            StreamReader reader = new StreamReader(@"C:\Mine\Company\Unisys Aug 2023\AutomationSolution\OpenEMRAutomation\TestData\data.json");
            string jsonText = reader.ReadToEnd();
            Console.WriteLine(jsonText);
            dynamic json= JsonConvert.DeserializeObject(jsonText);

            Console.WriteLine(json["browser"]);
            Console.WriteLine(json["url"]);
            Console.WriteLine(json["machine"]);
        }

    }
}
