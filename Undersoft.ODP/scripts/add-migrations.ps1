Write-Host "Updating dotnet ef tools"
$env:Path += "	% USERPROFILE % \.dotnet\tools";
dotnet tool update --global dotnet-ef
cd ../src/Undersoft.ODP
dotnet ef migrations add InitialCreate --context EntryDbContext --output-dir Infra/Data/Base/Migrations/Entry
dotnet ef migrations add InitialCreate --context EventDbContext --output-dir Infra/Data/Base/Migrations/Event
dotnet ef migrations add InitialCreate --context ReportDbContext --output-dir Infra/Data/Base/Migrations/Report