using Microsoft.OData.Client;
using Microsoft.OData.Edm;
using System;

namespace UltimatR
{
    public partial class ODataClientContext<TStore> : DsContext where TStore : IDataStore
    {
        public ODataClientContext(Uri serviceUri) : base(serviceUri)
        {
        }
    }

    public partial class ODataClientContext : DataServiceContext, IDataClient
    {
        public ODataClientContext(Uri serviceUri) : base(serviceUri)
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
            //Type t = GetType();
            //if (!DsRegistry.EdmModels.TryGet(t, out IEdmModel edmModel))
            //    DsRegistry.EdmModels.Add(t, edmModel = OnModelCreating(.GetEdmModel()));
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