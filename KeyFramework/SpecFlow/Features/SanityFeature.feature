Feature: SanityFeature
	

@SanityTest

Scenario: Verify Login into the application
	Given I have logged into Key application page
	Then I should see properties dashboard page

Scenario: Verify Add New Property


Scenario: Verify Market Place
	#Given I have logged into Key application page
	#Then I should see properties dashboard page
	When I click Market Place I can see all the jobs and apply jobs
	When I fill all the mandatory details on apply job application
	| Key          | Value			|
	| Amount	   | 100			|
	| Note		   | job quote form |
	Then I click submit button page navigate to marketplace page with successful message
	

