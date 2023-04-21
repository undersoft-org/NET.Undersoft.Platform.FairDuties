using Microsoft.OData.Edm;
using System;

namespace UltimatR
{
    public partial class RestClientContext<TStore> where TStore : IDataStore
    {
        public RestClientContext(Uri serviceUri)
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