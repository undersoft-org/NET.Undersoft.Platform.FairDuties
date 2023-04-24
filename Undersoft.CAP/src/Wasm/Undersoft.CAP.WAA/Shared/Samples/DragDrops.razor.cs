﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// DragDrops
/// </summary>
public partial class DragDrops
{
    /// <summary>
    /// GetAttributes
    /// </summary>
    /// <returns></returns>
    private IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
    {
        new()
        {
            Name = "MaxItems",
            Description = Localizer["A1"],
            Type = "int?",
            ValueList = " — ",
            DefaultValue = "null"
        },
        new()
        {
            Name = "ChildContent",
            Description = Localizer["A1"],
            Type = "RenderFragment<TItem>?",
            ValueList = " — ",
            DefaultValue = " — "
        },
    };

    /// <summary>
    /// GetMethods
    /// </summary>
    /// <returns></returns>
    private IEnumerable<MethodItem> GetMethods() => new MethodItem[]
    {
        new()
        {
            Name = nameof(Dropzone<MethodItem>.Accepts),
            Description = Localizer["M1"],
            Parameters = "Func<TItem?, TItem?, bool>",
            ReturnValue = "bool "
        },
        new()
        {
            Name = nameof(Dropzone<MethodItem>.AllowsDrag),
            Description = Localizer["M2"],
            Parameters = "TItem",
            ReturnValue = "bool"
        },
        new()
        {
            Name = nameof(Dropzone<MethodItem>.CopyItem),
            Description = Localizer["M3"],
            Parameters = "TItem, TItem",
            ReturnValue = "TItem"
        },
        new()
        {
            Name = nameof(Dropzone<MethodItem>.ItemWrapperClass),
            Description = Localizer["M4"],
            Parameters = "TItem",
            ReturnValue = "string"
        },
        new()
        {
            Name = nameof(Dropzone<MethodItem>.OnItemDrop),
            Description = Localizer["M5"],
            Parameters = " — ",
            ReturnValue = " — "
        },
        new()
        {
            Name = nameof(Dropzone<MethodItem>.OnItemDropRejected),
            Description = Localizer["M6"],
            Parameters = " — ",
            ReturnValue = " — "
        },
        new()
        {
            Name = nameof(Dropzone<MethodItem>.OnReplacedItemDrop),
            Description = Localizer["M7"],
            Parameters = " — ",
            ReturnValue = " — "
        },
        new()
        {
            Name = nameof(Dropzone<MethodItem>.OnItemDropRejectedByMaxItemLimit),
            Description = Localizer["M8"],
            Parameters = " — ",
            ReturnValue = " — "
        }
    };
}
