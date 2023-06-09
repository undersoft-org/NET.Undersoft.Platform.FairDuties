using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Series;

namespace RadicalR.Server
{
    public class StreamServiceBuilder<TServiceStore> : DataServiceBuilder, IDataServiceBuilder<TServiceStore> where TServiceStore : IDataServiceStore
    {
        IServiceRegistry _registry;

        public StreamServiceBuilder() : base()
        {
            _registry = ServiceManager.GetRegistry();
            StoreType = typeof(TServiceStore);
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
                                type => type.GetCustomAttribute<StreamServiceAttribute>()
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
                    ifaceType = typeof(IStreamDataController<>).MakeGenericType(new[] { genTypes[4] });
                else if (genTypes.Length > 3)
                    if (genTypes[3].IsAssignableTo(typeof(IDto)) && storeTypes.Contains(genTypes[1]))
                        ifaceType = typeof(IStreamDataController<>).MakeGenericType(new[] { genTypes[3] });
                    else
                        continue;

                StreamServiceRegistry.ServiceContracts.Add(ifaceType);

                _registry.AddSingleton(ifaceType, controllerType.New());
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
                return StoreRoutes.StreamEventStore;
            }
            else
            {
                return StoreRoutes.StreamDataStore;
            }
        }
    }
}