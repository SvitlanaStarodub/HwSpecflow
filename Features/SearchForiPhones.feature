Feature: SearchForiPhones
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Compare iPhone7 and iPhone7 plus
	Given I open 'https://rozetka.com.ua/'
	And I search for 'Apple iPhone'
	When I search for a phone characteristics 
	| Phone         |
	| iPhone 7      |
	| iphone 7 Plus |
	And I save similar phone's characteristics
	Then The similar characteristics are available in Console
