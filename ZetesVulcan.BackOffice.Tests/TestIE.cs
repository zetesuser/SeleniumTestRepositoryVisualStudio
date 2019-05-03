// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Selenium.Utils;

namespace ZetesVulcan.BackOffice.Tests
{
    [TestFixture]
    public class TestIE
    {
        private Login _login;

        [SetUp]

        public void Initialize_1()

        {
            _login = new Login(Brower.InternetExplorer);
            _login.LoadPage();
        }

        [TestCase("admin", "", "Palavra-chave é de preenchimento obrigatório")]
        public void Validate_1 (string value1, string value2, string value3)
        {
            _login.SetField_Username(value1);
            _login.SetField_Password(value2);
            _login.SetButton_btnprimary();
            string returnValue = _login.Getlabel_helpblockerror();
            Assert.AreEqual(value3, returnValue);

            //double returnValue = _login.returnValue_1();
            //Assert.AreEqual(value2, returnValue);

        }

        [TearDown]
        public void Finalize_1()
        {
            _login.SetClose();
        }
    }
}
