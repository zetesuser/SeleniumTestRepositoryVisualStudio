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
        public void Chrome()
        {

            var parentTest = extent.CreateTest("<div style='color:green; font -weight :bold'>Browser Chrome</div>", "<h3>This test method gets passed</h3>");
            parentTest.Log(Status.Info, "First step of PassedTestMethod");
            parentTest.Pass("<div style='color:green; font -weight :bold'>PassedTestMethod gets completed.</div>");

            TestChrome testchrome = new TestChrome();
            testchrome.LoginWithoutPassword();
            var childTest = parentTest.CreateNode("LoginWithoutPassword");
            childTest.Log(Status.Info, "aaa");
            childTest.Pass("child pass");

            testchrome.LoginWithoutPassword();
            var childTest2 = parentTest.CreateNode("LoginWithoutPassword");
            childTest2.Log(Status.Info, "bbb");
            childTest2.Fail("child pass");
        }

        [TestMethod]
        public void Firefox()
        {

            TestFirefox testfirefox = new TestFirefox();
            testfirefox.LoginWithouPassword();

            var test = extent.CreateTest("<div style='color:red; font -weight :bold'>Browser Firefox</div>", "<h3>This test method gets failled</h3>");
            test.Log(Status.Info, "First step of FailledTestMethod");
            test.Fail("<div style='color:red; font -weight :bold'>FailledTestMethod gets completed.</div>");
        }

        [TestMethod]
        public void InternetExplorer()
        {
            TestIE testie = new TestIE();
            testie.LoginWithouPassword();

            var test = extent.CreateTest("Browser Internet Explorer", "This test method gets skipped");
            test.Log(Status.Info, "First step of SkippedTestMethod");
            test.Skip("SkippedTestMethod gets completed.");
        }

        [TestCleanup]
        public void Cleanup()
        {
            extent.Flush();
        }

    }
}
