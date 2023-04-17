using Microsoft.OData.Edm;
using System;

namespace UltimatR
{
    public partial class WebApiClientContext<TStore> where TStore : IDataStore
    {
        public WebApiClientContext(Uri serviceUri)
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