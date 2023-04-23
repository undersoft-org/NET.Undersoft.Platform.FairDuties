namespace Undersoft.AEP.Core
{
    public interface IUsageOption
    {
        long Id { get; set; }

        string Name { get; set; }

        string Data { get; set; }

        string TypeName { get; set; }
    }
}