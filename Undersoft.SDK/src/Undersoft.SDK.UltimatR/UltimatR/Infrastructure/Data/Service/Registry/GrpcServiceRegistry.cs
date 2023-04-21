using System.Series;

namespace UltimatR
{
    public static class GrpcServiceRegistry
    {
        public static IDeck<Type> ServiceContracts = new Catalog<Type>();
    }
}
