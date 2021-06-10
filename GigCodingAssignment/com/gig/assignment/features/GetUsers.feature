Feature: GET Users
	All the scenarios related to Get Users

Background: 
	Given the user initializes the connection to the API https://reqres.in/api/

@GET_USERS_ALL
Scenario: Get All Users
	When the user makes a get call to the endpoint users
	Then the user gets the response code 200
	And the user gets a list of users