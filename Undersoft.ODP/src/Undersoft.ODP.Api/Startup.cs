using RadicalR;
using Undersoft.ODP.Infra.Data.Base.Contexts;

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
                .AddServiceSetup()
                .ConfigureServices()
                .AddDataServices<ICqrsStore>(
                    DataServiceTypes.All,
                    builder =>
                        builder
                            .AddDataService<EntryDb>()
                            .AddDataService<ReportDb>()
                //)
                //.AddDataServices<IEventStore>(
                //    DataServiceTypes.All,
                //    builder =>
                //        builder.AddDataService<EventDbContext>()
                );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAppSetup(env).UseInternalProvider().UseDataMigrations();
        }
    }
}
