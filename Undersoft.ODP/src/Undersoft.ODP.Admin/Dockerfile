#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Undersoft.ODP/src/Undersoft.ODP.Admin/Undersoft.ODP.Admin.csproj", "Undersoft.ODP/src/Undersoft.ODP.Admin/"]
COPY ["Undersoft.ODP/src/Undersoft.ODP/Undersoft.ODP.csproj", "Undersoft.ODP/src/Undersoft.ODP/"]
COPY ["OpenSource.SDK/UltimatR/OpenSource.SDK.csproj", "OpenSource.SDK/UltimatR/"]
RUN dotnet restore "Undersoft.ODP/src/Undersoft.ODP.Admin/Undersoft.ODP.Admin.csproj"
COPY . .
WORKDIR "/src/Undersoft.ODP/src/Undersoft.ODP.Admin"
RUN dotnet build "Undersoft.ODP.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Undersoft.ODP.Admin.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Undersoft.ODP.Admin.dll"]