using Hudl.UI.Tests.Configurations;
using JetBrains.Annotations;
using OpenQA.Selenium;

namespace Hudl.UI.Tests.Pages;

[UsedImplicitly]
public class LandingPage(IWebDriver driver, TestConfiguration testConfiguration) : BasePage(driver, testConfiguration)
{
    private readonly By _expandableLogin = By.CssSelector("[data-qa-id='login-select']");
    private readonly By _hudlLogin = By.CssSelector("[data-qa-id='login-hudl']");
    protected override string Path => "/en_gb/";

    public void ClickLoginButton() => Click(_expandableLogin);

    public void ClickHudl() => Click(_hudlLogin);
}