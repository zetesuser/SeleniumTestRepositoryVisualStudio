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
        private readonly string Expected_UserRequired = "Utilizador é de preenchimento obrigatório";
        private readonly string Expected_PasswordRequired = "Palavra-chave é de preenchimento obrigatório";

        //[TestMethod] //using Microsoft.VisualStudio.TestTools.UnitTesting;
        //[Test] //using NUnit.Framework;
        public Tuple<int, string, string> LoginWithouUser(IEnumerable<double> valReturn)
        {
            IEnumerable<double> values = null;
            string strscreenshotpath = "";
            try
            {
                _login = new Authencation(Browser.InternetExplorer);
                _login.LoadPage();

                string Return_PageTitle = _login.ReturnTitle();
                Assert.AreEqual(Expected_PageTitle, Return_PageTitle);

                _login.SetField_Username("");
                _login.SetButton_btnprimary();
                var return_UserRequired = _login.Getlabel_helpblockerror_User(values);

                strscreenshotpath = return_UserRequired.Item2;
                Assert.AreEqual(Expected_UserRequired, return_UserRequired.Item1);

                _login.SetClose();

                int intResult = 1;
                string strResult = "";              
                return Tuple.Create(intResult, strResult, strscreenshotpath);
            }
            catch (Exception ex)
            {
                _login.SetClose();
                int intResult = 0;
                string strResult = ex.ToString();                
                return Tuple.Create(intResult, strResult, strscreenshotpath);
            }
        }

        [TestMethod] //using Microsoft.VisualStudio.TestTools.UnitTesting;
        //[TestProperty("User", "admin")] //using NUnit.Framework;
        //[TestProperty("Password", "")] //using NUnit.Framework;
        //[TestProperty("Expected_PasswordRequired", "Palavra-chave é de preenchimento obrigatório")] //using NUnit.Framework;
        //[Test] //using NUnit.Framework;
        public Tuple<int, string, string> LoginWithoutPassword(IEnumerable<double> valReturn)
        {
            IEnumerable<double> values = null;
            string strscreenshotpath = "";
            try
            {
                _login = new Authencation(Browser.InternetExplorer);
                _login.LoadPage();

                string Return_PageTitle = _login.ReturnTitle();
                Assert.AreEqual(Expected_PageTitle, Return_PageTitle);

                _login.SetField_Username(User);
                _login.SetField_Password(Password);
                _login.SetButton_btnprimary();

                var return_PasswordRequired = _login.Getlabel_helpblockerror_Password(values);

                strscreenshotpath = return_PasswordRequired.Item2;
                Assert.AreEqual(Expected_PasswordRequired, return_PasswordRequired.Item1);

                _login.SetClose();

                int intResult = 1;
                string strResult = "";              
                return Tuple.Create(intResult, strResult, strscreenshotpath);
            }
            catch (Exception ex)
            {
                _login.SetClose();
                int intResult = 0;
                string strResult = ex.ToString();                
                return Tuple.Create(intResult, strResult, strscreenshotpath);
            }
        }
    }
}
