namespace Undersoft.AEP
{
    public interface IClaim
    {
        double Checksum { get; set; }

        long AllocSetId { get; set; }
        IAllocSet AllocSet { get; set; }

        long AllocTypeId { get; }
        IAllocType AllocType { get; set; }

        long AllocRateId { get; }
        IAllocRate AllocRate { get; set; }
    }
}