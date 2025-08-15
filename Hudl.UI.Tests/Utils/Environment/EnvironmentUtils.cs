using Hudl.UI.Tests.Configurations;

namespace Hudl.UI.Tests.Utils.Environment;

public static class EnvironmentUtils
{
    public static string? GetAllowedEnvironmentVariable(AllowedEnvironmentVariables name) =>
        System.Environment.GetEnvironmentVariable(name.ToString());

    public static string GetAllowedEnvironmentVariableOrThrow(AllowedEnvironmentVariables name) =>
        System.Environment.GetEnvironmentVariable(name.ToString()) ??
        throw new SystemException($"{name} was not found in environment variables.");
}