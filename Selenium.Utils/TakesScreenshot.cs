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

        public static string Capture(IWebDriver webDriver, string pathParentScreenshot, string pathScreenshot, string nameScreenshot)
        {
            ITakesScreenshot ts = (ITakesScreenshot)webDriver;
            Screenshot screenshot = ts.GetScreenshot();            

            string codeBase = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            if (!Directory.Exists(path.Substring(0, path.LastIndexOf("bin")) + pathParentScreenshot))
            {
                Directory.CreateDirectory((path.Substring(0, path.LastIndexOf("bin")) + pathParentScreenshot).ToString());
            }

            if (!Directory.Exists(path.Substring(0, path.LastIndexOf("bin")) + pathParentScreenshot + pathScreenshot))
            {
                Directory.CreateDirectory((path.Substring(0, path.LastIndexOf("bin")) + pathParentScreenshot + pathScreenshot).ToString());
            }

            //string uptobinPath = codeBase.Substring(0, codeBase.LastIndexOf("bin")) + pathParentScreenshot + pathScreenshot + nameScreenshot + ".png";            
            string uptobinPath = codeBase.Substring(0, codeBase.LastIndexOf("bin")) + pathParentScreenshot + nameScreenshot + ".png";
            string localPath = new Uri(uptobinPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }
    }
}
