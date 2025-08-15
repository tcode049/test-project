using System.Diagnostics.CodeAnalysis;
using Hudl.UI.Tests.Utils.Environment;
using Hudl.UI.Tests.Utils.WebDriver;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Hudl.UI.Tests.Configurations;

[UsedImplicitly]
[method: System.Text.Json.Serialization.JsonConstructor]
[method: SetsRequiredMembers]
public class TestConfiguration(
    BrowserType browserType,
    string baseUrl,
    string loginUrl)
{
    public static readonly TestConfiguration TestConfig = Get();
    public BrowserType BrowserType { get; } = browserType;
    public string BaseUrl { get; } = baseUrl;
    public string LoginUrl { get; } = loginUrl;

    private static TestConfiguration Get()
    {
        var jsonFileName = GetWebEnvironmentNameOrDefault() + ".json";
        var configurationDir = Path.Combine("Resources", "Configuration");
        var envDir = Path.Combine(configurationDir, "Environment");
        var jsonFileDir = Path.Combine(envDir, jsonFileName);
        var fileContents = File.ReadAllText(jsonFileDir);

        return ParseJsonDictionary<TestConfiguration>(fileContents)
               ?? throw new NullReferenceException("No configuration file found.");
    }

    private static T? ParseJsonDictionary<T>(string contents) => JsonConvert.DeserializeObject<T>(contents);

    private static string GetWebEnvironmentNameOrDefault() =>
        EnvironmentUtils.GetAllowedEnvironmentVariable(AllowedEnvironmentVariables.WebEnvironment) ?? "LocalTest";
}