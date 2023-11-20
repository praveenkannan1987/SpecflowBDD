Feature: google failure 

A short summary of the feature

@testtalk1
Scenario: google open
	Given I open google file
	When I enter text "hello world"

@testtalk1
Scenario: google open 2
	Given I open google file
	When I enter text "hello world"
	And I connect to DB connect

@testtalk1
Scenario: google open 3
	Given I open google file
	When I enter text "hello world"
