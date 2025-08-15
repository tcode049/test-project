#pragma warning disable CA1825
using BoDi;
using Hudl.UI.Tests.Configurations;
using Hudl.UI.Tests.Pages;
using Hudl.UI.Tests.Utils.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using TechTalk.SpecFlow;
using static Hudl.UI.Tests.Utils.WebDriver.BrowserType;

namespace Hudl.UI.Tests.Hooks;

[Binding]
public class Hooks(
    IObjectContainer objectContainer)
{
    [BeforeScenario]
    public void Setup()
    {
        var testConfig = TestConfiguration.TestConfig;

        var driver = LoadWebDriver(testConfig.BrowserType);

        var pageFactory = new PageFactory(driver, testConfig);
        pageFactory.Create<LandingPage>().GoToPage();

        objectContainer.RegisterInstanceAs(pageFactory);
    }

    [AfterScenario]
    public void TearDownAsync()
    {
        var pageFactory = objectContainer.Resolve<PageFactory>();
        pageFactory.DisposeDriver();
    }

    private static IWebDriver LoadWebDriver(BrowserType browserType)
    {
        return browserType switch
        {
            Chrome => new ChromeDriver(LoadDriverOptions<ChromeOptions>()),
            Firefox => new FirefoxDriver(LoadDriverOptions<FirefoxOptions>()),
            Edge => new EdgeDriver(LoadDriverOptions<EdgeOptions>()),
            Safari => new SafariDriver(LoadDriverOptions<SafariOptions>()),
            _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType,
                $"Configuration is not valid. {browserType}.")
        };
    }

    private static TDriverOptions LoadDriverOptions<TDriverOptions>() where TDriverOptions : DriverOptions
    {
        var options = Activator.CreateInstance<TDriverOptions>();
        options.PageLoadStrategy = PageLoadStrategy.Normal;
        return options;
    }
}