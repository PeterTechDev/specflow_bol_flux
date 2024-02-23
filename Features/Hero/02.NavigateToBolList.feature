Feature:02. Navigate to BOL List in Hero System

Background:
    Given the user is on the Hero login page
    When the user fills the username field with 'psouza' and the password field with 'Wtec123!'
    And the user clicks the login button
    Then the user should be redirected to the Hero Home page
    
@TestCaseKey=PSP-T28 @NavigateToBOLsList @2
Scenario:2. Navigate to BOL List page in Hero System

    When the user clicks on the main menu
    And the user selects the 'WTEC' option
    And the user clicks on the 'Steel' option
    And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
    Then  the BOL list page is displayed
