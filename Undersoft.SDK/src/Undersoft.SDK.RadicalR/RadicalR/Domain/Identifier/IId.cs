using System.Instant;

namespace RadicalR
{
    public interface IGraphLink : IFigure
    {
        long LeftId { get; set; }
        long RightId { get; set; }
    }

}