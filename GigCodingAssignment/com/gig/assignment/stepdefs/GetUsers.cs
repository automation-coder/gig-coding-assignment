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
            //Verifying that user has got the response from the Server
            Assert.IsNotNull(response, "The Response from the API is null for GET all users");
            //Adding the response to the ScenarioContext to access from Common Step Defs
            _scenarioContext.Add("RESPONSE", response);
        }

        [Then("the user gets a list of users")]
        public void verifyUsersList()
        {
            GetUsersResponse users = JsonActions.getObjectFromResponse<GetUsersResponse>(response);
            //Verifying that the list is not empty
            Assert.That(users.Data.Count >= 1);
        }
    }
}
