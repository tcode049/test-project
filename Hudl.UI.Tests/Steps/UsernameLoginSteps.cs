using Hudl.UI.Tests.Pages;
using TechTalk.SpecFlow;

namespace Hudl.UI.Tests.Steps;

[Binding]
public class UsernameLoginSteps(PageFactory pageFactory)
{
    private readonly UsernameLoginPage _page = pageFactory.Create<UsernameLoginPage>();

    [When("I type (.*) into the username field")]
    public void WhenITypeIntoTheUsernameField(string text) => _page.TypeUsername(text);

    [Given("I am on the Username Login page")]
    [When("I am on the Username Login page")]
    public void GivenIAmOnTheUsernameLoginPage() =>
        _page.VerifyUrl();

    [When("I enter a valid username")]
    public void WhenIEnterAValidUsername() => _page.EnterValidUsername();

    [Then("I expect the username error message is (.*)")]
    public void ThenIExpectTheUsernameErrorMessageIs(string errorMessage) => _page.VerifyUsernameErrorMessage(errorMessage);

    [When("I press the return key")]
    public void WhenIPressTheReturnKey() => _page.PressReturnKey();

    [When("I click continue")]
    public void WhenIClickContinue() => _page.ClickContinue();
}