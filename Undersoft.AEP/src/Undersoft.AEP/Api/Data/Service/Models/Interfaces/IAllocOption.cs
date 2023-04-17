namespace Undersoft.AEP
{
    public interface IAllocOption
    {
        long Id { get; set; }

        string Name { get; set; }

        string Data { get; set; }

        string TypeName { get; set; }
    }
}