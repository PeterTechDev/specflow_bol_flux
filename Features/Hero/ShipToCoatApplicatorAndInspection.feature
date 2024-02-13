Feature: Shipping to Coating Applicator and Inspection Verification

Background:
    Given the user is logged into Hero with username 'psouza' and password 'Wtec123!'
    And the user is on the Hero home page
    When the user clicks on the main menu
    And the user selects the 'WTEC' option
    And the user clicks on the 'Steel' option
    And the user navigates through 'Manufacturing', 'Bill of Lading', to 'List'
    Then the BOL list page is displayed


@TestCaseKey=PSP-T32
Scenario: Shipping to Coating Applicator and Inspection Verification
        
    When the user enters "<bolNumber>" into the search field
    When the user clicks in the Select button
    And the user clicks in the button "Ship to Coating Applicator"
    And the user enters a valid LRB number "19446445" and adds it to the BOL
    And the user attaches image files for inspection
    And the user clicks on Save button
    Then the Rubicon status should be "<rubiconStatus>"
    And the Hero Status should be "<heroStatus>"
    And the QC Inspection status should be "<qcStatus>"
    And the Shipping Inspection status should be "<shippingStatus>"

    Examples:
    | bolNumber            | rubiconStatus | heroStatus                       | qcStatus  | shippingStatus |
    | MNST-GALV-GUST-604-1 | In Transit    | Shipped to Coating Applicator    | Pending   | Passed         |