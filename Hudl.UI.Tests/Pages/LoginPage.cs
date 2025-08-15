using Hudl.UI.Tests.Configurations;
using JetBrains.Annotations;
using OpenQA.Selenium;

namespace Hudl.UI.Tests.Pages;

[UsedImplicitly]
public abstract class LoginPage(IWebDriver driver, TestConfiguration testConfiguration) : BasePage(driver, testConfiguration)
{
    private readonly TestConfiguration _testConfiguration = testConfiguration;
    private readonly By _continueButton = By.CssSelector("button[type='submit']");
    protected override string GetExpectedBaseUrl() => _testConfiguration.LoginUrl;
    
    public void ClickContinue() => Click(_continueButton);

    public void PressReturnKey() => PressKeys(_continueButton, Keys.Return);
}