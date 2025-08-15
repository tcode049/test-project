using Hudl.UI.Tests.Configurations;
using Hudl.UI.Tests.Utils.Environment;
using JetBrains.Annotations;
using OpenQA.Selenium;

namespace Hudl.UI.Tests.Pages;

[UsedImplicitly]
public class PasswordLoginPage(IWebDriver driver, TestConfiguration testConfiguration) : LoginPage(driver, testConfiguration)
{
    private readonly By _passwordField = By.Id("password");
    private readonly By _passwordErrorMessage = By.CssSelector(".ulp-validator-error, .ulp-input-error-message");
    protected override string Path => "/u/login/password";

    public void EnterValidPassword() => TypePassword(EnvironmentUtils.GetAllowedEnvironmentVariableOrThrow(AllowedEnvironmentVariables.UiPassword));
    public void TypePassword(string text) => InputText(_passwordField, text);
    public void VerifyPasswordErrorMessage(string expectedErrorMessage) => VerifyText(_passwordErrorMessage, expectedErrorMessage);
}