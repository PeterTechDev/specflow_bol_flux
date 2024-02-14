Feature: 11. Complete Coating

    Background:
        Given the user is logged into Hero with username 'psouza' and password 'Wtec123!'
        And the user is on the Hero home page
        When the user clicks on the main menu
        And the user selects the 'WTEC' option
        And the user clicks on the 'Steel' option
        And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
        Then the BOL list page is displayed

    @TestCaseKey=PSP-T38
    Scenario Outline: 11. Complete Coating
        
        When the user enters "<bolCode>" into the search field
        And the user clicks in the Select button
        And the user clicks in the button "Coating Completed"
        Then the "<pageTitle>" page for "<bolCode>" is displayed
        And the user enters a valid available pickup date "<pickupDate>"
        And the user fills in the pieces coated number "<piecesCoated>"
        And the user attaches a xlsx file
        And the user clicks on Save button
        Then the message "<successMessage>" is displayed
     
        
          Examples:
| bolCode              | pageTitle         | pickupDate | successMessage                   | piecesCoated |
| MNST-GALV-GUST-651-1 | Coating Completed | 02/29/2024 | BOL updated to Coating Completed | 10           |