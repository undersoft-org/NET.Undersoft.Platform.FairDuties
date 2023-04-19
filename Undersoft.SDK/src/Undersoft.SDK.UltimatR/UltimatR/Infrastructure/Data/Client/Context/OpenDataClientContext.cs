using Microsoft.OData.Client;
using Microsoft.OData.Edm;

namespace UltimatR
{
    public partial class OpenDataClientContext<TStore> : OpenDcContext where TStore : IDataStore
    {
        public OpenDataClientContext(Uri serviceUri) : base(serviceUri)
        {
        }
    }

    public partial class OpenDcContext : DataServiceContext, IDataClient
    {
        public OpenDcContext(Uri serviceUri) : base(serviceUri)
        {
            MergeOption = MergeOption.AppendOnly;
            HttpRequestTransportMode = HttpRequestTransportMode.HttpClient;
            IgnoreResourceNotFoundException = true;
            KeyComparisonGeneratesFilterQuery = false;
            DisableInstanceAnnotationMaterialization = true;
            EnableWritingODataAnnotationWithoutPrefix = false;
            AddAndUpdateResponsePreference = DataServiceResponsePreference.NoContent;
            EntityParameterSendOption = EntityParameterSendOption.SendOnlySetProperties;
            SaveChangesDefaultOptions = SaveChangesOptions.BatchWithSingleChangeset;
            ResolveName = (t) => this.GetMappedName(t);
            ResolveType = (n) => this.GetMappedType(n);
        }

        public void CreateServiceModel()
        {
            Format.LoadServiceModel = () => GetServiceModel();
            Format.UseJson();
        }

        public IEdmModel GetServiceModel()
        {
            Type t = GetType();
            if (!OpenDataServiceRegistry.EdmModels.TryGet(t, out IEdmModel edmModel))
                OpenDataServiceRegistry.EdmModels.Add(t, edmModel = OnModelCreating(this.GetEdmModel()));
            return null;
        }

        protected virtual IEdmModel OnModelCreating(IEdmModel builder)
        {
            return builder;
        }


        public override DataServiceQuery<T> CreateQuery<T>(string resourcePath, bool isComposable)
        {

            return base.CreateQuery<T>(resourcePath, isComposable);
        }

    }
}