Feature: Optional


Scenario: Optional charater demo
	Given I am logged in to application
	When I add book
	And I go to checkout page
	Then I have 1 book in cart
	When I add book
	And I go to checkout page
	Then I have 2 books in cart