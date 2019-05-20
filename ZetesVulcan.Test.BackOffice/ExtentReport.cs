using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace ZetesVulcan.Test.BackOffice
{
    //[TestClass]
    //public class ExtentReport
    //{
    //    [TestMethod]
    //    public void ExtentReportTest()
    //    {

    //        var htmlReporter = new ExtentHtmlReporter("extentReport.html") ;
    //        var extent = new ExtentReports();            
    //        extent.AttachReporter(htmlReporter);

    //        //use real values
    //        string hostname = Dns.GetHostName();
    //        OperatingSystem os = Environment.OSVersion;


    //        //hard code
    //        extent.AddSystemInfo("Operation System:", os.ToString());
    //        extent.AddSystemInfo("Hostname: ", hostname);
    //        extent.AddSystemInfo("Browser: ", "Google Chrome");

    //        var test = extent.CreateTest("ExtentReportTest");
    //        test.Log(Status.Info, "Step 1: Test case starts.");
    //        test.Log(Status.Pass, "Step 2: Test case passed");
    //        test.Log(Status.Fail, "Step 3: Test case failed");
    //        test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
    //        test.Pass("Screenshot").AddScreenCaptureFromPath("screenshot.png");
    //        extent.Flush();
    //    }
    //}
}
