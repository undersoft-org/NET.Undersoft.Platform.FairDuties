using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace UltimatR
{
    public interface IServiceSetup
    {
        IServiceSetup AddMapper(IDataMapper mapper);
        IServiceSetup AddMapper(params Profile[] profiles);
        IServiceSetup AddMapper<TProfile>() where TProfile : Profile;
        IServiceSetup AddDataService(Type contextType, string routePrefix = null, int? pageLimit = null);
        IServiceSetup AddDataService<TContext>(string routePrefix = null, int? pageLimit = null) where TContext : DbContext;
        IServiceSetup ConfigureDataServices(int? pageLimit = null);
        IServiceSetup AddCaching();
        IServiceSetup ConfigureCoreServices(Assembly[] assemblies = null);
        IServiceSetup ConfigureServices(Assembly[] assemblies = null);
        IServiceSetup ConfigureServices(bool includeSwagger, Assembly[] assemblies = null);
        IServiceSetup ConfigureEndpoints(Assembly[] assemblies = null);
        IServiceSetup ConfigureClients(Assembly[] assemblies = null);
        IServiceSetup AddImplementations(Assembly[] assemblies = null);
        IServiceSetup ConfigureApiVersions(string[] apiVersions);
        IServiceSetup AddMvcDsSupport();
        IServiceSetup MergeServices();
        IServiceRegistry Services { get; }
    }
}