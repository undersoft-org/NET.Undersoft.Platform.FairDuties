using System.Text.Json.Serialization;

namespace UltimatR
{
    public interface IEntityLink<TLeft, TRight> : IIdentifiable, IGraphLink where TLeft : class, IIdentifiable where TRight : class, IIdentifiable
    {
        [JsonIgnore]
        TLeft LeftEntity { get; set; }
        long LeftEntityId { get; set; }
        [JsonIgnore]
        TRight RightEntity { get; set; }
        long RightEntityId { get; set; }
    }
}