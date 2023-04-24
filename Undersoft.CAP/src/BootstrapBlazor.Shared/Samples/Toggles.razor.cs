﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// Toggles
/// </summary>
public sealed partial class Toggles
{
    /// <summary>
    /// 获得事件方法
    /// </summary>
    /// <returns></returns>
    private IEnumerable<EventItem> GetEvents() => new EventItem[]
    {
        new EventItem()
        {
            Name = "ValueChanged",
            Description = Localizer["ValueChanged"],
            Type = "EventCallback<bool>"
        }
    };

    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
    {
        // TODO: 移动到数据库中
        new AttributeItem() {
            Name = "Color",
            Description = Localizer["Color"],
            Type = "Color",
            ValueList = "Primary / Secondary / Success / Danger / Warning / Info / Dark",
            DefaultValue = "Success"
        },
        new AttributeItem() {
            Name = "IsDisabled",
            Description = Localizer["IsDisabled"],
            Type = "boolean",
            ValueList = "true / false",
            DefaultValue = "false"
        },
        new AttributeItem() {
            Name = "OffText",
            Description = Localizer["OffTextAttr"],
            Type = "string",
            ValueList = "—",
            DefaultValue = Localizer["OffTextDefautValue"]!
        },
        new AttributeItem() {
            Name = "OnText",
            Description = Localizer["OnTextAttr"],
            Type = "string",
            ValueList = "—",
            DefaultValue = Localizer["OnTextDefautValue"]!
        },
        new AttributeItem() {
            Name = "Width",
            Description = Localizer["Width"],
            Type = "int",
            ValueList = " — ",
            DefaultValue = "120"
        },
        new AttributeItem() {
            Name = "Value",
            Description = Localizer["Value"],
            Type = "boolean",
            ValueList = " ",
            DefaultValue = "None"
        },
        new AttributeItem() {
            Name = "ShowLabel",
            Description = Localizer["ShowLabel"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "true"
        },
        new AttributeItem() {
            Name = "DisplayText",
            Description = Localizer["DisplayText"],
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "OnValueChanged",
            Description = Localizer["OnValueChanged"],
            Type = "Func<bool, Task>",
            ValueList = " — ",
            DefaultValue = " — "
        }
    };
}
