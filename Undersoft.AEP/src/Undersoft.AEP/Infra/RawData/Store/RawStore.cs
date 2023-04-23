﻿using System.Instant.Stock;

namespace Undersoft.AEP.Raw;

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

    public virtual Stocker<Link<UsageSet, Vertex>> UsageSetToUniverse { get; set; }

    public virtual Stocker<Link<UsageSet, Source>> UsageSetToSource { get; set; }

    public virtual Stocker<Link<UsageSet, Estimate>> UsageSetToEstimate { get; set; }

    public virtual Stocker<Link<UsageSet, Asset>> UsageSetToAsset { get; set; }

    protected void OnConfigure()
    {

    }
    protected void OnModelConfigure(StockOptions builder)
    {

    }
}