using System.Series;

namespace RadicalR.Server
{
    public static class StreamServiceRegistry
    {
        public static IDeck<Type> ServiceContracts = new Catalog<Type>();
    }
}
