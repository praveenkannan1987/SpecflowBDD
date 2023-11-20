using AventStack.ExtentReports.Reporter.Config;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;

namespace TestProject.Utility
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        //public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = "D:\\Report\\TestResults.html";

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentSparkReporter(testResultPath);
            htmlReporter.LoadJSONConfig("D:\\Specflow\\Nunit\\TestProject\\Config\\spark-config.json");

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext,int stepno)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine("D:\\Report\\Screenshot\\", scenarioContext.ScenarioInfo.Title + stepno + ".png");
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }
    }
}
