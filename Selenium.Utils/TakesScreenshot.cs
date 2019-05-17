using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium.Utils
{
    public static class TakesScreenshot
    {

        public static string Capture(IWebDriver webDriver, string pathScreenshot, string nameScreenshot)
        {
            ITakesScreenshot ts = (ITakesScreenshot)webDriver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string uptobinPath = path.Substring(0, path.LastIndexOf("bin")) + pathScreenshot + nameScreenshot + ".png";
            string localPath = new Uri(uptobinPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }
    }
}
