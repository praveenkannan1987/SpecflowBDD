Feature: Api

A short summary of the feature

@tag1
Scenario: Emp API GET
	Given I send a GET request for single user "2"
	Then the response status code should be 200
	And the response for last_name contain "Weaver"

Scenario Outline: Emp API GET For many
	Given I send a GET request for single user "<No>"
	Then the response status code should be 200
	And the response for last_name contain "<lastName>"
Examples: 
| No | lastName |
| 2  | Weaver   |
| 3  | Wong     |
| 4  | Eve      |