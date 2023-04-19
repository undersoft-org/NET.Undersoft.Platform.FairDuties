using System.Instant;

namespace UltimatR
{
    public interface IGraphLink : IFigure
    {
        long LeftId { get; set; }
        long RightId { get; set; }
    }

}