Feature:5. Ship to Coating Applicator Inspection

Background:
    Given the user is logged into Hero with username 'psouza' and password 'Wtec123!'
    And the user is on the Hero home page
    When the user clicks on the main menu
    And the user selects the 'WTEC' option
    And the user clicks on the 'Steel' option
    And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
    Then the BOL list page is displayed

@TestCaseKey=PSP-T32
Scenario: 5. Ship to Coating Applicator Inspection

    When the user enters "<bolNumber>" into the search field
    And the user clicks in the Select button
    And the user clicks in the button "Ship to Coating Applicator"
    And the user enters a valid LRB number "<lrbNumber>" and adds it to the BOL
    And the user attaches image files for inspection
    And the user clicks on Save button
    Then message "Pre-Departure Inspection was marked as Passed" is displayed

        Examples: 
| bolNumber            | lrbNumber  |
| MNST-GALV-GUST-650-1 |19445985    |
