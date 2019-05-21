using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Utils
{
    public static class ExtentsReport
    {
        public static string ExtentSelenium(string pathParentExtent, string pathExtentSelenium)
        {

            string codeBase = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            if (!Directory.Exists(path.Substring(0, path.LastIndexOf("bin")) + pathParentExtent))
            {
                Directory.CreateDirectory((path.Substring(0, path.LastIndexOf("bin")) + pathParentExtent).ToString());
            }

            if (!Directory.Exists(path.Substring(0, path.LastIndexOf("bin")) + pathParentExtent + pathExtentSelenium))
            {
                Directory.CreateDirectory((path.Substring(0, path.LastIndexOf("bin")) + pathParentExtent).ToString() + pathExtentSelenium);
            }

            string uptobinPath = codeBase.Substring(0, codeBase.LastIndexOf("bin")) + pathParentExtent + pathExtentSelenium;
            string localPath = new Uri(uptobinPath).LocalPath;
            return localPath;
        }
    }
}
