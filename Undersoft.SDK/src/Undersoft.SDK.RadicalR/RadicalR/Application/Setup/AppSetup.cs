using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Logs;

namespace RadicalR
{
    public partial class AppSetup : IAppSetup
    {
        public static bool usedExternal;

        IApplicationBuilder app;
        IWebHostEnvironment env;

        public AppSetup(IApplicationBuilder application) { app = application; }

        public AppSetup(IApplicationBuilder application, IWebHostEnvironment environment, bool useSwagger)
        {
            app = application;
            env = environment;
            UseStandardSetup(useSwagger ? new string[] { "1" } : null);
        }

        public AppSetup(IApplicationBuilder application, IWebHostEnvironment environment, string[] apiVersions = null)
        {
            app = application;
            env = environment;
            UseStandardSetup(apiVersions);
        }

        public IAppSetup RebuildProviders()
        {
            if (usedExternal)
            {
                UseExternalProvider();
            }
            else
            {
                UseInternalProvider();
            }

            return this;
        }

        public void UseEndpoints()
        {
            app.UseEndpoints(endpoints =>
            {
                var method = typeof(GrpcEndpointRouteBuilderExtensions).GetMethods().Where(m => m.Name.Contains("MapGrpcService")).FirstOrDefault().GetGenericMethodDefinition();
                IDeck<Type> serviceContracts = GrpcServiceRegistry.ServiceContracts;
                foreach (var serviceContract in serviceContracts)
                    method.MakeGenericMethod(serviceContract).Invoke(endpoints, new object[] { endpoints });

                endpoints.MapCodeFirstGrpcReflectionService();
                endpoints.MapControllers();
            });
        }

        public IAppSetup UseDataClients()
        {
            RepositoryManager.LoadClientEdms(app).ConfigureAwait(true);
            return this;
        }

        public IAppSetup UseDataMigrations()
        {
            using (IServiceScope scope = ServiceManager.GetProvider().CreateScope())
            {
                try
                {
                    IServicer us = scope.ServiceProvider.GetRequiredService<IServicer>();
                    us.GetEndpoints().ForEach(e => ((DbContext)e.Context).Database.Migrate());
                }
                catch (Exception ex)
                {
                    this.Error<Applog>("Data migration initial create - unable to connect the database engine", null, ex);
                }
            }

            return this;
        }

        public IAppSetup UseExternalProvider()
        {
            IServiceManager sm = ServiceManager.GetManager();
            sm.Registry.MergeServices(false);
            ServiceManager.SetProvider(app.ApplicationServices);
            usedExternal = true;
            return this;
        }

        public IAppSetup UseInternalProvider()
        {
            IServiceManager sm = ServiceManager.GetManager();
            sm.Registry.MergeServices();
            app.ApplicationServices = ServiceManager.BuildInternalProvider();
            usedExternal = false;
            return this;
        }

        public IAppSetup UseStandardSetup(string[] apiVersions = null)
        {
            UseHeaderForwarding();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseODataBatching();
            app.UseODataQueryRequest();

            app.UseRouting();

            app.UseCors();

            if (apiVersions != null)
                UseSwaggerSetup(apiVersions);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            UseEndpoints();

            return this;
        }

        public IAppSetup UseSwaggerSetup(string[] apiVersions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var ao = ServiceManager.GetConfiguration().Identity;

            app.UseSwagger();
            app.UseSwaggerUI(
                s =>
                {
                    s.SwaggerEndpoint($"{ao.ApiBaseUrl}/swagger/v1/swagger.json", ao.ApiName);
                    s.OAuthClientId(ao.OidcSwaggerUIClientId);
                    s.OAuthAppName(ao.ApiName);
                });
            return this;
        }

        public IAppSetup UseHeaderForwarding()
        {
            var forwardingOptions = new ForwardedHeadersOptions()
            {
                ForwardedHeaders = ForwardedHeaders.All
            };

            forwardingOptions.KnownNetworks.Clear();
            forwardingOptions.KnownProxies.Clear();

            app.UseForwardedHeaders(forwardingOptions);

            return this;
        }

        public IAppSetup UseJwtUserInfo()
        {
            app.UseMiddleware<JwtMiddleware>();

            return this;
        }
    }
}