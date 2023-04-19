﻿using AutoMapper;
using System.Reflection;

namespace UltimatR
{
    public interface IServiceSetup
    {
        IServiceSetup AddMapper(IDataMapper mapper);
        IServiceSetup AddMapper(params Profile[] profiles);
        IServiceSetup AddMapper<TProfile>() where TProfile : Profile;
        IServiceSetup AddOperationalServices<TServiceStore>(DataServiceTypes dataServiceTypes, Action<DataServiceBuilder> builder) where TServiceStore : IDataServiceStore;
        IServiceSetup AddCaching();
        IServiceSetup ConfigureCoreServices(Assembly[] assemblies = null);
        IServiceSetup ConfigureServices(Assembly[] assemblies = null);
        IServiceSetup ConfigureServices(bool includeSwagger, Assembly[] assemblies = null);
        IServiceSetup AddRepositoryEndpoints(Assembly[] assemblies = null);
        IServiceSetup AddRepositoryClients(Assembly[] assemblies = null);
        IServiceSetup AddImplementations(Assembly[] assemblies = null);
        IServiceSetup ConfigureApiVersions(string[] apiVersions);
        IServiceSetup AddMvcDsSupport();
        IServiceSetup MergeServices();
        IServiceRegistry Services { get; }
    }
}