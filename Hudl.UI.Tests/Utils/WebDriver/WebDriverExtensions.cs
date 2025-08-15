using OpenQA.Selenium;

namespace Hudl.UI.Tests.Utils.WebDriver;

public static class WebDriverExtensions
{
    public static IWebElement WaitUntilElementLocated(this IWebDriver driver, By selector) =>
        CustomWebDriverWait.NewWait(driver).UntilElementLocated(selector);

    public static void WaitUntilUrlIsPresent(this IWebDriver driver, string url) =>
        CustomWebDriverWait.NewWait(driver).UntilPageUrlIsPresent(url);
}