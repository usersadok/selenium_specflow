Feature: Simple automation in a website

	@login	
	Scenario: The page finds results 
		Given I visit the url "http://automationpractice.com"
		When I search for the article "Casual Dresses"
		Then the page finds "4" results in the search
		
	@login
	Scenario: The page does not find results
		Given I visit the url "http://automationpractice.com"
		When I search for the article "Glasses"
		Then the page finds "0" results in the search
		And I get the not found message 'No results were found for your search "Glasses"'