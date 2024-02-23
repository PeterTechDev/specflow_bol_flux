Feature: 17. Verify Statuses - After Ticket Creation

    Background:
        Given the Rubicon login page is displayed
        When the user enters valid login credentials
        And the user clicks the Login button
        When the user clicks on the Vendor Search icon

    @TestCaseKey=PSP-T41 @17
    Scenario: 17. Verify Statuses - After Ticket Creation
        
        When the user enters "<bolNumber>" into the search field
        Then "<bolNumber>" should be displayed in the search results
        Then the Rubicon status should be "<rubiconStatus>"
        And the Hero Status should be "<heroStatus>"
        And the QC Inspection status should be "<qcStatus>"
        And the Shipping Inspection status should be "<shippingStatus>"
        
        Examples:
| bolNumber            | rubiconStatus | heroStatus | qcStatus | shippingStatus |
| MNST-GALV-GUST-651-1 | TODO          | TODO       | Passed   | Passed         |