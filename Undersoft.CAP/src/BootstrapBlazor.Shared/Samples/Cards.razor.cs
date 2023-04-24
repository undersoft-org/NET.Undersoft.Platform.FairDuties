﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// Card展示组件
/// </summary>
public sealed partial class Cards
{
    /// <summary>
    /// Card属性
    /// </summary>
    /// <returns></returns>
    private IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
    {
        new AttributeItem
        {
            Name = "BodyTemplate",
            Description = Localizer["BodyTemplate"],
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "FooterTemplate",
            Description = Localizer["FooterTemplate"],
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem
        {
            Name = "HeaderTemplate",
            Description = Localizer["HeaderTemplate"],
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem
        {
            Name = "Class",
            Description = Localizer["Class"],
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem {
            Name = "Color",
            Description = Localizer["Color"],
            Type = "Color",
            ValueList = "None / Primary / Secondary / Success / Danger / Warning / Info / Light / Dark",
            DefaultValue = " — "
        },
        new AttributeItem {
            Name = "IsCenter",
            Description = Localizer["IsCenter"],
            Type = "boolean",
            ValueList = "true / false",
            DefaultValue = "false"
        },
        new AttributeItem
        {
            Name = "IsCollapsible",
            Description = Localizer["IsCollapsible"],
            Type = "boolean",
            ValueList = "true / false",
            DefaultValue = "false"
        },
        new AttributeItem
        {
            Name = nameof(Card.Collapsed),
            Description = Localizer["Collapsed"],
            Type = "boolean",
            ValueList = "true / false",
            DefaultValue = "false"
        },
        new AttributeItem
        {
            Name = "IsShadow",
            Description = Localizer["IsShadow"],
            Type = "boolean",
            ValueList = "true / false",
            DefaultValue = "false"
        }
    };
}

