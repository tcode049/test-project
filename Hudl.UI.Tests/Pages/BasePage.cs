using System.Text.RegularExpressions;
using FluentAssertions;
using Hudl.UI.Tests.Configurations;
using Hudl.UI.Tests.Utils.WebDriver;
using OpenQA.Selenium;

namespace Hudl.UI.Tests.Pages;

public abstract partial class BasePage(IWebDriver driver, TestConfiguration testConfiguration)
{
    public void GoToPage() => driver.Url = GetExpectedUrl();

    public void VerifyUrl()
    {
        HasUrlSettled();
        GetCurrentUrl().Should().Be(GetExpectedUrl());
    }
    
    protected void PressKeys(By selector, params string[] keys)
    {
        foreach (var key in keys)
            driver.WaitUntilElementLocated(selector).SendKeys(key);
    }

    protected void Click(By selector) => driver.WaitUntilElementLocated(selector).Click();

    protected abstract string Path { get; }

    protected void InputText(By selector, string input)
    {
        var element = driver.WaitUntilElementLocated(selector);
        element.Clear();
        element.SendKeys(input);
    }

    protected void VerifyText(By selector, string expectedText)
    {
        var element = driver.WaitUntilElementLocated(selector);
        var actualText = element.Text;
        actualText.Should().Be(expectedText, $"Expected text in {selector} to be {expectedText} but was {actualText}");
    }


    protected virtual string GetExpectedBaseUrl() => testConfiguration.BaseUrl;
    private void HasUrlSettled() => driver.WaitUntilUrlIsPresent(GetExpectedUrl());
    private string GetExpectedUrl() => $"{GetExpectedBaseUrl()}/{RemoveFirstSlash(Path)}";

    private string GetCurrentUrl() => new Uri(driver.Url).GetLeftPart(UriPartial.Path);

    private static string RemoveFirstSlash(string endpoint) => StartingSlashRegex().Replace(endpoint, "$1");

    [GeneratedRegex("^\\/(.*)")]
    private static partial Regex StartingSlashRegex();
}