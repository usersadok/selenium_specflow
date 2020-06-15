using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;

namespace SeleniumSpecflow.Utils
{
    [Binding]
    class Hooks
    {
        private static ExtentHtmlReporter _reporter;
        private static AventStack.ExtentReports.ExtentReports _extent;
        private static ExtentTest _test;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            // start reporters
            string basePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp3.1", "");
            _reporter = new ExtentHtmlReporter($"{basePath}\\Reports\\index.html");

            // create ExtentReports and attach reporter(s)
            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(_reporter);

        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            // calling flush writes everything to the log file
            _extent.Flush();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // creates a test 
            _test = _extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                _test.Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
                // test with snapshot
                _test.AddScreenCaptureFromPath("screenshot.png");
            }
        }


        [AfterStep]
        public void AfterStepReporting()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    _test.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if(stepType == "When")
                    _test.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if(stepType == "Then")
                     _test.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if(stepType == "And")
                     _test.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if(ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    _test.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if(stepType == "When")
                    _test.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if(stepType == "Then")
                    _test.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if(stepType == "And")
                    _test.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
        }
    }
}
