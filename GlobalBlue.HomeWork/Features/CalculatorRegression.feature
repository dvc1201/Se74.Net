@Calculator
@Regression
Feature: CalculatorRegression
	In order to calculate my refund
	As a customer
	I want to enter my purchases

Background: 
    Given I Open the Calculator

Scenario: Calculate in Austria
    Given I select 'AUT' as country
	When I Enter my Purchases
	| Amount   | CalculatedRefund | 
	| abcd     | @INVALID         | 
	| -89.56   | @MINIMUM         | 
	| 0        | @MINIMUM         | 
	| 75.009   | @MINIMUM         | 
	| 75.01    | 9.00             | 
	| 250      | 28.50            |
	| 400      | 46.00            |
	| 85000    | 12750.00         |
	Then I should see that 4 Purchases are displayed
	And  I should see proper Calculated and Total values
	When I Reset the Calculator Page
	Then Calculator Page is initialised
