dotnet tool restore
dotnet restore
dotnet build --no-restore
dotnet stryker -tp tests/PowerUtils.BuildingBlocks.Domain.Tests/PowerUtils.BuildingBlocks.Domain.Tests.csproj --reporter cleartext --reporter html -o