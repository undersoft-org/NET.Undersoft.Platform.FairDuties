using BootstrapBlazor.Shared;
using Longbow.Tasks;
using Microsoft.Extensions.Options;

namespace BootstrapBlazor.Server.Services;

internal class ClearUploadFilesService : BackgroundService
{
    private readonly IWebHostEnvironment _env;

    public ClearUploadFilesService(IWebHostEnvironment env, IOptionsMonitor<WebsiteOptions> websiteOption)
    {
        _env = env;
        websiteOption.CurrentValue.WebRootPath = env.WebRootPath;
        websiteOption.CurrentValue.ContentRootPath = env.ContentRootPath;
        websiteOption.CurrentValue.IsDevelopment = env.IsDevelopment();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _ = TaskServicesManager.GetOrAdd("Clear Upload Files", token =>
        {
            var webSiteUrl = $"images{Path.DirectorySeparatorChar}uploader{Path.DirectorySeparatorChar}";
            var filePath = Path.Combine(_env.WebRootPath, webSiteUrl);
            if (Directory.Exists(filePath))
            {
                Directory.EnumerateFiles(filePath).Take(10).ToList().ForEach(file =>
                {
                    try
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }

                        File.Delete(file);
                    }
                    catch
                    {
                    }
                });
            }

            return Task.CompletedTask;
        }, TriggerBuilder.Build(Cron.Minutely(10)));

        return Task.CompletedTask;
    }
}
