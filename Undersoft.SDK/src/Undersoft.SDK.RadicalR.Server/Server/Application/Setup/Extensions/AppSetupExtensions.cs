﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace RadicalR.Server
{
    public static class AppSetupExtensions
    {
        public static IAppSetup UseAppSetup(this IApplicationBuilder app, IWebHostEnvironment env, bool useSwagger = true)
        {
            return new AppSetup(app, env, useSwagger);
        }
        public static IAppSetup UseAppSetup(this IApplicationBuilder app, IWebHostEnvironment env, string[] apiVersions)
        {
            return new AppSetup(app, env,apiVersions);
        }
        public static IApplicationBuilder UseExternalProvider(this IApplicationBuilder app)
        {
            new AppSetup(app).UseExternalProvider();
            return app;
        }

        public static IApplicationBuilder UseInternalProvider(this IApplicationBuilder app)
        {
            new AppSetup(app).UseInternalProvider();
            return app;
        }

        public static IApplicationBuilder RebuildProviders(this IApplicationBuilder app)
        {
            new AppSetup(app).RebuildProviders();
            return app;
        }
    }
}