Feature: Login

Verifying that I can login to QSight application using valid credentials and logout safely. 
SME: JK 
login(JK) 

@smoke @login
Scenario: user is able to login QSight using valid credentials
	Given I navigate to QSight application
	And I enter valid username password  and click on login
	| username             | password                 |
	| Automation-SiteAdmin | ON4DSq2OZuujuI7emo29Cw== |
	Then I select department 
	And I click on Continue button
	And I verify landing page Add Product to Hospital Inventory	
	Then I click on logout link 
	Then I verify I am logged out







