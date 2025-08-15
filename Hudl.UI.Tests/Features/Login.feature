@UI
Feature: Hudl Login

    Background:
        Given I am on the Landing page
        And I click the login button
        And I click Hudl
        And I am on the Username Login page

    Scenario: Happy path - Login with valid credentials
        When I enter a valid username
        And I click continue
        And I am on the Password Login page
        And I enter a valid password
        And I click continue
        Then I am on the Home page

    Scenario Outline: Happy path - Continue using return key
        When I enter a valid username
        And I press the return key
        And I am on the Password Login page
        And I enter a valid password
        And I press the return key
        Then I am on the Home page

    Scenario Outline: Invalid email
        When I type <Email> into the username field
        And I click continue
        And I am on the Username Login page
        Then I expect the username error message is <ErrorMessage>

        Examples:
          | Scenario      | Email         | ErrorMessage           |
          | Empty email   |               | Enter an email address |
          | Invalid email | invalid</>1,: | Enter a valid email.   |

    Scenario Outline: Invalid password
        When I enter a valid username
        And I click continue
        And I am on the Password Login page
        And I type <Password> into the password field
        And I click continue
        And I am on the Password Login page
        Then I expect the password error message is <ErrorMessage>

        Examples:
          | Scenario         | Password      | ErrorMessage                                    |
          | Empty password   |               | Enter your password.                            |
          | Invalid password | invalid</>1,: | Your email or password is incorrect. Try again. |