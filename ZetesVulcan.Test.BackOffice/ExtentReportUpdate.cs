﻿using System;
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
using System.IO;

namespace ZetesVulcan.Test.BackOffice
{

    [TestClass]
    public class ExtentReportUpdate
    {
        
        static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(ExtentsReport.ExtentSelenium("ExtentGenerate\\", "Report\\") + "extentReportupdate.html");
        static ExtentReports extent = new ExtentReports();

        [TestInitialize]
        public void Setup()
        {            
            string pathextentconfig = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetExecutingAssembly().CodeBase.LastIndexOf("bin")) + "extent-config.xml";
            string localPathextentconfig = new Uri(pathextentconfig).LocalPath;
            htmlReporter.LoadConfig(localPathextentconfig);
            extent.AttachReporter(htmlReporter);
        }

        [TestMethod]
        public void EnvVariables()
        {
            string hostname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;
            extent.AddSystemInfo("Operation System:", os.ToString());
            extent.AddSystemInfo("Hostname: ", hostname);
        }

        [TestMethod]
        public void Chrome()
        {

            var parentTest = extent.CreateTest("<div style='color:blue; font -weight :bold'>Browser Chrome</div>", "<h3>Authentication</h3>");
            parentTest.Log(Status.Info, "Start Chrome Authentication test");

            var childTest = parentTest;

            TestChrome testchrome = new TestChrome();
            IEnumerable<double> values = null;

            var resultsChromeLoginWithouUser = testchrome.LoginWithouUser(values);
            switch (resultsChromeLoginWithouUser.Item1)
            {
                case 1:
                    {
                        childTest = parentTest.CreateNode("Login Without User");
                        childTest.Pass("Screenshot successs").AddScreenCaptureFromPath(Path.GetFileName(resultsChromeLoginWithouUser.Item3));
                        childTest.Log(Status.Info, "Success Login Without User");
                        childTest.Pass("Successs");
                        break;
                    }
                case 0:
                    {
                        childTest = parentTest.CreateNode("Login Without User");
                        childTest.Fail("Screenshot fail").AddScreenCaptureFromPath(Path.GetFileName(resultsChromeLoginWithouUser.Item3));
                        childTest.Log(Status.Info, "Fail Login Without User");
                        childTest.Fail(resultsChromeLoginWithouUser.Item2);
                        break;
                    }
            }

            var resultsChromeLoginWithoutPassword = testchrome.LoginWithoutPassword(values);
            switch (resultsChromeLoginWithoutPassword.Item1)
            {
                case 1:
                    {
                        childTest = parentTest.CreateNode("Login Without Password");
                        childTest.Pass("Screenshot successs").AddScreenCaptureFromPath(Path.GetFileName(resultsChromeLoginWithoutPassword.Item3));
                        childTest.Log(Status.Info, "Success Login Without Password");
                        childTest.Pass("Successs");
                        break;
                    }
                case 0:
                    {
                        childTest = parentTest.CreateNode("Login Without Password");

                        childTest.Fail("Screenshot fail").AddScreenCaptureFromPath(Path.GetFileName(resultsChromeLoginWithoutPassword.Item3));
                        childTest.Log(Status.Info, "Fail Login Without Password");
                        childTest.Fail(resultsChromeLoginWithouUser.Item2);
                        break;
                    }
            }

            parentTest.Log(Status.Info, "<div style='color:green; font -weight :bold'>End Chrome Authentication test</div>");

        }

        [TestMethod]
        public void Firefox()
        {

            var parentTest = extent.CreateTest("<div style='color:blue; font -weight :bold'>Browser FireFox</div>", "<h3>Authentication</h3>");
            parentTest.Log(Status.Info, "Start FireFox Authentication test");

            var childTest = parentTest;

            TestFirefox testfirefox = new TestFirefox();
            IEnumerable<double> values = null;

            var resultsFireFoxLoginWithouUser = testfirefox.LoginWithouUser(values);
            switch (resultsFireFoxLoginWithouUser.Item1)
            {
                case 1:
                    {
                        childTest = parentTest.CreateNode("Login Without User");
                        childTest.Pass("Screenshot successs").AddScreenCaptureFromPath(Path.GetFileName(resultsFireFoxLoginWithouUser.Item3));
                        childTest.Log(Status.Info, "Success Login Without User");
                        childTest.Pass("Successs");
                        break;
                    }
                case 0:
                    {
                        childTest = parentTest.CreateNode("Login Without User");
                        childTest.Fail("Screenshot fail").AddScreenCaptureFromPath(Path.GetFileName(resultsFireFoxLoginWithouUser.Item3));
                        childTest.Log(Status.Info, "Fail Login Without User");
                        childTest.Fail(resultsFireFoxLoginWithouUser.Item2);
                        break;
                    }
            }

            var resultsFireFoxLoginWithoutPassword = testfirefox.LoginWithouPassword(values);
            switch (resultsFireFoxLoginWithoutPassword.Item1)
            {
                case 1:
                    {
                        childTest = parentTest.CreateNode("Login Without Password");
                        childTest.Pass("Screenshot successs").AddScreenCaptureFromPath(Path.GetFileName(resultsFireFoxLoginWithoutPassword.Item3));                       
                        childTest.Log(Status.Info, "Success Login Without Password");
                        childTest.Pass("Successs");
                        break;
                    }
                case 0:
                    {
                        childTest = parentTest.CreateNode("Login Without Password");
                        childTest.Fail("Screenshot fail").AddScreenCaptureFromPath(Path.GetFileName(resultsFireFoxLoginWithoutPassword.Item3));
                        childTest.Log(Status.Info, "Fail Login Without Password");
                        childTest.Fail(resultsFireFoxLoginWithoutPassword.Item2);
                        break;
                    }
            }

            parentTest.Log(Status.Info, "<div style='color:green; font -weight :bold'>End FireFox Authentication test</div>");
        }

        [TestMethod]
        public void InternetExplorer()
        {
            var parentTest = extent.CreateTest("<div style='color:blue; font -weight :bold'>Browser InternetExplorer</div>", "<h3>Authentication</h3>");
            parentTest.Log(Status.Info, "Start InternetExplorer Authentication test");

            var childTest = parentTest;

            TestIE testie = new TestIE();
            IEnumerable<double> values = null;

            var resultsInternetExplorerLoginWithouUser = testie.LoginWithouUser(values);
            switch (resultsInternetExplorerLoginWithouUser.Item1)
            {
                case 1:
                    {
                        childTest = parentTest.CreateNode("Login Without User");
                        childTest.Pass("Screenshot successs").AddScreenCaptureFromPath(Path.GetFileName(resultsInternetExplorerLoginWithouUser.Item3));
                        childTest.Log(Status.Info, "Success Login Without User");
                        childTest.Pass("Successs");
                        break;
                    }
                case 0:
                    {
                        childTest = parentTest.CreateNode("Login Without User");
                        childTest.Fail("Screenshot fail").AddScreenCaptureFromPath(Path.GetFileName(resultsInternetExplorerLoginWithouUser.Item3));
                        childTest.Log(Status.Info, "Fail Login Without User");
                        childTest.Fail(resultsInternetExplorerLoginWithouUser.Item2);
                        break;
                    }
            }

            var resultsInternetExplorerLoginWithoutPassword = testie.LoginWithoutPassword(values);
            switch (resultsInternetExplorerLoginWithoutPassword.Item1)
            {
                case 1:
                    {
                        childTest = parentTest.CreateNode("Login Without Password");
                        childTest.Pass("Screenshot successs").AddScreenCaptureFromPath(Path.GetFileName(resultsInternetExplorerLoginWithoutPassword.Item3));
                        childTest.Log(Status.Info, "Success Login Without Password");
                        childTest.Pass("Successs");
                        break;
                    }
                case 0:
                    {
                        childTest = parentTest.CreateNode("Login Without Password");
                        childTest.Fail("Screenshot fail").AddScreenCaptureFromPath(Path.GetFileName(resultsInternetExplorerLoginWithoutPassword.Item3));
                        childTest.Log(Status.Info, "Fail Login Without Password");
                        childTest.Fail(resultsInternetExplorerLoginWithoutPassword.Item2);
                        break;
                    }
            }

            parentTest.Log(Status.Info, "<div style='color:green; font -weight :bold'>End InternetExplorer Authentication test</div>");
        }

        [TestCleanup]
        public void Cleanup()
        {
            extent.Flush();
        }
    }
}
