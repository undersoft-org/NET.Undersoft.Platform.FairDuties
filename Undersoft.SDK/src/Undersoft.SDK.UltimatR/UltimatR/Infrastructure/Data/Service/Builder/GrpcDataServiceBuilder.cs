using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UltimatR
{
    public class GrpcDataServiceBuilder<TServiceStore> : DataServiceBuilder, IDataServiceBuilder<TServiceStore> where TServiceStore : IDataServiceStore
    {
        IServiceRegistry _registry;

        public GrpcDataServiceBuilder() : base()
        {
            _registry = ServiceManager.GetManager().Registry;
            StoreType = typeof(TServiceStore);
        }

        public void BuildModel()
        {
            Type[] storeTypes = DbRegistry.Stores.Where(s => s.IsAssignableTo(StoreType)).ToArray();

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

            foreach (var controllerType in controllerTypes)
            {
                Type ifaceType = null;
                var genTypes = controllerType.GenericTypeArguments;

                if (genTypes.Length > 4 && storeTypes.Contains(genTypes[1]) || storeTypes.Contains(genTypes[2]))
                    ifaceType = typeof(IGrpcDataServiceController<,,>).MakeGenericType(new[] { genTypes[0], genTypes[3], genTypes[4] });
                else if (genTypes.Length > 3)
                    if (genTypes[3].IsAssignableTo(typeof(IDto)) && storeTypes.Contains(genTypes[1]))
                        ifaceType = typeof(IGrpcDataServiceController<,,>).MakeGenericType(new[] { genTypes[0], genTypes[2], genTypes[3] });
                    else
                        continue;

                _registry.AddSingleton(ifaceType, controllerType);
            }
        }

        public void Configure()
        {
            throw new NotImplementedException();
        }

        public override void Build()
        {
            BuildModel();
        }

        protected override string GetRoutes()
        {
            if (StoreType == typeof(IEventStore))
            {
                return StoreRoutes.GrpcEventStore;
            }
            else
            {
                return StoreRoutes.GrpcCqrsStore;
            }
        }
    }
}