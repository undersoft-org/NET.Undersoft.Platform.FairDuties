using ProtoBuf.Grpc.Configuration;
using System.Reflection;

namespace UltimatR
{
    internal class ProcedureBinder : ServiceBinder
    {
        private readonly IServiceRegistry registry;

        public ProcedureBinder(IServiceRegistry registry)
        {
            this.registry = registry;
        }

        public override IList<object> GetMetadata(MethodInfo method, Type contractType, Type serviceType)
        {
            var resolvedServiceType = serviceType;
            if (serviceType.IsInterface)
                resolvedServiceType = registry[serviceType]?.ImplementationType ?? serviceType;

            return base.GetMetadata(method, contractType, resolvedServiceType);
        }
    }
}