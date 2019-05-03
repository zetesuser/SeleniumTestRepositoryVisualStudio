using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace Selenium.Utils
{
    public static class WebDriverFactory
    {
        
        public static IWebDriver ReturnWebDriver(
            Brower brower, string PathDriver = null)
        {
            IWebDriver webDriver = null;
            switch (brower)
            {
                case Brower.Firefox:
                    webDriver = new FirefoxDriver(PathDriver);
                    break;
                case Brower.Chrome:
                    webDriver = new ChromeDriver(PathDriver);
                    break;
                case Brower.InternetExplorer:
                    var options = new InternetExplorerOptions();
                    {
                        options.EnableNativeEvents = false;
                        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        options.EnsureCleanSession = true;
                        options.AddAdditionalCapability("javascriptEnabled", "true");
                        
                    }
                    webDriver = new InternetExplorerDriver(PathDriver,options);
                    //webDriver.SwitchTo().DefaultContent();
                    webDriver.SwitchTo().ParentFrame();
                    break;
            }

            return webDriver;
        }
      
    }
}
