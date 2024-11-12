Feature: Blood Pressure Category Classification
  As a user of the Blood Pressure app
  I want to calculate my blood pressure readings
  So that I can understand my health status

  Scenario Outline: Calculate blood pressure readings
    Given I have entered a systolic pressure of <Systolic>
    And I have entered a diastolic pressure of <Diastolic>
    When I calculate the blood pressure
    Then the category should be "<Category>"

    Examples:
      | Systolic | Diastolic | Category                |
      | 80       | 50        | Low                     |
      | 110      | 70        | Ideal blood pressure    |
      | 130      | 85        | Pre-High blood pressure |
      | 150      | 95        | High blood pressure     |
