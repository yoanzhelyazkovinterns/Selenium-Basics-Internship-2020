Feature: LogIn
	As a Registered User, I want my User journey to have corect behavior.

@positive
Scenario: LogIn successfully with correct username and password
	Given I open Web Scraper Testing Ground website
	When I enter username "admin" 
	And I enter password "12345" 
	And I click on the LogIn button
	Then I should see Greeting message

@negative
Scenario Outline: LogIn error is displayed when entering incorrect username and password
	Given I open Web Scraper Testing Ground website
	When I enter username "<username>" 
	And I enter password "<password>" 
	And I click on the LogIn button
	Then I should see Error message displayed
	Examples: 
	| username | password |
	| user     | 54321    |
	| someUser | 1234     |