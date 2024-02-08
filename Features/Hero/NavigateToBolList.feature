﻿Feature: Navigate to BOL List in Hero System
    @TestCaseKey=PSP-T28

    @NavigateToBOLsList
    Scenario: Navigate to BOL List in Hero System
        Given the user is logged into Rubicon with username 'psouza' and password 'Wtec123!'
        And the user is on the Hero home page
        When the user clicks on the main menu
        And the user selects the 'WTEC' option
        And the user clicks on the 'Steel' option
        And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
        Then  the BOL list page is displayed
