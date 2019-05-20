using System;
using System.Configuration;
using Selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace ZetesVulcan.Test.BackOffice
{
    public class Authencation
    {
        private Browser _browser;
        private OpenQA.Selenium.IWebDriver _driver;

        public Authencation(Browser browser)
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

        public void LoadPage()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlBackOffice"]);
            _driver.Manage().Window.Maximize();
        }

        public string ReturnTitle()
        {
            return _driver.Title;
        }

        public void SetField_Username(string value)
        {
            AuthenticationPage authenticationPage = new AuthenticationPage(_driver);
            authenticationPage.TypeUsername(value);
        }

        public void SetField_Password(string value)
        {
            AuthenticationPage authenticationPage = new AuthenticationPage(_driver);
            authenticationPage.TypePassword(value);
        }

        public void SetButton_btnprimary()
        {
            AuthenticationPage authenticationPage = new AuthenticationPage(_driver);
            authenticationPage.SetButtonPrimary();
        }

        public Tuple<string, string> Getlabel_helpblockerror_User(IEnumerable<double> valReturn)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.Id("Username-error")) != null);

            IWebElement getlabelhelpblockerror_User = _driver.FindElement(By.Id("Username-error"));

            string screenshotpath = TakesScreenshot.Capture(_driver, "Screenshots\\" + _browser + "\\", "Screenshots" + DateTime.Now.ToString("yyyyMMddHHmmssffff"));

            return Tuple.Create(getlabelhelpblockerror_User.Text, screenshotpath);

        }

        public Tuple<string, string> Getlabel_helpblockerror_Password(IEnumerable<double> valReturn)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.Id("Password-error")) != null);

            IWebElement getlabelhelpblockerror_Password = _driver.FindElement(By.Id("Password-error"));

            string screenshotpath = TakesScreenshot.Capture(_driver, "Screenshots\\" + _browser + "\\", "Screenshots" + DateTime.Now.ToString("yyyyMMddHHmmssffff"));

            return Tuple.Create(getlabelhelpblockerror_Password.Text, screenshotpath);
        }

        public void SetClose()
        {
            _driver.Close();
            _driver.Quit();
            _driver = null;
        }
    }
}
