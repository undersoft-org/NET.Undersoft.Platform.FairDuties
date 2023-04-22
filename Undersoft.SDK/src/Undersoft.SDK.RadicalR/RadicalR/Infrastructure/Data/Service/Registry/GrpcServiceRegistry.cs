using System.Series;

namespace RadicalR
{
    public static class GrpcServiceRegistry
    {
        public static IDeck<Type> ServiceContracts = new Catalog<Type>();
    }
}
