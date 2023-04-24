﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// Dropdowns
/// </summary>
public sealed partial class Dropdowns
{
    /// <summary>
    /// GetAttributes
    /// </summary>
    /// <returns></returns>
    private IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
    {
        // TODO: 移动到数据库中
        new AttributeItem() {
            Name = "Value",
            Description = Localizer["ADesc1"],
            Type = "TValue",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "Class",
            Description = Localizer["ADesc2"],
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "Color",
            Description = Localizer["ADesc3"],
            Type = "Color",
            ValueList = "Primary / Secondary / Info / Warning / Danger ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "Direction",
            Description = Localizer["ADesc4"],
            Type = "Direction",
            ValueList = "Dropup / Dropright /  Dropleft",
            DefaultValue = " None "
        },
        new AttributeItem() {
            Name = "Items",
            Description = Localizer["ADesc5"],
            Type = "list",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "MenuAlignment",
            Description = Localizer["ADesc6"],
            Type = "Alignment",
            ValueList = "None / Left / Center / Right ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "MenuItem",
            Description = Localizer["ADesc7"],
            Type = "string",
            ValueList = "button / a ",
            DefaultValue = " a "
        },
        new AttributeItem() {
            Name = "Responsive",
            Description = Localizer["ADesc8"],
            Type = "string",
            ValueList = "dropdown-menu / dropdown-menu-end / dropdown-menu-{lg | md | sm }-{right | left}",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "ShowSplit",
            Description = Localizer["ADesc9"],
            Type = "bool",
            ValueList = "true / false ",
            DefaultValue = " false "
        },
        new AttributeItem() {
            Name = "Size",
            Description = Localizer["ADesc10"],
            Type = "Size",
            ValueList = "None / ExtraSmall / Small / Medium / Large / ExtraLarge / ExtraExtraLarge",
            DefaultValue = "None"
        },
        new AttributeItem() {
            Name = "TagName",
            Description = Localizer["ADesc11"],
            Type = "string",
            ValueList = " a / button ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = nameof(Dropdown<string>.FixedButtonText),
            Description = Localizer["FixedButtonText"],
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        }
    };

    /// <summary>
    /// GetEvents
    /// </summary>
    /// <returns></returns>
    private IEnumerable<EventItem> GetEvents() => new EventItem[]
    {
        new EventItem()
        {
            Name = "OnSelectedItemChanged",
            Description= Localizer["EDesc1"],
            Type ="Func<SelectedItem, Task>"
        }
   };
}
