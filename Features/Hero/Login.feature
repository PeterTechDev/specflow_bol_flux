Feature: Login to Hero System valid credential
    @TestCaseKey=PSP-T27

  Scenario: Successful Login with Valid Credentials
    Given the user is on the Hero login page
    When the user fills the username field with 'psouza' and the password field with 'Wtec123!'
    And the user clicks the login button
    Then the user should be redirected to the Hero Home page
