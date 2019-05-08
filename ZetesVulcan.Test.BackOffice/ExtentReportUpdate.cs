using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net;
using System.Configuration;
using Selenium.Utils;

namespace ZetesVulcan.Test.BackOffice
{
    [TestClass]
    public class ExtentReportUpdate
    {

        static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter("extentReportUpdate.html");
        static ExtentReports extent = new ExtentReports();
        

        [TestInitialize]
        public void Setup()
        {

            extent.AttachReporter(htmlReporter);
        }


        [TestMethod]
        public void EnvVariables()
        {
            string hostname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;
            extent.AddSystemInfo("Operation System:", os.ToString());
            extent.AddSystemInfo("Hostname: ", hostname);
            extent.AddSystemInfo("Browser: ", "Google Chrome");
        }

        [TestMethod]
        public void PassedTestMethod()
        {
            var test = extent.CreateTest("<div style='color:green; font -weight :bold'>PassedTestMethod</div>", "<h3>This test method gets passed</h3>");
            test.Log(Status.Info, "First step of PassedTestMethod");
            test.Pass("<div style='color:green; font -weight :bold'>PassedTestMethod gets completed.</div>");
        }

        [TestMethod]
        public void FailledTestMethod()
        {
            var test = extent.CreateTest("<div style='color:red; font -weight :bold'>FailledTestMethod</div>", "<h3>This test method gets failled</h3>");
            test.Log(Status.Info, "First step of FailledTestMethod");
            test.Fail("<div style='color:red; font -weight :bold'>FailledTestMethod gets completed.</div>");
        }

        [TestMethod]
        public void SkippedTestMethod()
        {
            var test = extent.CreateTest("SkippedTestMethod", "This test method gets skipped");
            test.Log(Status.Info, "First step of SkippedTestMethod");
            test.Skip("SkippedTestMethod gets completed.");
        }

        [TestMethod]
        public void WarningTestMethod()
        {
            var test = extent.CreateTest("WarningTestMethod", "This test method gets passed");
            test.Log(Status.Info, "First step of WarningTestMethod");
            test.Warning("WarningTestMethod gets completed.");
        }

        [TestCleanup]
        public void Cleanup()
        {
            extent.Flush();
        }

    }
}
