Feature:05. Ship to Coating Applicaor Inspection

Background:
    Given the user is logged into Hero with username 'talmeida ' and password 'Tpa1234!'
    And the user is on the Hero home page
    When the user clicks on the main menu
    And the user selects the 'WTEC' option
    And the user clicks on the 'Steel' option
    And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
    Then the BOL list page is displayed

@TestCaseKey=PSP-T32 @5
Scenario: 5. Ship to Coating Applicator Inspection

    When the user enters "<bolNumber>" into the search field
    When the user clicks in the Select button
    Then the user clicks in the button "Ship to Coating Applicator"
    And the user enters a valid LRB number "<lrbNumber>" and adds it to the BOL
    When the user attaches image files for inspection
    Then the user clicks on Save button
    Then message "The Shipping Inspection was filled out and Passed" is displayed
    

        Examples: 
| bolNumber            | lrbNumber |
| MNST-GALV-GUST-719-1 | 19446946  |
