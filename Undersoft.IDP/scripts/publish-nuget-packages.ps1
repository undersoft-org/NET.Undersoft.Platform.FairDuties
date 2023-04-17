param([string] $version, [string] $key)

dotnet nuget push ./packages/Undersoft.IDP.Admin.BusinessLogic.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/Undersoft.IDP.Admin.BusinessLogic.Identity.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/Undersoft.IDP.Admin.BusinessLogic.Shared.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json

dotnet nuget push ./packages/Undersoft.IDP.Admin.EntityFramework.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/Undersoft.IDP.Admin.EntityFramework.Extensions.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/Undersoft.IDP.Admin.EntityFramework.Identity.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/Undersoft.IDP.Admin.EntityFramework.Shared.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json

dotnet nuget push ./packages/Undersoft.IDP.Admin.EntityFramework.Configuration.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/Undersoft.IDP.Shared.Configuration.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json

dotnet nuget push ./packages/Undersoft.IDP.Admin.UI.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json