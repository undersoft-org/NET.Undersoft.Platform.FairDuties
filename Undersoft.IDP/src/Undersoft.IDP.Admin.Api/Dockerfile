#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.Api/Undersoft.IDP.Admin.Api.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.Api/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.BusinessLogic.Identity/Undersoft.IDP.Admin.BusinessLogic.Identity.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.BusinessLogic.Identity/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.BusinessLogic.Shared/Undersoft.IDP.Admin.BusinessLogic.Shared.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.BusinessLogic.Shared/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.Identity/Undersoft.IDP.Admin.EntityFramework.Identity.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.Identity/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework/Undersoft.IDP.Admin.EntityFramework.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.Extensions/Undersoft.IDP.Admin.EntityFramework.Extensions.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.Extensions/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.AuditLogging.EntityFramework/Undersoft.IDP.AuditLogging.EntityFramework.csproj", "Undersoft.IDP/src/Undersoft.IDP.AuditLogging.EntityFramework/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.AuditLogging/Undersoft.IDP.AuditLogging.csproj", "Undersoft.IDP/src/Undersoft.IDP.AuditLogging/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.BusinessLogic/Undersoft.IDP.Admin.BusinessLogic.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.BusinessLogic/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.MySql/Undersoft.IDP.Admin.EntityFramework.MySql.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.MySql/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.Shared/Undersoft.IDP.Admin.EntityFramework.Shared.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.Shared/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.Configuration/Undersoft.IDP.Admin.EntityFramework.Configuration.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.Configuration/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.PostgreSQL/Undersoft.IDP.Admin.EntityFramework.PostgreSQL.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.PostgreSQL/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.SqlServer/Undersoft.IDP.Admin.EntityFramework.SqlServer.csproj", "Undersoft.IDP/src/Undersoft.IDP.Admin.EntityFramework.SqlServer/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Shared.Configuration/Undersoft.IDP.Shared.Configuration.csproj", "Undersoft.IDP/src/Undersoft.IDP.Shared.Configuration/"]
COPY ["Undersoft.IDP/src/Undersoft.IDP.Shared/Undersoft.IDP.Shared.csproj", "Undersoft.IDP/src/Undersoft.IDP.Shared/"]
RUN dotnet restore "Undersoft.IDP/src/Undersoft.IDP.Admin.Api/Undersoft.IDP.Admin.Api.csproj"
COPY . .
WORKDIR "/src/Undersoft.IDP/src/Undersoft.IDP.Admin.Api"
RUN dotnet build "Undersoft.IDP.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Undersoft.IDP.Admin.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Undersoft.IDP.Admin.Api.dll"]