Feature: Login


@mytag
Scenario: Test the Landing page
	Given User goes to Landing page with url "http://automationpractice.com/index.php"
	Then A product "Faded Short Sleeve T-shirts" should be available Priced at "$16.51"
