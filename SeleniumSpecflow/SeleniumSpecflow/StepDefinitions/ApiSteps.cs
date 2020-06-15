using NUnit.Framework;
using SeleniumSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecflow.StepDefinitions
{
    [Binding]
    public class ApiSteps
    {
        private String _urlApi;

        [Given(@"I have this URL '(.*)'")]
        public void GivenIHaveThisURL(string url)
        {
            _urlApi = url;
        }
        
        [Then(@"I verify that the API is up and running")]
        public void ThenIVerifyThatTheAPIIsUpAndRunning()
        {
            HttpRequests httpRequests = new HttpRequests();

            Assert.AreEqual("OK", httpRequests.GetCodeOfGetRequest(_urlApi), $"The API '{_urlApi}' is not working properly", null);
        }
    }
}
