using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Threading.Tasks;

namespace UltimatR
{
    public class WebApiServiceContext<TStore> : WebApiServiceContext where TStore : IDataStore
    {
        protected virtual Type StoreType { get; }

        public WebApiServiceContext(IUltimatr ultimatr = null)
        {
            StoreType = typeof(TStore);
        }
    }

    public class WebApiServiceContext : IDataContext
    {
        public virtual IUltimatr ultimatr { get; }

        public IModel Model { get; set; }

        public WebApiServiceContext(IUltimatr ultimatr = null)
        {
            this.ultimatr = ultimatr;
        }

        public object DataSet<TEntity>() where TEntity : class, IIdentifiable
        {
            return null; /*odataBuilder.EntitySet<TEntity>(typeof(TEntity).Name);*/
        }

        public object DataSet(Type entityType)
        {
            //var entitySetName = entityType.Name;
            //if (entityType.IsGenericType && entityType.IsAssignableTo(typeof(Identifier)))
            //    entitySetName = entityType.GetGenericArguments().FirstOrDefault().Name + "Identifier";

            //var etc = odataBuilder.AddEntityType(entityType);
            //etc.Name = entitySetName;
            //var ets = odataBuilder.AddEntitySet(entitySetName, etc);
            //ets.EntityType.HasKey(entityType.GetProperty("Id"));
            //return ets;
            return null;
        }

        public TModel GetModel<TModel>()
        {
            //var model = edmModel ??= odataBuilder.GetEdmModel();
            //odataBuilder.ValidateModel(model);
            return default; // (TModel)model;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }

}