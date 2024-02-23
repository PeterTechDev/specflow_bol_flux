Feature: User Login to Rubicon

    @TestCaseKey=PSP-T18
    Scenario: User Login to Rubicon
        
            Given the Rubicon login page is displayed
            When the user enters valid login credentials
            And the user clicks the Login button
            Then the Rubicon Home Page is displayed
