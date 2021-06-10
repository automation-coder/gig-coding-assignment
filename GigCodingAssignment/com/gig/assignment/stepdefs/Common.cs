using GigCodingAssignment.com.gig.assignment.util;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GigCodingAssignment.com.gig.assignment.stepdefs
{
    [Binding]
    public sealed class Common
    {
        private readonly ScenarioContext _scenarioContext;

        public Common(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the user initializes the connection to the API (.*)")]
        public void InitializeClient(string baseUrl)
        {
            RestActions.Initialize(baseUrl);
        }

        [Then("the user gets the response code (.*)")]
        public void VerifyResponseCode(int statusCode)
        {
            var response = _scenarioContext.Get<IRestResponse>(ContextKeys.RESPONSE);
            int statusCodeInResponse = (int) response.StatusCode;
            Assert.AreEqual(statusCode, statusCodeInResponse);
        }
    }
}
