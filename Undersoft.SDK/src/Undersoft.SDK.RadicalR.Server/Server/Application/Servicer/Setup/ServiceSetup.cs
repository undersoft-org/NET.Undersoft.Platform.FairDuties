using AutoMapper;
using FluentValidation;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc.Server;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadicalR.Server
{
    public partial class ServiceSetup : RadicalR.ServiceSetup, IServiceSetup
    {
        public ServiceSetup(IServiceCollection services, IMvcBuilder mvcBuilder = null) : base(services, mvcBuilder)
        {
        }

        public ServiceSetup(IServiceCollection services, IConfiguration configuration)
            : base(services, configuration)
        {
        }     
      
        public IServiceRegistry Services => registry;

        public IServiceSetup AddDataServices<TServiceStore>(DataServiceTypes dataServiceTypes, Action<DataServiceBuilder> builder) where TServiceStore : IDataServiceStore
        {
            DataServiceBuilder.ServiceTypes = dataServiceTypes;
            if ((dataServiceTypes & DataServiceTypes.OData) > 0)
            {
                var ds = new OpenServiceBuilder<TServiceStore>();
                builder.Invoke(ds);
                ds.Build();
                ds.AddOData(mvc);
            }
            if ((dataServiceTypes & DataServiceTypes.Grpc) > 0)
            {
                var ds = new StreamServiceBuilder<TServiceStore>();
                builder.Invoke(ds);
                ds.Build();
            }
            return this;
        }

        public IServiceSetup AddMvcDataServiceSupport()
        {
            (mvc ??= Services.AddControllers()).AddMvcOptions(options =>
            {
                foreach (
                    OutputFormatter outputFormatter in options.OutputFormatters
                        .OfType<OutputFormatter>()
                        .Where(x => x.SupportedMediaTypes.Count == 0)
                )
                {
                    outputFormatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.odatatestxx-odata")
                    );
                }

                foreach (
                    InputFormatter inputFormatter in options.InputFormatters
                        .OfType<InputFormatter>()
                        .Where(x => x.SupportedMediaTypes.Count == 0)
                )
                {
                    inputFormatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.odatatestxx-odata")
                    );
                }
            });
            return this;
        }

        public IServiceSetup AddIdentityServer()
        {
            var ao = configuration.Identity;

            registry
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.Authority = ao.BaseUrl;
                        options.RequireHttpsMetadata = ao.RequireHttpsMetadata;
                        options.SaveToken = true;
                        options.Audience = ao.OidcApiName;
                    }
                );

            AddPolicies();

            registry.AddCors(
                options =>
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    })
            );

            return this;
        }

        public IServiceSetup AddGrpcServicer()
        {
            registry.AddCodeFirstGrpc(config =>
            {
                config.ResponseCompressionLevel = System
                    .IO
                    .Compression
                    .CompressionLevel
                    .NoCompression;
            });
            registry.TryAddSingleton(
                BinderConfiguration.Create(binder: new ProcedureBinder(registry))
            );
            registry.AddCodeFirstGrpcReflection();
            return this;
        }

        public IServiceSetup AddPolicies()
        {
            var ic = configuration.Identity;

            registry.AddAuthorization(options =>
            {
                ic.Scopes.ForEach(s => options.AddPolicy(s, policy => policy.RequireScope(s)));

                ic.Roles.ForEach(s => options.AddPolicy(s, policy => policy.RequireRole(s)));

                options.AddPolicy(
                    "Administrators",
                    policy =>
                        policy.RequireAssertion(
                            context =>
                                context.User.HasClaim(
                                    c =>
                                        (
                                            (
                                                c.Type == JwtClaimTypes.Role
                                                && c.Value == ic.AdministrationRole
                                            )
                                            || (
                                                c.Type == $"client_{JwtClaimTypes.Role}"
                                                && c.Value == ic.AdministrationRole
                                            )
                                        )
                                )
                        )
                );
            });
            return this;
        }

        public IServiceSetup AddSwagger()
        {
            string ver = configuration.Version;
            var ao = configuration.Identity;
            registry.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    ao.ApiVersion,
                    new OpenApiInfo { Title = ao.ApiName, Version = ao.ApiVersion }
                );
                //options.OperationFilter<SwaggerDefaultValues>();
                options.OperationFilter<SwaggerJsonIgnoreFilter>();
                options.DocumentFilter<IgnoreApiDocument>();
                //options.SchemaFilter<SwaggerExcludeFilter>();

                options.AddSecurityDefinition(
                    "oauth2",
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            Password = new OpenApiOAuthFlow
                            {
                                TokenUrl = new Uri($"{ao.BaseUrl}/connect/token"),
                                Scopes = ao.Scopes.ToDictionary(s => s)
                            }
                        }
                    }
                );
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
            return this;
        }

        public IServiceSetup ConfigureApiVersions(string[] apiVersions)
        {
            this.apiVersions = apiVersions;
            return this;
        }

        public new IServiceSetup ConfigureServices(Assembly[] assemblies = null)
        {
            Assemblies ??= assemblies ??= AppDomain.CurrentDomain.GetAssemblies();

            base.ConfigureServices(Assemblies);

            AddIdentityServer();

            AddGrpcServicer();

            AddSwagger();

            registry.MergeServices();

            return this;
        }

        public IServiceSetup ConfigureServices(bool includeSwagger, Assembly[] assemblies = null)
        {
            Assemblies ??= assemblies ??= AppDomain.CurrentDomain.GetAssemblies();

            base.ConfigureServices(Assemblies);

            AddIdentityServer();

            AddGrpcServicer();

            if (includeSwagger)
            {
                AddSwagger();
            }

            registry.MergeServices();

            return this;
        }

        public virtual IServiceSetup ConfigureCoreServices(Assembly[] assemblies = null)
        {
            Assemblies ??= assemblies ??= AppDomain.CurrentDomain.GetAssemblies();

            base.ConfigureServices(Assemblies);

            return this;
        }
    }
}
