using System.Instant;

namespace UltimatR
{
    public interface IId
    {
        long Id { get; set; }
    }

    public interface IGraphLink : IFigure
    {
        long LeftId { get; set; }
        long RightId { get; set; }
    }

    public interface ILink
    {
        long SourceId { get; set; }

        string SourceName { get; set; }

        long TargetId { get; set; }

        string TargetName { get; set; }
    }


}