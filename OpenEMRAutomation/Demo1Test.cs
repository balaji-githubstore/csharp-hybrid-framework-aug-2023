using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.OpenEMRAutomation
{
    /// <summary>
    /// Will be deleted - not part of the framework
    /// 
    /// </summary>
    public class Demo1Test
    {

        public static object[] ValidData()
        {
            object[] data1 = new object[2]; //number of parameters
            data1[0] = "saul";
            data1[1] = "saul123";

            object[] data2= new object[2];
            data2[0] = "peter";
            data2[1] = "peter123";

            object[] data3=new object[2];
            data3[0] = "kim";
            data3[1] = "kim123";

            object[] allDataSet = new object[3]; //number of test case
            allDataSet[0]=data1;
            allDataSet[1]=data2;
            allDataSet[2]=data3;

            return allDataSet;
        }

        [Test,TestCaseSource(nameof(ValidData)),Ignore("Not required!!")]
        public void ValidTest(string username,string password)
        {
            Console.WriteLine("hello"+username+password);
        }
    }
}
