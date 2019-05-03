using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ZetesVulcan.Test.BackOffice
{
    [TestClass]
    public class Login
    {
        private Browser _browser;
        private IWebDriver _driver;

        
        public Login(Browser browser)
        {
            _browser = browser;

            string pathDriver = null;
            if (browser == Browser.Chrome)
            {
                pathDriver = ConfigurationManager.AppSettings["PathDriverChrome"];
            }
            else
                if (browser == Browser.Firefox)
            {
                pathDriver = ConfigurationManager.AppSettings["PathDriverFirefox"];
            }
            else
                if (browser == Browser.InternetExplorer)
            {
                pathDriver = ConfigurationManager.AppSettings["PathDriverIE"];
            }
            _driver = WebDriverFactory.ReturnWebDriver(browser, pathDriver);
        }

        [TestMethod]
        public void LoadPage()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlBackOffice"]);
            _driver.Manage().Window.Maximize();
        }

        public void SetField_Username(string value)
        {
            IWebElement setfieldUsername = _driver.FindElement(By.Id("Username"));
            setfieldUsername.SendKeys(value.ToString());
        }

        public void SetField_Password(string value)
        {
            IWebElement setfieldPassword = _driver.FindElement(By.Id("Password"));
            setfieldPassword.SendKeys(value.ToString());
        }

        public void SetButton_btnprimary()
        {
            IWebElement setbuttonbtnprimary = _driver.FindElement(By.ClassName("btn-primary"));
            setbuttonbtnprimary.Submit();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.Id("Password-error")) != null);
        }

        public string Getlabel_helpblockerror()
        {
            IWebElement getlabelhelpblockerror = _driver.FindElement(By.Id("Password-error"));
            return getlabelhelpblockerror.Text;
        }

        public void SetClose()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
