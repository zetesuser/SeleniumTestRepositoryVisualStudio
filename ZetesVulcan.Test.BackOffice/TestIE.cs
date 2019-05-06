using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetesVulcan.Test.BackOffice
{
    public class TestIE
    {
        private Login _login;

        //[SetUp]
        public void Initialized()
        {
            _login = new Login(Browser.InternetExplorer);
            _login.LoadPage();
        }

        //[TestCase("Authentication")]
        public void checktitle(string value1)
        {
            value1 = "Authentication";
            string returnValue = _login.ReturnTitle();
            Assert.AreEqual(value1, returnValue);
        }

        //[TestCase("admin", "", "Palavra-chave é de preenchimento obrigatório")]
        public void Validated(string value1, string value2, string value3)
        {
            value1 = "admin";
            value2 = "";
            value3 = "alavra-chave é de preenchimento obrigatório";
            _login.SetField_Username(value1);
            _login.SetField_Password(value2);
            _login.SetButton_btnprimary();
            string returnValue = _login.Getlabel_helpblockerror();
            Assert.AreEqual(value3, returnValue);
        }

        //[TearDown]
        public void Finalized()
        {
            _login.SetClose();
        }
    }
}
