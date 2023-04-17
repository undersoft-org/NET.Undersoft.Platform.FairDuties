using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;
using System.Linq;

namespace UltimatR
{
    public class ODataServiceContext<TStore> : DataBaseContext, IDataBaseContext<TStore> where TStore : IDataStore
    {
        protected virtual Type StoreType { get; }

        public ODataServiceContext(DbContextOptions options, IUltimatr ultimatr = null) : base(options, ultimatr)
        {
            StoreType = typeof(TStore);
        }
    }

    public class OpenDataServiceContext
    {
        protected ODataConventionModelBuilder odataBuilder;
        protected IEdmModel edmModel;
        public virtual IUltimatr ultimatr { get; }

        public OpenDataServiceContext(IUltimatr ultimatr = null)
        {
            odataBuilder = new ODataConventionModelBuilder();
            this.ultimatr = ultimatr;
        }

        public object DataSet(Type entityType)
        {
            var entitySetName = entityType.Name;
            if (entityType.IsGenericType && entityType.IsAssignableTo(typeof(Identifier)))
                entitySetName = entityType.GetGenericArguments().FirstOrDefault().Name + "Identifier";

            var etc = odataBuilder.AddEntityType(entityType);
            etc.Name = entitySetName;
            var ets = odataBuilder.AddEntitySet(entitySetName, etc);
            ets.EntityType.HasKey(entityType.GetProperty("Id"));
            return ets;
        }

        public object DataSet<TEntity>() where TEntity : class, IIdentifiable
        {
            return odataBuilder.EntitySet<TEntity>(typeof(TEntity).Name);
        }

        public TModel GetModel<TModel>()
        {
            var model = edmModel ??= odataBuilder.GetEdmModel();
            odataBuilder.ValidateModel(model);
            return (TModel)model;
        }
    }

}