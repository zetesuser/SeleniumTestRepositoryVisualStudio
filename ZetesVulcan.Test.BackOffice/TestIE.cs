using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetesVulcan.Test.BackOffice
{
    [TestClass]
    public class TestIE
    {
        private Login _login;

        //[TestCase("Authentication")]
        private readonly string Expected_PageTitle = "Authentication";

        //[TestCase("admin", "", "Palavra-chave é de preenchimento obrigatório")]
        private readonly string User = "admin";
        private readonly string Password = "";
        private readonly string Expected_PasswordRequired = "Palavra-chave é de preenchimento obrigatório";

        //[SetUp]
        [TestMethod]
        public void Initialized()

        {
            _login = new Login(Browser.InternetExplorer);
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

        //[TearDown]
    }
}
