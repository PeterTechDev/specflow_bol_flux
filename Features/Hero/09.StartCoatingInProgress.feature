Feature: 09. Start Coating in progress

    Background:
        Given the user is logged into Hero with username 'psouza' and password 'Wtec123!'
        And the user is on the Hero home page
        When the user clicks on the main menu
        And the user selects the 'WTEC' option
        And the user clicks on the 'Steel' option
        And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
        Then the BOL list page is displayed

    @TestCaseKey=PSP-T36 @9
    Scenario Outline: 9. Start Coating in progress
        
        When the user enters "<bolNumber>" into the search field
        Then the Rubicon status should be "<rubiconStatus>"
        When the user clicks in the Select button
        Then the user clicks in the button "coating in progress"
        Then the "<pageTitle>" page for "<bolNumber>" is displayed
        And the user fills in a valid Internal job number "<internalJobNumber>"
        And the user enters a valid estimated coating completion date "<completionDate>"
        And the user enters a valid estimated pickup date "<pickupDate>"
        And the user clicks on Save button
        Then the message "<sucessMessage>" is displayed
        
        Examples:
| bolNumber            | internalJobNumber | completionDate | pageTitle           | sucessMessage           | pickupDate | rubiconStatus         |
| MNST-GALV-GUST-719-1 | 123               | 2/29/2024      | Coating in Progress | BOL coating in progress | 2/29/2024  | At Coating Applicator |