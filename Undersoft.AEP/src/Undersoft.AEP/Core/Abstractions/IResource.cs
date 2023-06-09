﻿using System.Uniques;

namespace Undersoft.AEP.Core
{
    public interface IResource : IUniqueObject
    {
        IAsset Asset { get; set; }

        IEstimate Estimate { get; set; }

        IUsageSet UsageSet { get; set; }

        ISource Source { get; set; }
    }
}