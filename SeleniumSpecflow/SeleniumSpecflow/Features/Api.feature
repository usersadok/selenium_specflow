Feature: Everything to test the APIs
	
	@api
	Scenario: API is up and running
		Given I have this URL 'http://automationpractice.com/'
		Then I verify that the API is up and running
	@api		
	Scenario: API is down
		Given I have this URL 'http://automationpractice.com/indexx.php'
#		The next step will on purpose to verify the error thrown in the console
		Then I verify that the API is up and running