using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.OData.ModelBuilder;
using System.Logs;
using RadicalR;

namespace RadicalR.Server
{
    public partial class DataBaseContext : RadicalR.DataBaseContext
    {
        public override IModel Model
        {
            get
            {
                return base.Model;
            }
        }

        public DataBaseContext(DbContextOptions options, IRadicalr radicalr = null) : base(options, radicalr)
        {
        }

        public TModel GetEdm<TModel>()
        {
            return BuildEdm<TModel>();
        }

        private TModel BuildEdm<TModel>()
        {
            var entityTypes = this.Model.GetEntityTypes();
            var odataBuilder = new ODataConventionModelBuilder();

            foreach (var entityType in entityTypes)
            {
                var type = entityType.ClrType;
                var entitySetName = entityType.Name;
                if (type.IsGenericType && type.IsAssignableTo(typeof(Identifier)))
                    entitySetName = type.GetGenericArguments().FirstOrDefault().Name + "Identifier";
                var etc = odataBuilder.AddEntityType(type);
                etc.Name = entitySetName;
                var ets = odataBuilder.AddEntitySet(entitySetName, etc);
                ets.EntityType.HasKey(type.GetProperty("Id"));
            }
            return (TModel)odataBuilder.GetEdmModel();
        }
    }
}