namespace RadicalR
{
    public static class StoreRoutes
    {
        public static string EntryStore { get; set; } = "data/entry";
        public static string ReportStore { get; set; } = "data/report";
        public static string EventStore { get; set; } = "event";
        public static string CqrsStore { get; set; } = "data";
        public static string OpenEventStore { get; set; } = "event/open";
        public static string OpenCqrsStore { get; set; } = "data/open";
        public static string GrpcEventStore { get; set; } = "event/grpc";
        public static string GrpcCqrsStore { get; set; } = "data/grpc";
        public static string RestEventStore { get; set; } = "event/rest";
        public static string RestCqrsStore { get; set; } = "data/rest";

        public static class Constant
        {
            public const string EntryStore = "data/entry";
            public const string ReportStore = "data/report";
            public const string EventStore = "event";
            public const string CqrsStore = "data";
            public const string OpenEventStore = "event/open";
            public const string OpenCqrsStore = "data/open";
            public const string GrpcEventStore = "event/grpc";
            public const string GrpcCqrsStore = "data/grpc";
            public const string RestEventStore = "event/rest";
            public const string RestCqrsStore = "data/rest";
        }
    }
}
