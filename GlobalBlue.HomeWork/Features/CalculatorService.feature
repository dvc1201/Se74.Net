Feature: CalculatorService
	In order to test the Calculator service
	As a QA
	I want to calculate refunds

@mytag
Scenario: Refunds in Austria
	Given I use 40 as Jurisdiction
	When I Call the Calculator Service
	| Amount   | CalculatedRefund | 
	| 75.01    | 9.00             | 
	| 250      | 28.50            |
	| 400      | 46.00            |
	| 85000    | 12750.00         |
	Then no Error is detected
