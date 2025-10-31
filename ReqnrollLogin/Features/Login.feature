Feature: Login Page Functionality
  As a user of the application
  I want to log in using valid credentials
  So that I can access the secure area of the application

   Background:
    Given the application is launched
    And I am on the login page


  Scenario: Successful login with valid credentials
    When I enter a valid username "student"
    And I enter a valid password "Password123"
    And I click on the submit button
    Then I should see a successful login message "Logged In Successfully"
    And I should see a welcome message "Congratulations student. You successfully logged in!"

  Scenario: Login attempt with invalid username
    When I enter an invalid username "wronguser"
    And I enter a valid password "Password123"
    And I click on the submit button
    Then I should see an error message "Your username is invalid!"
  
Scenario: Login attempt with invalid password
    When I enter a valid username "student"
    And I enter an invalid password "wrongpassword"
    And I click on the submit button
    Then I should see an error message "Your password is invalid!"

  Scenario: Login attempt with empty fields
    When I leave the username and password field empty
    And I click on the submit button
    Then I should see an error message "Your username is invalid!"