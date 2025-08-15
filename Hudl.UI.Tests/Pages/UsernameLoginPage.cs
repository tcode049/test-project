using Hudl.UI.Tests.Configurations;
using Hudl.UI.Tests.Utils.Environment;
using JetBrains.Annotations;
using OpenQA.Selenium;

namespace Hudl.UI.Tests.Pages;

[UsedImplicitly]
public class UsernameLoginPage(IWebDriver driver, TestConfiguration testConfiguration) : LoginPage(driver, testConfiguration)
{
    protected override string Path => "/u/login/identifier";
    private readonly By _usernameErrorMessage = By.CssSelector(".ulp-error-info.aria-error-check.ulp-validator-error");
    private readonly By _usernameField = By.Id("username");
    
    public void EnterValidUsername() => TypeUsername(EnvironmentUtils.GetAllowedEnvironmentVariableOrThrow(AllowedEnvironmentVariables.UiUsername));
    public void TypeUsername(string text) => InputText(_usernameField, text);
    public void VerifyUsernameErrorMessage(string expectedErrorMessage) => VerifyText(_usernameErrorMessage, expectedErrorMessage);
}