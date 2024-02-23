Feature: 16. Ticket Creation in Rubicon

    @TestCaseKey=PSP-T43 @16
    Scenario Outline: 16. Ticket Creation in Rubicon

        Given the Rubicon login page is displayed
        When the user enters valid login credentials
        And the user clicks the Login button
        When the user clicks on the Customer icon
        And the user fills in '<salesOrderNumber>' in the Sales Order Number input
        Then the Purchase Order '<salesOrderNumber>' details page is displayed
        When I click the actions button
        And I select the 'Create Ticket' option
        Then the "Create Ticket" page is displayed
        When the user select "<BolCode>" item from the dropdown "bolId"
        And the user selects the correct LRB "<lrbNumber>" from the list
        When the user clicks on "Submit"
        Then a sucessful message "<successMessage>" is displayed

        
          Examples:
| salesOrderNumber | BolCode       | lrbNumber | successMessage       |
| 132813           | GALV-GUST-706 | 19447087  | created successfully |