using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetesVulcan.Test.BackOffice
{
    public class AuthenticationPage
    {
        private OpenQA.Selenium.IWebDriver _driver;
        By username = By.Id("Username");
        By password = By.Id("Password");
        By buttonbtnprimary = By.ClassName("btn-primary");

        public AuthenticationPage(OpenQA.Selenium.IWebDriver driver)
        {
            _driver = driver;
        }

        public void TypeUsername(string typeUser)
        {
            _driver.FindElement(username).SendKeys(typeUser);
        }

        public void TypePassword(string typePassword)
        {
            _driver.FindElement(password).SendKeys(typePassword);
        }

        public void SetButtonPrimary()
        {
            _driver.FindElement(buttonbtnprimary).Submit();
        }
    }
}
