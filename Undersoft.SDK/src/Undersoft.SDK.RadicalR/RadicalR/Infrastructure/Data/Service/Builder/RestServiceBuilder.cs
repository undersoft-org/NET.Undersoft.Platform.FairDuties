using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RadicalR
{
    public class RestServiceBuilder<TStore> : DataServiceBuilder, IDataServiceBuilder<TStore> where TStore : IDataServiceStore
    {
        IServiceRegistry _registry;

        public RestServiceBuilder() : base()
        {
            _registry = ServiceManager.GetManager().Registry;
            StoreType = typeof(TStore);
        }

        public void BuildModel()
        {
            Type[] storeTypes = DataBaseRegistry.Stores.Where(s => s.IsAssignableTo(StoreType)).ToArray();

            if (!storeTypes.Any())
                return;

            Assembly[] asm = AppDomain.CurrentDomain.GetAssemblies();
            var controllerTypes = asm.SelectMany(
                    a =>
                        a.GetTypes()
                            .Where(
                                type => type.GetCustomAttribute<RestServiceAttribute>()
                                        != null
                            )
                            .ToArray())
                .Where(
                    b =>
                        !b.IsAbstract
                        && b.BaseType.IsGenericType
                        && b.BaseType.GenericTypeArguments.Length > 3
                ).ToArray();

            foreach (var controllerType in controllerTypes)
            {
                Type ifaceType = null;
                var genTypes = controllerType.BaseType.GenericTypeArguments;

                if (genTypes.Length > 4 && storeTypes.Contains(genTypes[1]) || storeTypes.Contains(genTypes[2]))
                    ifaceType = typeof(IRestDataServiceController<,,>).MakeGenericType(new[] { genTypes[0], genTypes[3], genTypes[4] });
                else if (genTypes.Length > 3)
                    if (genTypes[3].IsAssignableTo(typeof(IDto)) && storeTypes.Contains(genTypes[1]))
                        ifaceType = typeof(IRestDataServiceController<,,>).MakeGenericType(new[] { genTypes[0], genTypes[2], genTypes[3] });
                    else
                        continue;

                _registry.AddScoped(ifaceType, controllerType);
            }
        }

        public override void Build()
        {
            //BuildModel();
        }

        protected override string GetRoutes()
        {
            if (StoreType == typeof(IEventStore))
            {
                return StoreRoutes.RestEventStore;
            }
            else
            {
                return StoreRoutes.RestCqrsStore;
            }
        }
    }

}