using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Reflection;
using System.Series;

namespace RadicalR.Server
{
    public class OpenServiceBuilder<TServiceStore> : DataServiceBuilder, IDataServiceBuilder<TServiceStore> where TServiceStore : IDataServiceStore
    {
        protected ODataConventionModelBuilder odataBuilder;
        protected IEdmModel edmModel;

        public OpenServiceBuilder() : base()
        {
            odataBuilder = new ODataConventionModelBuilder();
            StoreType = typeof(TServiceStore);
        }

        public OpenServiceBuilder(string routePrefix, int pageLimit) : this()
        {
            RoutePrefix += "/" + routePrefix;
            PageLimit = pageLimit;
        }

        public override void Build()
        {
            BuildEdm();
        }

        public object EntitySet(Type entityType)
        {
            var entitySetName = entityType.Name;
            if (entityType.IsGenericType && entityType.IsAssignableTo(typeof(IdentifierDto)))
                entitySetName =
                    entityType.GetGenericArguments().FirstOrDefault().Name + "Identifier";

            var etc = odataBuilder.AddEntityType(entityType);
            etc.Name = entitySetName;
            var ets = odataBuilder.AddEntitySet(entitySetName, etc);
            ets.EntityType.HasKey(entityType.GetProperty("Id"));
            return ets;
        }

        public object EntitySet<TDto>() where TDto : class
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
                .Select(c => DataBaseRegistry.GetDbStore(c)).Where(s => s.IsAssignableTo(StoreType)).ToArray();

            if (!storeTypes.Any())
                return;

            Assembly[] asm = AppDomain.CurrentDomain.GetAssemblies();
            var controllerTypes = asm.SelectMany(
                    a =>
                        a.GetTypes()
                            .Where(
                                type => type.GetCustomAttribute<OpenServiceAttribute>()
                                        != null
                            )
                            .ToArray())
                .Where(
                    b =>
                        !b.IsAbstract
                        && b.BaseType.IsGenericType
                        && b.BaseType.GenericTypeArguments.Length > 3
                )
                .ToArray();

            foreach (var types in controllerTypes)
            {
                var genTypes = types.BaseType.GenericTypeArguments;

                if (genTypes.Length > 4 && storeTypes.Contains(genTypes[1]) || storeTypes.Contains(genTypes[2]))
                    EntitySet(genTypes[4]);
                else if (genTypes.Length > 3)
                    if (genTypes[3].IsAssignableTo(typeof(IDto)) && storeTypes.Contains(genTypes[1]))
                        EntitySet(genTypes[3]);
                    else
                        continue;
            }
        }

        public IMvcBuilder AddOData(IMvcBuilder mvc)
        {
            var model = GetEdm();
            var route = GetRoutes();
            mvc.AddOData(b =>
            {
                b.RouteOptions.EnableQualifiedOperationCall = true;
                b.RouteOptions.EnableUnqualifiedOperationCall = true;
                b.RouteOptions.EnableKeyInParenthesis = true;
                b.RouteOptions.EnableKeyAsSegment = false;
                b.RouteOptions.EnableControllerNameCaseInsensitive = true;
                b.EnableQueryFeatures(PageLimit).AddRouteComponents(route, model);

            });
            return mvc;
        }

        protected override string GetRoutes()
        {
            if (StoreType == typeof(IEventStore))
            {
                return StoreRoutes.OpenEventStore;
            }
            else
            {
                return StoreRoutes.OpenDataStore;
            }
        }

    }
}
