using Hudl.UI.Tests.Pages;
using TechTalk.SpecFlow;

namespace Hudl.UI.Tests.Steps;

[Binding]
public class HomeSteps(PageFactory pageFactory)
{
    private readonly HomePage _page = pageFactory.Create<HomePage>();

    [Given("I am on the Home page")]
    [When("I am on the Home page")]
    [Then("I am on the Home page")]
    public void ThenIAmOnTheHomePage() =>
        _page.VerifyUrl();
}