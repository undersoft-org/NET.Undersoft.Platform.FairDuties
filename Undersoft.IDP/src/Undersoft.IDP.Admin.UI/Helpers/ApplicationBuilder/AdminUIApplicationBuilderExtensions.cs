using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Undersoft.IDP.Admin.UI.Configuration;
using Undersoft.IDP.Admin.UI.Helpers;
using Undersoft.IDP.Admin.UI.Middlewares;
using System;
using System.Collections.Generic;
using Undersoft.IDP.Admin.UI.Configuration.Constants;

namespace Microsoft.AspNetCore.Builder
{
    public static class AdminUIApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseIdentityServer4AdminUI(this IApplicationBuilder app)
        {
            app.UseRoutingDependentMiddleware(app.ApplicationServices.GetRequiredService<TestingConfiguration>());

            return app;
        }

        public static IEndpointConventionBuilder MapIdentityServer4AdminUI(this IEndpointRouteBuilder endpoint, string patternPrefix = "/")
        {
            return endpoint.MapAreaControllerRoute(CommonConsts.AdminUIArea, CommonConsts.AdminUIArea, patternPrefix + "{controller=Home}/{action=Index}/{id?}");
        }

        public static IEndpointConventionBuilder MapIdentityServer4AdminUIHealthChecks(this IEndpointRouteBuilder endpoint, string pattern = "/health", Action<HealthCheckOptions> configureAction = null)
        {
            var options = new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            };

            configureAction?.Invoke(options);

            return endpoint.MapHealthChecks(pattern, options);
        }
    }
}
