﻿  @TestCaseKey=PSP-T27 @login @1
Feature:01. Login to Hero System valid credential
    
  Scenario:1. Login with Valid Credentials
    Given the user is on the Hero login page
    When the user fills the username field with '<username>' and the password field with '<password>!'
    And the user clicks the login button
    Then the user should be redirected to the Hero Home page

    Examples:
| username | password |
| psouza   | Wtec123  | 