using Selenium.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net;

namespace ZetesVulcan.Test.BackOffice
{
    //[TestClass] //using Microsoft.VisualStudio.TestTools.UnitTesting;
    //[TestFixture] //using NUnit.Framework;
    public class TestIE
    {
        private Authencation _login;
        //static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter("extentReport.html");
        //static ExtentReports extent = new ExtentReports();


        //[TestCase("Authentication")] //using NUnit.Framework;
        private readonly string Expected_PageTitle = "Authentication";

        //[TestCase("admin", "", "Palavra-chave é de preenchimento obrigatório")] //using NUnit.Framework;
        private readonly string User = "admin";
        private readonly string Password = "";
        private readonly string Expected_PasswordRequired = "Palavra-chave é de preenchimento obrigatório";

        //[TestInitialize]
        //public void ExtentReportSetup()
        //{
        //    htmlReporter.AppendExisting = true;
        //    extent.AttachReporter(htmlReporter);
        //}

        //[TestMethod]
        //public void ExtentReportEnvVariables()
        //{
        //    string hostname = Dns.GetHostName();
        //    OperatingSystem os = Environment.OSVersion;
        //    extent.AddSystemInfo("Operation System:", os.ToString());
        //    extent.AddSystemInfo("Hostname: ", hostname);
        //    extent.AddSystemInfo("Browser: ", "Google Chrome");
        //}

        //[TestMethod] //using Microsoft.VisualStudio.TestTools.UnitTesting;
        //[Test] //using NUnit.Framework;
        public void LoginWithouPassword()
        {
            //var test = extent.CreateTest("<div style='color:green; font -weight :bold'>Browser Internet Explorer</div>", "<h3>Authentication - > Login Withou Password</h3>");

            try
            {
                //test.Log(Status.Info, "Inicialize");
                _login = new Authencation(Browser.InternetExplorer);
                _login.LoadPage();

                string Return_PageTitle = _login.ReturnTitle();
                Assert.AreEqual(Expected_PageTitle, Return_PageTitle);

                _login.SetField_Username(User);
                _login.SetField_Password(Password);
                _login.SetButton_btnprimary();
                string return_PasswordRequired = _login.Getlabel_helpblockerror();
                Assert.AreEqual(Expected_PasswordRequired, return_PasswordRequired);

                _login.SetClose();
                //test.Log(Status.Info, "Finalize");

                //test.Pass("<div style='color:green; font -weight :bold'>Authentication - > Login Withou Password.</div>");
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                //test.Fail("<div style='color:red; font -weight :bold'>Authentication - > Login Withou Password -> " + error + ".</div>");
            }
        }

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    //extent.Flush();
        //}
    }
}
