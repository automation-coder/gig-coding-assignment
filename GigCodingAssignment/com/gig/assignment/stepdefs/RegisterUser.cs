using GigCodingAssignment.com.gig.assignment.dto;
using GigCodingAssignment.com.gig.assignment.poco;
using GigCodingAssignment.com.gig.assignment.util;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GigCodingAssignment.com.gig.assignment.stepdefs
{
    [Binding]
    public sealed class RegisterUser
    {
        private static IRestResponse response;
        private readonly ScenarioContext _scenarioContext;

        public RegisterUser(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user sends registration information to the endpoint (.*)")]
        public void WhenTheUserSendsRegistrationInformationToTheEndpointRegister(String endPoint, Table table)
        {
            //Creating Request Object from the input received from feature file
            RegisterUserRequest registerUserRequest = table.CreateInstance<RegisterUserRequest>();
            response = RestActions.Post(endPoint, registerUserRequest);
            //Can be addedd an Assert statement to check any exception in Response
            //Adding the response to the ScenarioContext to access from Common Step Defs
            _scenarioContext.Add(ContextKeys.RESPONSE, response);
        }

        [Then(@"the user gets a token")]
        public void ThenTheUserGetsAToken()
        {
            RegisterSuccessResponse successResponse = JsonActions.GetObjectFromResponse<RegisterSuccessResponse>(response);
            //Verifying that the response has some token value
            Assert.False(String.IsNullOrEmpty(successResponse.token));
        }

        [Then(@"the user gets an error message (.*)")]
        public void ThenTheUserGetsAnErrorMessage(String message)
        {
            RegisterErrorResponse errorResponse = JsonActions.GetObjectFromResponse<RegisterErrorResponse>(response);
            //Verifying the error message in the response
            Assert.AreEqual(message, errorResponse.error);
        }

    }
}
