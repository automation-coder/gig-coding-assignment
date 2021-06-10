Feature: Register User
	All the scenarios related to Register User

Background: 
	Given the user initializes the connection to the API https://reqres.in/api/

@REGISTER_USER
Scenario: Register an User having email and password
	When the user sends registration information to the endpoint register
		| email              | password |
		| eve.holt@reqres.in | pistol   |
	Then the user gets the response code 200
	And the user gets a token

@REGISTER_USER_NEGATIVE
Scenario: Register an User having only email
	When the user sends registration information to the endpoint register
		| email       | password |
		| sydney@fife |          |
	Then the user gets the response code 400
	And the user gets an error message Missing password