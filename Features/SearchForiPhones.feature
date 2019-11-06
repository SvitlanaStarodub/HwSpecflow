Feature: SearchForiPhones
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Compare iPhone7 and iPhone7 plus
	Given I open 'https://rozetka.com.ua/'
	And I search for 'Apple iPhone'
	And I search for 'iPhone 7,iPhone 7 Plus' characteristics 
	Then I save similar phone's characteristics
	And The similar characteristics are available in a file
