using AutoMapper;
using System.Reflection;

namespace RadicalR.Server
{
    public partial interface IServiceSetup : RadicalR.IServiceSetup
    {      
        IServiceSetup AddDataServices<TServiceStore>(DataServiceTypes dataServiceTypes, Action<DataServiceBuilder> builder) where TServiceStore : IDataServiceStore;
        IServiceSetup ConfigureApiVersions(string[] apiVersions);
        IServiceSetup AddMvcDataServiceSupport();
        IServiceSetup AddSwagger();
        IServiceSetup AddGrpcServicer();
        IServiceSetup AddIdentityServer();
        IServiceSetup ConfigureServices(bool includeSwagger, Assembly[] assemblies = null);
        IServiceSetup ConfigureCoreServices(Assembly[] assemblies = null);
    }
}