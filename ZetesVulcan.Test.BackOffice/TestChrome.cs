using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetesVulcan.Test.BackOffice
{
    //[TestFixture]
    public class TestChrome
    {
        private Login _login;

        //[SetUp]
        public void Initialized()
        {
            _login = new Login(Browser.Chrome);
            _login.LoadPage();
        }

        //[TestCase("admin", "", "Palavra-chave é de preenchimento obrigatório")]
        public void Validated(string value1, string value2, string value3)
        {
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
