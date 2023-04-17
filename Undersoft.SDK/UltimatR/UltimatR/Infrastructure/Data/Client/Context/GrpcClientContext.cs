using Microsoft.OData.Edm;
using System;

namespace UltimatR
{
    public partial class GrpcClientContext<TStore> where TStore : IDataStore
    {
        public GrpcClientContext(Uri serviceUri)
        {
        }
    }

    public partial class GrpcClientContext : IDataClient
    {
        public GrpcClientContext(Uri serviceUri)
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