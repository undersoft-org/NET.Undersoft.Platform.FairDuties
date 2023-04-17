using Undersoft.ODP.Infra.Data.Base.Contexts;
using UltimatR;

namespace Undersoft.ODP.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAppSetup(env)
                .UseInternalProvider()
                .UseDataMigrations();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var setup = services.AddServiceSetup()
                    .ConfigureServices()
                    .AddDataService<EntryDbContext>()
                    .AddDataService<EventDbContext>()
                    .AddDataService<ReportDbContext>()
                    .MergeServices();
        }

        public IConfiguration Configuration { get; }
    }
}
