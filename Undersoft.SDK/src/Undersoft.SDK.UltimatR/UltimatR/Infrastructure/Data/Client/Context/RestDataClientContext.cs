using Microsoft.OData.Edm;
using System;

namespace UltimatR
{
    public partial class RestDataClientContext<TStore> where TStore : IDataStore
    {
        public RestDataClientContext(Uri serviceUri)
        {
        }
    }

    public partial class WebApiClientContext : IDataClient
    {
        public WebApiClientContext(Uri serviceUri)
        {
        }

        public void CreateServiceModel()
        {

        }

        protected virtual IEdmModel OnModelCreating(IEdmModel builder)
        {
            return builder;
        }

    }
}