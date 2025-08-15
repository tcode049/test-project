## Pre-requisites

* [.NET 9.0](https://dotnet.microsoft.com/en-us/)
* [Powershell v7.5.2+](https://github.com/PowerShell/PowerShell/releases/tag/v7.5.2)

## Running tests

1. Open PowerShell
2. Set login credentials:
   ```pwsh
   $env:UiUsername = "REPLACE_WITH_USERNAME"
   $env:UiPassword = "REPLACE_WITH_PASSWORD"
   ```
3. Run tests using `dotnet test`