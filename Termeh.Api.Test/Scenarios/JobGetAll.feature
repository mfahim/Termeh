Feature: JobGetAll
As a customer rep
    I want to get job all jobs
    So that I can see the list of current jobs

Scenario: Getting list of jobs
	Given ShowJobsQuery
	When I press get all jobs
	Then the result should be list of jobs
