using System.Collections.Concurrent;
using Hudl.UI.Tests.Configurations;
using OpenQA.Selenium;

namespace Hudl.UI.Tests.Pages;

public class PageFactory(IWebDriver driver, TestConfiguration testConfig)
{
    private readonly ConcurrentDictionary<Type, BasePage> _cache = new();

    internal TPage Create<TPage>() where TPage : BasePage => (Create(typeof(TPage)) as TPage)!;
    private BasePage Create(Type type) => _cache.GetOrAdd(type, InvokeObjectAsBasePage);
    
    private BasePage InvokeObjectAsBasePage(Type type)
    {
        if (!typeof(BasePage).IsAssignableFrom(type))
            throw new Exception($"{type} does assign to {typeof(BasePage)}");

        return (BasePage)Activator.CreateInstance(type, driver, testConfig)!;
    }

    public void DisposeDriver() => driver.Dispose();
}