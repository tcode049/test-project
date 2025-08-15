using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Hudl.UI.Tests.Utils.WebDriver;

public class CustomWebDriverWait
{
    private readonly WebDriverWait _fluentWait;

    private CustomWebDriverWait(IWebDriver driver, int duration)
    {
        _fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(duration));
        _fluentWait.IgnoreExceptionTypes(IgnoredTypes());
    }

    private static Type[] IgnoredTypes() =>
    [
        typeof(StaleElementReferenceException),
        typeof(ElementNotInteractableException),
        typeof(NoSuchElementException)
    ];

    public static CustomWebDriverWait NewWait(IWebDriver driver)
    {
        return new CustomWebDriverWait(driver, 10);
    }

    public IWebElement UntilElementLocated(By selector)
    {
        try
        {
            return _fluentWait.Until(driver => driver.FindElement(selector));
        }
        catch (Exception)
        {
            throw new Exception(selector + " was not located.");
        }
    }

    public void UntilPageUrlIsPresent(string url)
    {
        try
        {
            _fluentWait.Until(driver => driver.Url.StartsWith(url));
        }
        catch (Exception)
        {
            throw new Exception(url + " did not load.");
        }
    }
}