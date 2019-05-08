using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ExtentReport
{
    public class ExtentReport
    {
        static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter("extentReportUpdate.html");
        static ExtentReports extent = new ExtentReports();
    }
}
