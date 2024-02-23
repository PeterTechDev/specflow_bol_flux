Feature: 18. Ship to Customer

    Background:
        Given the user is logged into Hero with username 'psouza' and password 'Wtec123!'
        And the user is on the Hero home page
        When the user clicks on the main menu
        And the user selects the 'WTEC' option
        And the user clicks on the 'Steel' option
        And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
        Then the BOL list page is displayed

    @TestCaseKey=PSP-T44
    Scenario Outline: 18. Ship to customer
        
        When the user enters "<bolNumber>" into the search field
        When the user clicks in the customer Select button
        And the user clicks the customer "Ship to Customer" button
        Then the user enters a valid LRB number "<lrbNumber>" and adds it to the BOL
        When the user attaches image files for inspection
        Then the user clicks on Save button
        Then the message "<successMessage>" is displayed
        
Examples:
| bolNumber     | lrbNumber | successMessage                                    |
| GALV-GUST-704 | 19447086  | The Shipping Inspection was filled out and Passed |