using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumSpecflow.PagesHandler;
using SeleniumSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecflow.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [BeforeScenario]
        public void Setup()
        {
            // Browser valid options["chrome" | "firefox" | "ie"]
            _driver = DriverHandler.GetWebDriver("chrome");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _homePage = new HomePage(_driver);
        }
        [AfterScenario]
        public void Teardown()
        {
            _driver.Quit();
        }

        /**
         * -----------------------   SEARCH definitions
        */
        [Given(@"I visit the url ""(.*)""")]
        public void GivenIVisitTheUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        
        [When(@"I search for the article ""(.*)""")]
        public void WhenISearchForTheArticle(string article)
        {
            _homePage.InputItemToSearch(article);
            _homePage.ClickOnSearchButton();
        }
        
        [Then(@"the page finds ""(.*)"" results in the search")]
        public void ThenThePageFindsResultsInTheSearch(string counter)
        {
            string counterMessage = _homePage.GetResultsCounterMessage();
            Assert.AreEqual($"{counter} results have been found.", counterMessage);
        }
        
        [Then(@"I get the not found message '(.*)'")]
        public void ThenIGetTheNotFoundMessageGlasses(string expectedMessage)
        {
            if(_homePage.IsAlertWarningDisplayed())
            {
                Assert.AreEqual(expectedMessage, _homePage.GetAlertWarningText());
            }
            else
            {
                Assert.IsTrue(false, $"The message '{expectedMessage}' was not displayed");
            }
        }
    }
}
