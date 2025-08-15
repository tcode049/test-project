using Hudl.UI.Tests.Pages;
using TechTalk.SpecFlow;

namespace Hudl.UI.Tests.Steps;

[Binding]
public class PasswordLoginSteps(PageFactory pageFactory)
{
    private readonly PasswordLoginPage _page = pageFactory.Create<PasswordLoginPage>();

    [When("I type (.*) into the password field")]
    public void WhenITypeIntoThePasswordField(string text) => _page.TypePassword(text);

    [When("I am on the Password Login page")]
    public void WhenIAmOnThePasswordLoginPage() =>
        _page.VerifyUrl();

    [When("I enter a valid password")]
    public void WhenIEnterAValidPassword() => _page.EnterValidPassword();

    [Then("I expect the password error message is (.*)")]
    public void ThenIExpectThePasswordErrorMessageIs(string errorMessage) => _page.VerifyPasswordErrorMessage(errorMessage);
}