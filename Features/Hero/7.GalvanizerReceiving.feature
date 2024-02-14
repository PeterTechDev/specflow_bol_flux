Feature: 7. Galvanizer Receiving

    Background:
        Given the user is logged into Hero with username 'psouza' and password 'Wtec123!'
        And the user is on the Hero home page
        When the user clicks on the main menu
        And the user selects the 'WTEC' option
        And the user clicks on the 'Steel' option
        And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
        Then the BOL list page is displayed

    @TestCaseKey=PSP-T34
    Scenario Outline: 7. Galvanizer Receiving
        
        When the user enters "<bolNumber>" into the search field
        And the user clicks in the Select button
        And the user clicks in the button "Receive"
        Then the Receive page for "<bolNumber>" is displayed
        When the user fills in a valid Internal job number "<internalJobNumber>"
        And the user enters a valid estimated coating completion date "<completionDate>"
        And the user fills in the pieces received number "<piecesReceived>"
        And the user attaches a signed BOL picture
        And the user clicks on Save button
        Then the message "BOL received" is displayed
        
        Examples:
        | bolNumber                 | internalJobNumber | completionDate | piecesReceived |
        | MNST-GALV-GUST-650-1      | 123                 | 02/14/2024     | 10           | 