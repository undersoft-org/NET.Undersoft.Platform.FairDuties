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
using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc.Server;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UltimatR
{
    public partial class ServiceSetup : IServiceSetup
    {
        string[] apiVersions = new string[1] { "1" };
        Assembly[] Assemblies;
        IMvcBuilder mvc;

        public ServiceSetup(IServiceCollection services)
        {
            manager = new ServiceManager(services);
            registry = manager.Registry;
        }

        public ServiceSetup(IServiceCollection services, IConfiguration configuration)
            : this(services)
        {
            manager.Configuration = new ServiceConfiguration(configuration, services);
        }

        public void AddJsonSerializerDefaults()
        {
#if NET6_0
            var opt = ((JsonSerializerOptions)typeof(JsonSerializerOptions)
                .GetField("s_defaultOptions",
                    System.Reflection.BindingFlags.Static |
                    System.Reflection.BindingFlags.NonPublic).GetValue(null));

            //opt.PropertyNameCaseInsensitive = true;
            opt.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            opt.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opt.WriteIndented = true;
#endif
#if NET7_0

            var flds = typeof(JsonSerializerOptions).GetRuntimeFields();
            flds.Single(f => f.Name == "_defaultIgnoreCondition")
            .SetValue(JsonSerializerOptions.Default, JsonIgnoreCondition.WhenWritingNull);
            flds.Single(f => f.Name == "_referenceHandler")
            .SetValue(JsonSerializerOptions.Default, ReferenceHandler.IgnoreCycles);
#endif
        }

        void AddDbContextConfiguration(IDataBaseContext context)
        {
            DataBaseContext _context = context as DataBaseContext;
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            _context.ChangeTracker.LazyLoadingEnabled = true;
            _context.Database.AutoTransactionsEnabled = false;
        }

        string AddDsClientPrefix(Type contextType, string routePrefix = null)
        {
            Type iface = OpenDataServiceRegistry.GetDsStore(contextType);
            return GetStoreRoutes(iface, routePrefix);
        }

        string AddDsEndpointPrefix(Type contextType, string routePrefix = null)
        {
            Type iface = DbRegistry.GetDbStore(contextType);
            return GetStoreRoutes(iface, routePrefix);
        }

        public IServiceSetup AddMvcDsSupport()
        {
            (mvc ??= Services.AddControllers())
                .AddMvcOptions(options =>
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

        string GetStoreRoutes(Type iface, string routePrefix = null)
        {
            if (iface == typeof(IEntryStore))
            {
                return (routePrefix != null)
                    ? (StoreRoutes.EntryStore = routePrefix)
                    : StoreRoutes.EntryStore;
            }
            else if (iface == typeof(IEventStore))
            {
                return (routePrefix != null)
                    ? (StoreRoutes.EventStore = routePrefix)
                    : StoreRoutes.EventStore;
            }
            else if (iface == typeof(IReportStore))
            {
                return (routePrefix != null)
                    ? (StoreRoutes.ReportStore = routePrefix)
                    : StoreRoutes.ReportStore;
            }
            else if (iface == typeof(ICqrsStore))
            {
                return (routePrefix != null)
                    ? (StoreRoutes.CqrsStore = routePrefix)
                    : StoreRoutes.CqrsStore;
            }
            else
            {
                return (routePrefix != null)
                  ? (StoreRoutes.CqrsStore = routePrefix)
                  : StoreRoutes.CqrsStore;
            }
        }

        IServiceConfiguration configuration => manager.Configuration;

        IServiceManager manager { get; }

        IServiceRegistry registry { get; set; }

        IServiceCollection services => registry.Services;

        public IServiceRegistry Services => registry;

        public IServiceSetup AddCaching()
        {
            registry.AddObject(GlobalCache.Catalog);

            Type[] stores = new Type[]
            {
                typeof(IEntryStore),
                typeof(IReportStore),
                typeof(IEventStore)
            };
            foreach (Type item in stores)
            {
                AddDataCache(item);
            }

            return this;
        }

        public IServiceSetup AddDataCache(Type tstore)
        {
            Type idatacache = typeof(IStoreCache<>).MakeGenericType(tstore);
            Type datacache = typeof(StoreCache<>).MakeGenericType(tstore);

            object cache = datacache.New(registry.GetObject<IDataCache>());
            registry.AddObject(idatacache, cache);
            registry.AddObject(datacache, cache);

            return this;
        }

        public IServiceSetup AddOperationalServices<TServiceStore>(DataServiceTypes dataServiceTypes, Action<DataServiceBuilder> builder) where TServiceStore : IDataServiceStore
        {
            DataServiceBuilder.ServiceTypes = dataServiceTypes;
            if ((dataServiceTypes & DataServiceTypes.OData) > 0)
            {
                Task.Run(() =>
                {
                    var ds = new OpenDataServiceBuilder<TServiceStore>();
                    builder.Invoke(ds);
                    ds.Build();
                });
            }
            if ((dataServiceTypes & DataServiceTypes.Grpc) > 0)
            {
                Task.Run(() =>
                {
                    var ds = new GrpcDataServiceBuilder<TServiceStore>();
                    builder.Invoke(ds);
                    ds.Build();
                });
            }
            if ((dataServiceTypes & DataServiceTypes.WebAPI) > 0)
            {
                Task.Run(() =>
                {
                    var ds = new RestDataServiceBuilder<TServiceStore>();
                    builder.Invoke(ds);
                    ds.Build();
                });
            }
            return this;
        }

        public IServiceSetup AddIdentityServer()
        {
            var ao = configuration.Identity;

            registry.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = ao.BaseUrl;
                options.RequireHttpsMetadata = ao.RequireHttpsMetadata;
                options.SaveToken = true;
                options.Audience = ao.OidcApiName;
            });


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
                config.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.NoCompression;
            });
            registry.TryAddSingleton(BinderConfiguration.Create(binder: new ProcedureBinder(registry)));
            registry.AddCodeFirstGrpcReflection();
            return this;
        }

        public IServiceSetup AddImplementations(Assembly[] assemblies = null)
        {
            AddAppImplementations(assemblies);

            AddDomainImplementations();

            return this;
        }

        public IServiceSetup AddMapper<TProfile>() where TProfile : Profile
        {
            AddMapper(new DataMapper(typeof(TProfile).New<TProfile>()));

            return this;
        }

        public IServiceSetup AddMapper(params Profile[] profiles)
        {
            AddMapper(new DataMapper(profiles));

            return this;
        }

        public IServiceSetup AddMapper(IDataMapper mapper)
        {
            registry.AddObject(mapper);
            registry.AddObject<IDataMapper>(mapper);
            registry.AddScoped<IMapper, DataMapper>();

            return this;
        }

        public IServiceSetup AddPolicies()
        {
            var ic = configuration.Identity;

            registry.AddAuthorization(
                options =>
                {
                    ic.Scopes
                        .ForEach(s => options.AddPolicy(s, policy => policy.RequireScope(s)));

                    ic.Roles
                        .ForEach(s => options.AddPolicy(s, policy => policy.RequireRole(s)));

                    options.AddPolicy("RequireAdministratorRole",
                        policy =>
                            policy.RequireAssertion(context => context.User.HasClaim(c =>
                                    ((c.Type == JwtClaimTypes.Role && c.Value == ic.AdministrationRole) ||
                                    (c.Type == $"client_{JwtClaimTypes.Role}" && c.Value == ic.AdministrationRole)))
                            ));
                }
            );
            return this;
        }

        public IServiceSetup AddSwagger()
        {
            string ver = configuration.Version;
            var ao = configuration.Identity;
            registry.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(ao.ApiVersion, new OpenApiInfo { Title = ao.ApiName, Version = ao.ApiVersion });
                //options.OperationFilter<SwaggerDefaultValues>();
                options.OperationFilter<SwaggerJsonIgnoreFilter>();
                options.DocumentFilter<IgnoreApiDocument>();
                //options.SchemaFilter<SwaggerExcludeFilter>();

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
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
                });
                //options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
            return this;
        }

        public IServiceSetup ConfigureApiVersions(string[] apiVersions)
        {
            this.apiVersions = apiVersions;
            return this;
        }

        public IServiceSetup AddRepositoryClients(Assembly[] assemblies = null)
        {
            IServiceConfiguration config = configuration;
            assemblies ??= AppDomain.CurrentDomain.GetAssemblies();
            TypeInfo[] definedTypes = assemblies.SelectMany(a => a.DefinedTypes).ToArray();
            IEnumerable<IConfigurationSection> clients = config.Clients();
            RepositoryClients repoClients = new RepositoryClients();

            services.AddSingleton(registry.AddObject<IRepositoryClients>(repoClients).Value);

            foreach (IConfigurationSection client in clients)
            {
                ClientProvider provider = config.ClientProvider(client);
                string connectionString = config.ClientConnectionString(client).Trim();
                int poolsize = config.ClientPoolSize(client);
                Type preContextType = definedTypes
                    .Where(t => t.FullName.Contains(client.Key))
                    .Select(t => t.UnderlyingSystemType)
                    .FirstOrDefault();
                if (
                    (provider == ClientProvider.None)
                    || (connectionString == null)
                    || (preContextType == null)
                )
                {
                    continue;
                }

                Type[] contextTypes = new Type[]
                {
                    preContextType.MakeGenericType(typeof(IEntryStore)),
                    preContextType.MakeGenericType(typeof(IReportStore))
                };

                foreach (Type contextType in contextTypes)
                {
                    string routePrefix = AddDsClientPrefix(contextType).Trim();
                    if (!connectionString.EndsWith('/'))
                    {
                        connectionString += "/";
                    }

                    if (routePrefix.StartsWith('/'))
                    {
                        routePrefix = routePrefix.Substring(1);
                    }

                    string _connectionString = $"{connectionString}{routePrefix}";

                    Type iRepoType = typeof(IRepositoryClient<>).MakeGenericType(contextType);
                    Type repoType = typeof(RepositoryClient<>).MakeGenericType(contextType);

                    IRepositoryClient repoClient = (IRepositoryClient)
                        repoType.New(provider, _connectionString);

                    Type storeDbType = typeof(DataClientContext<>).MakeGenericType(
                        OpenDataServiceRegistry.GetDsStore(contextType)
                    );
                    Type storeRepoType = typeof(RepositoryClient<>).MakeGenericType(storeDbType);

                    IRepositoryClient storeClient = (IRepositoryClient)
                        storeRepoType.New(repoClient);

                    Type istoreRepoType = typeof(IRepositoryClient<>).MakeGenericType(storeDbType);
                    Type ipoolRepoType = typeof(IRepositoryContextPool<>).MakeGenericType(
                        storeDbType
                    );
                    Type ifactoryRepoType = typeof(IRepositoryContextFactory<>).MakeGenericType(
                        storeDbType
                    );
                    Type idataRepoType = typeof(IRepositoryContext<>).MakeGenericType(storeDbType);

                    repoClient.PoolSize = poolsize;

                    IRepositoryClient globalClient = RepositoryManager.AddClient(repoClient);

                    registry.AddObject(iRepoType, globalClient);
                    registry.AddObject(repoType, globalClient);

                    registry.AddObject(istoreRepoType, storeClient);
                    registry.AddObject(ipoolRepoType, storeClient);
                    registry.AddObject(ifactoryRepoType, storeClient);
                    registry.AddObject(idataRepoType, storeClient);
                    registry.AddObject(storeRepoType, storeClient);

                    RepositoryManager.AddClientPool(globalClient.ContextType, poolsize);
                }
            }

            return this;
        }

        public IServiceSetup AddRepositoryEndpoints(Assembly[] assemblies = null)
        {
            IServiceConfiguration config = configuration;
            assemblies ??= Assemblies ??= AppDomain.CurrentDomain.GetAssemblies();
            TypeInfo[] definedTypes = assemblies.SelectMany(a => a.DefinedTypes).ToArray();
            IEnumerable<IConfigurationSection> endpoints = config.Endpoints();

            RepositoryEndpoints repoEndpoints = new RepositoryEndpoints();
            registry.AddSingleton(registry.AddObject<IRepositoryEndpoints>(repoEndpoints).Value);


            foreach (IConfigurationSection endpoint in endpoints)
            {
                string connectionString = config.EndpointConnectionString(endpoint);
                EndpointProvider provider = config.EndpointProvider(endpoint);
                int poolsize = config.EndpointPoolSize(endpoint);
                Type contextType = definedTypes
                    .Where(t => t.FullName == endpoint.Key)
                    .Select(t => t.UnderlyingSystemType)
                    .FirstOrDefault();

                if (
                    (provider == EndpointProvider.None)
                    || (connectionString == null)
                    || (contextType == null)
                )
                {
                    continue;
                }

                RepositoryEndpointOptions.AddEntityServicesForDb(provider);

                Type iRepoType = typeof(IRepositoryEndpoint<>).MakeGenericType(contextType);
                Type repoType = typeof(RepositoryEndpoint<>).MakeGenericType(contextType);
                Type repoOptionsType = typeof(DbContextOptions<>).MakeGenericType(contextType);

                IRepositoryEndpoint repoEndpoint = (IRepositoryEndpoint)
                    repoType.New(provider, connectionString);

                Type storeDbType = typeof(DataBaseContext<>).MakeGenericType(
                    DbRegistry.GetDbStore(contextType)
                );
                Type storeOptionsType = typeof(DbContextOptions<>).MakeGenericType(storeDbType);
                Type storeRepoType = typeof(RepositoryEndpoint<>).MakeGenericType(storeDbType);

                IRepositoryEndpoint storeEndpoint = (IRepositoryEndpoint)
                    storeRepoType.New(repoEndpoint);

                Type istoreRepoType = typeof(IRepositoryEndpoint<>).MakeGenericType(storeDbType);
                Type ipoolRepoType = typeof(IRepositoryContextPool<>).MakeGenericType(storeDbType);
                Type ifactoryRepoType = typeof(IRepositoryContextFactory<>).MakeGenericType(
                    storeDbType
                );
                Type idataRepoType = typeof(IRepositoryContext<>).MakeGenericType(storeDbType);

                repoEndpoint.PoolSize = poolsize;

                IRepositoryEndpoint globalEndpoint = RepositoryManager.AddEndpoint(repoEndpoint);

                AddDbContextConfiguration(globalEndpoint.Context);

                registry.AddObject(iRepoType, globalEndpoint);
                registry.AddObject(repoType, globalEndpoint);
                registry.AddObject(repoOptionsType, globalEndpoint.Options);

                registry.AddObject(istoreRepoType, storeEndpoint);
                registry.AddObject(ipoolRepoType, storeEndpoint);
                registry.AddObject(ifactoryRepoType, storeEndpoint);
                registry.AddObject(idataRepoType, storeEndpoint);
                registry.AddObject(storeRepoType, storeEndpoint);
                registry.AddObject(storeOptionsType, storeEndpoint.Options);

                RepositoryManager.AddEndpointPool(globalEndpoint.ContextType, poolsize);
            }

            return this;
        }

        public IServiceSetup ConfigureServices(Assembly[] assemblies = null)
        {
            Assemblies ??= assemblies ??= AppDomain.CurrentDomain.GetAssemblies();

            AddMapper(new DataMapper());

            AddCaching();

            AddIdentityServer();

            AddJsonSerializerDefaults();

            AddGrpcServicer();

            AddRepositoryEndpoints(Assemblies);

            AddRepositoryClients(Assemblies);

            AddImplementations(Assemblies);

            AddSwagger();

            registry.MergeServices();

            return this;
        }

        public IServiceSetup ConfigureServices(bool includeSwagger, Assembly[] assemblies = null)
        {
            Assemblies ??= assemblies ??= AppDomain.CurrentDomain.GetAssemblies();

            AddMapper(new DataMapper());

            AddCaching();

            AddIdentityServer();

            AddJsonSerializerDefaults();

            AddGrpcServicer();

            AddRepositoryEndpoints(Assemblies);

            AddRepositoryClients(Assemblies);

            AddImplementations(Assemblies);

            if (includeSwagger)
            {
                AddSwagger();
            }

            registry.MergeServices();

            return this;
        }

        public IServiceSetup ConfigureCoreServices(Assembly[] assemblies = null)
        {
            Assemblies ??= assemblies ??= AppDomain.CurrentDomain.GetAssemblies();

            AddMapper(new DataMapper());

            AddCaching();

            AddJsonSerializerDefaults();

            AddRepositoryEndpoints(Assemblies);

            AddRepositoryClients(Assemblies);

            AddImplementations(Assemblies);

            registry.MergeServices();

            return this;
        }

        public IServiceSetup MergeServices()
        {
            registry.MergeServices();

            return this;
        }
    }
}
