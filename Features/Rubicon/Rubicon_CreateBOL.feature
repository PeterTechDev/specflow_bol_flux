@CreateBOL
Feature: Bill of Lading Creation from Purchase Order Details

  Scenario: Create a Bill of Lading from the Purchase Order '40539' details page
    Given the Rubicon login page is displayed
    When the user enters valid login credentials
    And the user clicks the Login button
    When the user clicks on the 'Vendor Search' icon
    And the user fills in '<PurchaseOrderNumber>' in the 'Purchase Order Number' input
    And the user presses enter
    Then the Purchase Order '<PurchaseOrderNumber>' details page is displayed
    When I click the 'Actions' button
    And I select 'Create BOL' from the Actions dropdown
    Then the 'Coating Applicator Bill Of Lading Entry' page is displayed
    When I click the 'Submit' button on the BOL Entry page
    Then a message 'BOL successfully created' is displayed

    Examples:
    | PurchaseOrderNumber |
    | 40532                 |
