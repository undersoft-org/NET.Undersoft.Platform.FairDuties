﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// InputNumbers
/// </summary>
public sealed partial class InputNumbers
{
    private IEnumerable<AttributeItem> GetAttributes()
    {
        return new[]
        {
            new AttributeItem() {
                Name = "Value",
                Description = Localizer["InputNumbersAtt1"],
                Type = "sbyte|byte|int|long|short|float|double|decimal",
                ValueList = " — ",
                DefaultValue = "0"
            },
            new AttributeItem() {
                Name = "Max",
                Description = Localizer["InputNumbersAtt2"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem()
            {
                Name = "Min",
                Description = Localizer["InputNumbersAtt3"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem()
            {
                Name = "Step",
                Description = Localizer["InputNumbersAtt4"],
                Type = "int|long|short|float|double|decimal",
                ValueList = " — ",
                DefaultValue = "1"
            },
            new AttributeItem()
            {
                Name = "IsDisabled",
                Description = Localizer["InputNumbersAtt5"],
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "false"
            },
            new AttributeItem() {
                Name = "ShowLabel",
                Description = Localizer["InputNumbersAtt6"],
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "false"
            },
            new AttributeItem() {
                Name = "DisplayText",
                Description = Localizer["InputNumbersAtt7"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            }
        };
    }
}
