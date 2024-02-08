Feature: Transfer LRB from BOL and Verify Status Change to 'In Transit'
    @TestCaseKey=PSP-T25

    @SearchBOLCodeandTransferLRB
     Scenario: Successfully transfer LRB and update BOL status to 'in transit'
        Given the Rubicon login page is displayed
        When the user enters valid login credentials
        And the user clicks the Login button
        When the user clicks on the 'Vendor Search' icon
        And the user fills in '<BOLCode>' in the Bill of Lading input
        Then the Purchase Order '<BOLCode>' details page is displayed
        And the user clicks on the '<BOLCode>' item

        Given I am on the BOL page '<BOLCode>'
        When the 'Hero Synced Status' is 'Yes'
        And I click the actions button
        And I select the 'Transfer LRBs' option
        And I select option '40532' from the dropdown
        And I click on the checkbox to confirm my selection
        And I click the submit button to complete the LRB transfer
        Then I am on the BOL page '<BOLCode>'
        And The BOL 'Status' should be 'In Transit'

        Examples:
        | BOLCode               |
        | MNST-GALV-GUST-607-1  |