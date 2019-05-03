using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;

namespace ZetesVulcan.BackOffice.Tests
{
    public class Login
    {
        private Brower _brower;
        private IWebDriver _driver;

        public Login(Brower brower)
        {
            _brower = brower;

            string pathDriver = null;
            if (brower == Brower.Chrome)
            {
                pathDriver = ConfigurationManager.AppSettings["PathDriverChrome"];
            }
            else
                if (brower == Brower.Firefox)
            {
                pathDriver = ConfigurationManager.AppSettings["PathDriverFirefox"];
            }
            else
                if (brower == Brower.InternetExplorer)
                {
                    pathDriver = ConfigurationManager.AppSettings["PathDriverIE"]; 
                }
            _driver = WebDriverFactory.ReturnWebDriver(brower, pathDriver);
        }

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
            //if (_brower != Brower.InternetExplorer)
                setbuttonbtnprimary.Submit();
            //else
            //    setbuttonbtnprimary.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.Id("Password-error")) != null);
        }

        public string Getlabel_helpblockerror()
        {
            IWebElement getlabelhelpblockerror = _driver.FindElement(By.Id("Password-error"));
            return getlabelhelpblockerror.Text;
        }

        //public double returnValue_1()
        //{
        //    IWebElement returnValue1 = _driver.FindElement(By.Id("DistanciaKm"));
        //    return Convert.ToDouble(returnValue1.Text);
        //}

        public void SetClose()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
