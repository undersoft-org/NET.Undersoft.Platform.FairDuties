if ($env:NugetKey -eq $null)
{
    echo "请设置环境变量 NugetKey 上传秘钥"
    exit
}

if ($env:NugetSource -eq $null)
{
    echo "请设置环境变量 NugetSource 上传 Nuget 地址"
    exit
}

$currentProj = Get-Project

$projectFolder = Split-Path -parent $currentProj.FullName

$outFolder = -Join($projectFolder, "\bin\Release\")

Remove-Item $outFolder*.nupkg -recurse

$pkgName = -Join($outFolder, $currentProj.Name)

$pkgFileName = -Join($pkgName, "*.nupkg")

$spkgFileName = -Join($pkgName, "*.snupkg")

dotnet pack -c Release $currentProj.FullName

$done = Test-Path $pkgFileName

if ($done)
{
    dotnet nuget push -k $env:NugetKey -s $env:NugetSource $pkgFileName --skip-duplicate --no-symbols $spkgFileName
}
else 
{
    Write-Host "打包失败"
}
