using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Series;

namespace RadicalR
{
    public class CrudServiceBuilder<TStore> : DataServiceBuilder, IDataServiceBuilder<TStore> where TStore : IDataServiceStore
    {
        IServiceRegistry _registry;

        public CrudServiceBuilder() : base()
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
                                type => type.GetCustomAttribute<CrudServiceAttribute>()
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
                    ifaceType = typeof(ICrudDataService<,,>).MakeGenericType(new[] { genTypes[0], genTypes[3], genTypes[4] });
                else if (genTypes.Length > 3)
                    if (genTypes[3].IsAssignableTo(typeof(IDto)) && storeTypes.Contains(genTypes[1]))
                        ifaceType = typeof(ICrudDataService<,,>).MakeGenericType(new[] { genTypes[0], genTypes[2], genTypes[3] });
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
                return StoreRoutes.CrudEventStore;
            }
            else
            {
                return StoreRoutes.CrudDataStore;
            }
        }
    }

}