Feature: JobCreation
As a customer rep
    I want to create new jobs
    So that I can work

Scenario: Creating a new job
	Given AddJobCommand with Name ="testJob" and Number ="123" and description ="test job"
	When I press newJob
	Then the result should be a job with Name="testJob"
