namespace Undersoft.AEP.Core
{
    public interface IUsage : Raw.IUsage
    {
        IUsability Current { get; }

        ISource Source { get; set; }

        IUsage Used { get; set; }

        IUsability Target { get; set; }
    }
}