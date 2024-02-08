@PurchaseOrderSearch
Feature: Purchase Order Search Functionality

  @SearchPurchaseOrder
  Scenario: Search for a Purchase Order and view its details
    Given the Rubicon login page is displayed
    When the user enters valid login credentials
    And the user clicks the Login button
    When the user clicks on the 'Vendor Search' icon
    And the user fills in '<PurchaseOrderNumber>' in the 'Purchase Order Number' input
    And the user presses enter
    Then the Purchase Order '<PurchaseOrderNumber>' details page is displayed

            Examples:
    | PurchaseOrderNumber |
    | 40532                 |

  Scenario: Search for a Purchase Order with invalid number
    Given the Rubicon login page is displayed
    When the user enters valid login credentials
    And the user clicks the Login button
    When the user clicks on the 'Vendor Search' icon
    And the user fills in '00000' in the 'Purchase Order Number' input
    And the user presses enter
    Then the error message 'Purchase Order could not be found' is displayed

