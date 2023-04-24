﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// Responsives
/// </summary>
public partial class Responsives
{
    private static IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
    {
        new AttributeItem()
        {
            Name = nameof(Responsive.OnBreakPointChanged),
            Description = "Callback method when breakpoint threshold changes",
            Type = "Func<BreakPoint, Task<bool>>",
            ValueList = " — ",
            DefaultValue = " — "
        }
    };
}
