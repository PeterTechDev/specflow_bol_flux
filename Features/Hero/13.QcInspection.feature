Feature: 13.Quality Inspection

    Background:
        Given the user is logged into Hero with username 'psouza' and password 'Wtec123!'
        And the user is on the Hero home page
        When the user clicks on the main menu
        And the user selects the 'WTEC' option
        And the user clicks on the 'Steel' option
        And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
        Then the BOL list page is displayed

    @TestCaseKey=PSP-T40 @13
    Scenario: 13.Quality Inspection
        
        When the user enters "<bolNumber>" into the search field
        And the user clicks in the Select button
        Then the user clicks in the button "Quality Inspection"
        Then the Quality Inspection list is displayed
        When the user clicks the Select button for a BOL in the list
        And the user clicks the "Log QC" button
        Then the "Log Quality Inspection" page is displayed
        When the user checks "Yes" on the radio inputs for inspection criteria
        And the user attaches a picture file for the quality inspection evidence
        Then the user clicks on Save button
        Then message " was logged!" is displayed

        Examples:
| bolNumber            | rubiconStatus         | heroStatus        | qcStatus | shippingStatus |
| MNST-GALV-GUST-719-1 | At Coating Applicator | Coating Completed | Pending  | Passed         |