Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers


Scenario: Create a new customer
  Given I am on the create customer page
  When I fill in the customer details
  And I click the submit button
  Then the customer should be created successfully
  And I should be redirected to the customer details page

Scenario: Read customer details
  Given I am on the customer details page
  When I view the customer details
  Then I should see the customer information

Scenario: Update customer information
  Given I am on the customer details page
  When I click the edit button
  And I update the customer details
  And I click the submit button
  Then the customer information should be updated successfully
  And I should be redirected to the customer details page

Scenario: Delete a customer
  Given I am on the customer details page
  When I click the delete button
  Then the customer should be deleted successfully
  And I should be redirected to the customer list page