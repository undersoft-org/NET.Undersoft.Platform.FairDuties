using RadicalR.Server;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServerSetupExtensions
    {
        public static IServiceSetup AddServerSetup(this IServiceCollection services, IMvcBuilder mvcBuilder = null)
        {
            return new ServiceSetup(services);
        }
    }
}
