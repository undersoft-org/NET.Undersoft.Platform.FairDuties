using NLog.Web;
using System.Logs;

namespace Undersoft.ODP.Api
{
    public class Program
    {
        static string[] _args;
        static IWebHost _webapi;

        static IWebHost BuildWebApi()
        {
            WebHostBuilder builder = new WebHostBuilder();

            builder.Info<Runlog>("Starting AOS API ....");

            _webapi = builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(ConfigurationHelper.BuildConfiguration())
                .UseKestrel()
                .ConfigureKestrel((c, o) => o
                    .Configure(c.Configuration
                    .GetSection("Kestrel")))
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseNLog()
                .Build();
            return _webapi;
        }

        public static void Launch(string[] args)
        {
            try
            {
                _args = args;
                BuildWebApi()?.Run();
            }
            catch (Exception exception)
            {
                Log.Error<Runlog>(null, "AOS API terminated unexpectedly ....", exception);
            }
            finally
            {
                Log.Info<Runlog>(null, "AOS API shutted down ....");
            }
        }

        public static void Main(string[] args)
        {
            Launch(args);
        }

        public static async Task Restart()
        {
            Log.Info<Runlog>(null, "Restarting AOS API ....");

            Task.WaitAll(Shutdown());

            await Task.Run(() => Launch(_args));
        }

        public static async Task Shutdown()
        {
            Log.Info<Runlog>(null, "Shutting down AOS API ....");

            _webapi.Info<Runlog>("Stopping AOS API ....");

            await _webapi.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}
