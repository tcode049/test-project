using Hudl.UI.Tests.Pages;
using TechTalk.SpecFlow;

namespace Hudl.UI.Tests.Steps;

[Binding]
internal class LandingPageSteps(PageFactory pageFactory)
{
    private readonly LandingPage _page = pageFactory.Create<LandingPage>();

    [Given("I am on the Landing page")]
    public void GivenIAmOnTheLandingPage() => _page.VerifyUrl();
    
    
    [Given("I click the login button")]
    public void GivenIClickTheLoginButton() =>
        _page.ClickLoginButton();

    [Given("I click Hudl")]
    public void GivenIClickHudl() => _page.ClickHudl();
}