using Undersoft.ODP.Infra.Data.Base.Contexts;
using RadicalR.Server;
using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddServerSetup()
                .ConfigureServices(true)
                .AddDataServices<ICqrsStore>(
                    DataServiceTypes.All,
                    builder =>
                        builder
                            .AddDataService<EntryDb>()
                            .AddDataService<ReportDb>()
                )
                .AddDataServices<IEventStore>(
                    DataServiceTypes.All,
                    builder =>
                        builder.AddDataService<EventDb>()
                );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAppSetup(env)
                .UseInternalProvider()
                .UseDataMigrations();
        }
    }
}
