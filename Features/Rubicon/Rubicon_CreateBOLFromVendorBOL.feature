Feature: 15. Create Bol from Vendor BOL

    @15
    Scenario: 15. Create Bol from Vendor BOL

        Given the Rubicon login page is displayed
        When the user enters valid login credentials
        And the user clicks the Login button
        When the user clicks on the Customer icon
        And the user fills in '<salesOrderNumber>' in the Sales Order Number input
        Then the Purchase Order '<salesOrderNumber>' details page is displayed
        When I click the actions button
        
        And I select the 'Create BOL From Vendor BOL' option
        And "Select Vendor BOL" page is displayed
        And the user select "<BOLCode>" item from the dropdown "vendorBolId"
        When the user clicks on "Submit"
        Then "Customer Bill Of Lading Entry" page is displayed
        When the user clicks on "Submit"
        Then the new BOL detail page with related "<BOLCode>" is displayed

        Examples:
| salesOrderNumber | BOLCode               |
| 132813           | MNST-GALV-GUST-719-1  |
