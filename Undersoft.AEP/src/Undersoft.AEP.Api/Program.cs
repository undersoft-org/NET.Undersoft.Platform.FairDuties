using Microsoft.AspNetCore;
namespace Undersoft.AEP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 .ConfigureKestrel((c, o) => o.Configure(c.Configuration.GetSection("Kestrel")))
                 .UseStartup<EngineStartup>();
    }
}