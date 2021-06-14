using GigCodingAssignment.com.gig.assignment.dto;
using GigCodingAssignment.com.gig.assignment.util;
using Newtonsoft.Json;
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
    public sealed class GetUsers
    {
        private static IRestResponse response;
        private readonly ScenarioContext _scenarioContext;

        public GetUsers(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When("the user makes a get call to the endpoint (.*)")]
        public void GetAllUsers(String endpoint)
        {
            response = RestActions.Get(endpoint);
            //Can be addedd an Assert statement to check any exception in Response
            //Adding the response to the ScenarioContext to access from Common Step Defs
            _scenarioContext.Add(ContextKeys.RESPONSE, response);
        }

        [Then("the user gets a list of users")]
        public void verifyUsersList()
        {
            GetUsersResponse users = JsonActions.GetObjectFromResponse<GetUsersResponse>(response);
            //Verifying that the list is not empty
            Assert.That(users.data.Count >= 1);
        }
    }
}
