$packagesOutput = ".\packages"

# Business Logic
dotnet pack .\..\src\Undersoft.IDP.Admin.BusinessLogic\Undersoft.IDP.Admin.BusinessLogic.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Undersoft.IDP.Admin.BusinessLogic.Identity\Undersoft.IDP.Admin.BusinessLogic.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Undersoft.IDP.Admin.BusinessLogic.Shared\Undersoft.IDP.Admin.BusinessLogic.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Undersoft.IDP.Shared.Configuration\Undersoft.IDP.Shared.Configuration.csproj -c Release -o $packagesOutput

# EF
dotnet pack .\..\src\Undersoft.IDP.Admin.EntityFramework\Undersoft.IDP.Admin.EntityFramework.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Undersoft.IDP.Admin.EntityFramework.Extensions\Undersoft.IDP.Admin.EntityFramework.Extensions.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Undersoft.IDP.Admin.EntityFramework.Identity\Undersoft.IDP.Admin.EntityFramework.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Undersoft.IDP.Admin.EntityFramework.Shared\Undersoft.IDP.Admin.EntityFramework.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Undersoft.IDP.Admin.EntityFramework.Configuration\Undersoft.IDP.Admin.EntityFramework.Configuration.csproj -c Release -o $packagesOutput

# UI
dotnet pack .\..\src\Undersoft.IDP.Admin.UI\Undersoft.IDP.Admin.UI.csproj -c Release -o $packagesOutput