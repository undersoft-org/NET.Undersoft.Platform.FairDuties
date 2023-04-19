using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Reflection;

namespace UltimatR
{
    public class OpenDataServiceBuilder<TServiceStore> : DataServiceBuilder, IDataServiceBuilder<TServiceStore> where TServiceStore : IDataServiceStore
    {
        protected ODataConventionModelBuilder odataBuilder;
        protected ODataOptions odataOptions;
        protected IEdmModel edmModel;

        public OpenDataServiceBuilder() : base()
        {
            odataBuilder = new ODataConventionModelBuilder();
            StoreType = typeof(TServiceStore);
        }

        public OpenDataServiceBuilder(string routePrefix, int pageLimit) : this()
        {
            RoutePrefix += "/" + routePrefix;
            PageLimit = pageLimit;
        }

        public override void Build()
        {
            BuildEdm();
            Configure();
        }

        public object DataSet(Type entityType)
        {
            var entitySetName = entityType.Name;
            if (entityType.IsGenericType && entityType.IsAssignableTo(typeof(Identifier)))
                entitySetName =
                    entityType.GetGenericArguments().FirstOrDefault().Name + "Identifier";

            var etc = odataBuilder.AddEntityType(entityType);
            etc.Name = entitySetName;
            var ets = odataBuilder.AddEntitySet(entitySetName, etc);
            ets.EntityType.HasKey(entityType.GetProperty("Id"));
            return ets;
        }

        public object DataSet<TDto>() where TDto : class
        {
            return odataBuilder.EntitySet<TDto>(typeof(TDto).Name);
        }

        public IEdmModel GetEdm()
        {
            if (edmModel == null)
            {
                edmModel = odataBuilder.GetEdmModel();
                odataBuilder.ValidateModel(edmModel);
            }
            return edmModel;
        }

        public void BuildEdm()
        {
            Type[] storeTypes = this
                .Select(c => DbRegistry.GetDbStore(c)).Where(s => s.IsAssignableTo(StoreType)).ToArray();

            if (!storeTypes.Any())
                return;

            Assembly[] asm = AppDomain.CurrentDomain.GetAssemblies();
            var controllerTypes = asm.SelectMany(
                    a =>
                        a.GetTypes()
                            .Where(
                                type => type.GetCustomAttribute<OpenDataServiceAttribute>()
                                        != null
                            )
                            .ToArray())
                .Where(
                    b =>
                        !b.IsAbstract
                        && b.BaseType.IsGenericType
                        && b.BaseType.GenericTypeArguments.Length > 3
                )
                .Select(a => a.BaseType)
                .ToArray();

            foreach (var types in controllerTypes)
            {
                var genTypes = types.GenericTypeArguments;

                if (genTypes.Length > 4 && storeTypes.Contains(genTypes[1]) || storeTypes.Contains(genTypes[2]))
                    DataSet(genTypes[4]);
                else if (genTypes.Length > 3)
                    if (genTypes[3].IsAssignableTo(typeof(IDto)) && storeTypes.Contains(genTypes[1]))
                        DataSet(genTypes[3]);
                    else
                        continue;
            }
        }

        public void Configure()
        {
            odataOptions.RouteOptions.EnableQualifiedOperationCall = true;
            odataOptions.RouteOptions.EnableUnqualifiedOperationCall = true;
            odataOptions.RouteOptions.EnableKeyInParenthesis = true;
            odataOptions.RouteOptions.EnableKeyAsSegment = false;
            odataOptions.RouteOptions.EnableControllerNameCaseInsensitive = true;
            odataOptions.EnableQueryFeatures(PageLimit);
            odataOptions.AddRouteComponents(RoutePrefix, GetEdm());
        }

        protected override string GetRoutes()
        {
            if (StoreType == typeof(IEventStore))
            {
                return StoreRoutes.OpenEventStore;
            }
            else
            {
                return StoreRoutes.OpenCqrsStore;
            }
        }

    }
}
