using ProtoBuf.Grpc.Server;
using RadicalR.Server;

namespace Undersoft.AEP.Api
{
    public class EngineStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCodeFirstGrpc(config =>
            {
                config.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.NoCompression;
            });
            services.AddServiceSetup()
                .ConfigureServices();

            //services.AddSingleton<ICounter, Counter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAppSetup(env, false)
                .UseInternalProvider();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGrpcService<ICounter>();
                //endpoints.MapCodeFirstGrpcReflectionService();
            });
        }
    }
}