namespace RadicalR
{
    public static class StoreRoutes
    {
        public static string EntryStore { get; set; } = "dataentry";
        public static string ReportStore { get; set; } = "datareport";
        public static string EventStore { get; set; } = "event";
        public static string DataStore { get; set; } = "data";
        public static string OpenEventStore { get; set; } = "openevent";
        public static string OpenDataStore { get; set; } = "opendata";
        public static string StreamEventStore { get; set; } = "eventstream";
        public static string StreamDataStore { get; set; } = "datastream";
        public static string CrudEventStore { get; set; } = "eventcrud";
        public static string CrudDataStore { get; set; } = "datacrud";

        public static class Constant
        {
            public const string EntryStore = "entrydata";
            public const string ReportStore = "reportdata";
            public const string EventStore = "event";
            public const string DataStore = "data";
            public const string OpenEventStore = "openevent";
            public const string OpenDataStore = "opendata";
            public const string StreamEventStore = "streamevent";
            public const string StreamDataStore = "streamdata";
            public const string CrudEventStore = "crudevent";
            public const string CrudDataStore = "cruddata";
        }
    }
}
