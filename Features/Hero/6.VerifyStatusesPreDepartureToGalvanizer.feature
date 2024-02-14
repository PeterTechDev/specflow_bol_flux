﻿Feature: 6. Verify Statuses - BOL Pre-Departure to Galvanizer

    Background:
        Given the user is logged into Hero with username 'psouza' and password 'Wtec123!'
        And the user is on the Hero home page
        When the user clicks on the main menu
        And the user selects the 'WTEC' option
        And the user clicks on the 'Steel' option
        And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
        Then the BOL list page is displayed

    @TestCaseKey=PSP-T33
    Scenario: 6. Verify Statuses - BOL PreDeparture to Galvanizer
        
        When the user enters "<bolNumber>" into the search field
        Then "<bolNumber>" should be displayed in the search results
        Then the Rubicon status should be "<rubiconStatus>"
        And the Hero Status should be "<heroStatus>"
        And the QC Inspection status should be "<qcStatus>"
        And the Shipping Inspection status should be "<shippingStatus>"

        Examples:
| bolNumber            | rubiconStatus | heroStatus                     | qcStatus  | shippingStatus |
| MNST-GALV-GUST-602-1 | In Transit    | Shipped To Coating Applicator | Pending   | Passed        |