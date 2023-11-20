using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using TechTalk.SpecFlow;
using TestProject.Utility;
using Newtonsoft.Json;

namespace TestProject.Hooks
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        private readonly IObjectContainer _container;
        public int stepNo = 0;
        public static AppConfig appConfig;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var json = File.ReadAllText("D:\\Specflow\\Nunit\\TestProject\\Config\\specflow.json");
            appConfig = JsonConvert.DeserializeObject<AppConfig>(json!)!;
            ExtentReportInit();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        //[BeforeScenario("@testtalk1")]
        //public void BeforeScenarioWithTag()
        //{
        //    Console.WriteLine("@tag1");
        //}


        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Order =1");
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            stepNo++;
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                
                if (!appConfig.ScreenShotEveryStep)
                {
                    if (stepType == "Given")
                    {
                        _scenario.CreateNode<Given>(stepName);
                    }
                    else if (stepType == "When")
                    {
                        _scenario.CreateNode<When>(stepName);
                    }
                    else if (stepType == "Then")
                    {
                        _scenario.CreateNode<Then>(stepName);
                    }
                    else if (stepType == "And")
                    {
                        _scenario.CreateNode<And>(stepName);
                    }
                }
                else
                {
                    if (stepType == "Given")
                    {
                        _scenario.CreateNode<Given>(stepName).Pass("Pass",
                            MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, stepNo)).Build());
                    }
                    else if (stepType == "When")
                    {
                        _scenario.CreateNode<When>(stepName).Pass("Pass",
                            MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, stepNo)).Build());
                    }
                    else if (stepType == "Then")
                    {
                        _scenario.CreateNode<Then>(stepName).Pass("Pass",
                            MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, stepNo)).Build());
                    }
                    else if (stepType == "And")
                    {
                        _scenario.CreateNode<And>(stepName).Pass("Pass",
                            MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, stepNo)).Build());
                    }
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, stepNo)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, stepNo)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, stepNo)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, stepNo)).Build());
                }
            }
        }
        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }

        }
        [AfterFeature]
        public static void AfterFeature()
        {
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportTearDown();
        }

    }
}