Feature: BookVerifications
	

#Scenario: Verify selenium webdriver book price
#	Given User navigates to url "http://amazon.com"	
#	When User input text "selenium test" on "//input[@id='twotabsearchtextbox']"
#	When User clicks on "//input[@type='submit']"	
#	When User clicks on "//span[contains(text(),'Webdriver 3.0')]"
#	Then User verify value of "//span[@class='a-color-base']/span" is "$49.99"
#	Then User closes the browser


@Retry
Scenario: Verify java book price
	Given User navigates to url "http://amazon.in"	
	When User input text "selenium java book" on "//input[@id='twotabsearchtextbox']"
	When User clicks on "//input[@type='submit']"	
	When User clicks on "//span[contains(text(),'Hands-On Selenium WebDriver with Java:')]"
	Then User verify value of "//span[@class='a-color-base']/span" is "₹681.00"	



Scenario: Verify C# book price
	Given User navigates to url "http://amazon.in"	
	When User input text "selenium test c#" on "//input[@id='twotabsearchtextbox']"
	When User clicks on "//input[@type='submit']"	
	When User clicks on "//span[contains(text(),'Selenium Webdriver .0 with C#')]"	
	Then User verify value of "//span[@class='a-color-base']/span" is "₹3,381.00"
	





	
	