﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// 
/// </summary>
public sealed partial class Avatars
{
    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private IEnumerable<AttributeItem> GetAttributes() => new[]
    {
        // TODO: 移动到数据库中
        new AttributeItem() {
            Name = "Size",
            Description = Localizer["Size"],
            Type = "Size",
            ValueList = "ExtraSmall|Small|Medium|Large|ExtraLarge|ExtraExtraLarge",
            DefaultValue = "None"
        },
        new AttributeItem() {
            Name = "IsBorder",
            Description = Localizer["IsBorder"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new AttributeItem() {
            Name = "IsCircle",
            Description = Localizer["IsCircle"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new AttributeItem() {
            Name = "IsIcon",
            Description = Localizer["IsIcon"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new AttributeItem() {
            Name = "IsText",
            Description = Localizer["IsText"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new AttributeItem() {
            Name = "Icon",
            Description = Localizer["Icon"],
            Type = "string",
            ValueList = " — ",
            DefaultValue = "fa-solid fa-user"
        },
        new AttributeItem() {
            Name = "Text",
            Description = Localizer["Text"],
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "Url",
            Description = Localizer["Url"],
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "GetUrlAsync",
            Description = Localizer["GetUrlAsync"],
            Type = "Func<Task<string>>",
            ValueList = " — ",
            DefaultValue = " — "
        }
    };
}
