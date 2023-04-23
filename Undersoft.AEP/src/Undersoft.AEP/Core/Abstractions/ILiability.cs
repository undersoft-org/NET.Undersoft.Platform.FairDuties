namespace Undersoft.AEP.Core
{
    public interface ILiability
    {
        double Checksum { get; set; }

        long UsageSetId { get; set; }
        IUsageSet UsageSet { get; set; }

        long AssetId { get; }
        IAsset Asset { get; set; }

        long EstimateId { get; }
        IEstimate Estimate { get; set; }
    }
}