using System.Instant.Stock;
using System.Instant.Linking;

namespace Undersoft.AEP.Raw
{
    using Core;
    using System.Instant;

    public class RawStore
    {
    public RawStore() { }

    public virtual Stocker<Usage> Usage { get; set; }

    public virtual Stocker<UsageOption> UsageOption { get; set; }

    public virtual Stocker<Estimate> Estimate { get; set; }

    public virtual Stocker<Asset> Asset { get; set; }

    public virtual Stocker<UsageSet> UsageSet { get; set; }

    public virtual Stocker<Source> Source { get; set; }

    public virtual Stocker<Liability> Liability { get; set; }

    public virtual Stocker<Setup> Setup { get; set; }

    public virtual Stocker<Duty> Duty { get; set; }

    public virtual Stocker<Resource> Resource { get; set; }

    public virtual Stocker<Vector> Vector { get; set; }

    public virtual Stocker<Socket> Socket { get; set; }

    public virtual Stocker<Vertex> Vertex { get; set; }

    public virtual Stocker<Link<UsageSet, Vertex>> UsageSetToVertex { get; set; }

    public virtual Stocker<Link<UsageSet, Source>> UsageSetToSource { get; set; }

    public virtual Stocker<Link<UsageSet, Estimate>> UsageSetToEstimate { get; set; }

    public virtual Stocker<Link<UsageSet, Asset>> UsageSetToAsset { get; set; }

    public virtual Stocker<Link<Source, Asset>> SourceToAsset { get; set; }

    public virtual Stocker<Link<Source, Estimate>> SourceToEstimate { get; set; }

    public virtual Stocker<Link<Estimate, Estimate>> EstimateDependentOn { get; set; }

    public virtual Stocker<Link<Estimate, Estimate>> EstimateOptionalTo { get; set; }

    public virtual Stocker<Link<Asset, Asset>> AssetDependentOn { get; set; }

    public virtual Stocker<Link<Asset, Asset>> AssetOptionalTo { get; set; }

    public virtual Stocker<Link<Asset, Asset>> AssetRelatedTo { get; set; }

    protected void OnConfigure()
    {

    }

    protected void OnModelConfigure(StockOptions builder)
    {

    }
    }
}
