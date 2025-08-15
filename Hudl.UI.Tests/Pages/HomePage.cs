using Hudl.UI.Tests.Configurations;
using JetBrains.Annotations;
using OpenQA.Selenium;

namespace Hudl.UI.Tests.Pages;

[UsedImplicitly]
public class HomePage(IWebDriver driver, TestConfiguration testConfiguration) : BasePage(driver, testConfiguration)
{
    protected override string Path => "/home";
}