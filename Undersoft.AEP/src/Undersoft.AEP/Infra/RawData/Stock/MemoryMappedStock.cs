using System.Instant.Stock;

namespace Undersoft.AEP;

public class MemoryMappedStock
{
    public MemoryMappedStock() { }

    public virtual Stocker<Alloc> Alloc { get; set; }

    public virtual Stocker<AllocOption> AllocOption { get; set; }

    public virtual Stocker<AllocRate> AllocRate { get; set; }

    public virtual Stocker<AllocType> AllocType { get; set; }

    public virtual Stocker<AllocSet> AllocSet { get; set; }

    public virtual Stocker<Asset> Asset { get; set; }

    public virtual Stocker<Claim> Claim { get; set; }

    public virtual Stocker<Configuration> Configuration { get; set; }

    public virtual Stocker<Source> Entry { get; set; }

    public virtual Stocker<Resource> Resource { get; set; }

    public virtual Stocker<Sequence> Sequence { get; set; }

    public virtual Stocker<Slot> Slot { get; set; }

    public virtual Stocker<Universe> Universe { get; set; }

    public virtual Stocker<Link<AllocSet, Universe>> AllocSetToUniverse { get; set; }

    public virtual Stocker<Link<AllocSet, AllocType>> AllocSetToAllocType { get; set; }

    public virtual Stocker<Link<AllocSet, AllocRate>> AllocSetToAllocRate { get; set; }

    public virtual Stocker<Link<AllocSet, Asset>> AllocSetToAsset { get; set; }

    protected void OnConfigure()
    {

    }
    protected void OnModelConfigure(StockOptions builder)
    {

    }
}
