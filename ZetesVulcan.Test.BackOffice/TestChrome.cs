using Selenium.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZetesVulcan.Test.BackOffice
{
   // [TestClass] //using Microsoft.VisualStudio.TestTools.UnitTesting;
    //[TestFixture] //using NUnit.Framework;
    public class TestChrome
    {
        private Authencation _login;

        //[TestCase("Authentication")]
        private readonly string Expected_PageTitle = "Authentication";

        //[TestCase("admin", "", "Palavra-chave é de preenchimento obrigatório")]
        private readonly string User = "admin";
        private readonly string Password = "";
        private readonly string Expected_PasswordRequired = "Palavra-chave é de preenchimento obrigatório";

        //[TestMethod] //using Microsoft.VisualStudio.TestTools.UnitTesting;
        //[Test] //using NUnit.Framework;
        public void LoginWithouPassword()
        {
            try
            {
                _login = new Authencation(Browser.Chrome);
                _login.LoadPage();

                string Return_PageTitle = _login.ReturnTitle();
                Assert.AreEqual(Expected_PageTitle, Return_PageTitle);

                _login.SetField_Username(User);
                _login.SetField_Password(Password);
                _login.SetButton_btnprimary();
                string return_PasswordRequired = _login.Getlabel_helpblockerror();
                Assert.AreEqual(Expected_PasswordRequired, return_PasswordRequired);

                _login.SetClose();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }            
        }
        //[TearDown]
    }
}
