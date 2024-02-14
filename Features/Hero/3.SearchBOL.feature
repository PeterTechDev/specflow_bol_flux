Feature:3. Search for a Specific BOL in the List

Background:
    Given the user is logged into Hero with username 'psouza' and password 'Wtec123!'
    And the user is on the Hero home page
    When the user clicks on the main menu
    And the user selects the 'WTEC' option
    And the user clicks on the 'Steel' option
    And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
    Then the BOL list page is displayed

@TestCaseKey=PSP-T30
Scenario:3. Search for a Specific BOL in the List
        
    When the user enters "<bolNumber>" into the search field
    Then "<bolNumber>" should be displayed in the search results

    Examples: 
| bolNumber            |
| MNST-GALV-GUST-639-1 |
