using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

            string codeBase = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            if (!Directory.Exists(path.Substring(0, path.LastIndexOf("bin")) + pathScreenshot))
            {
                Directory.CreateDirectory((path.Substring(0, path.LastIndexOf("bin")) + pathScreenshot).ToString());
            }

            string uptobinPath = path.Substring(0, path.LastIndexOf("bin")) + pathScreenshot + nameScreenshot + ".png";
            string localPath = new Uri(uptobinPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }
    }
}
