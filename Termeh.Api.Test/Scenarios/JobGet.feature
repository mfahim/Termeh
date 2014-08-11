Feature: JobGet
As a customer rep
    I want to get job details by Id
    So that I can see the details

Scenario: Getting a job
	Given IndexJobQuery with Id ="1"
	When I press get details
	Then the result should be a job details with Id="1"
