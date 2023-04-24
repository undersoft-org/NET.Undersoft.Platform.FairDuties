﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples.Table;

/// <summary>
/// TablesCell
/// </summary>
public partial class TablesCell
{
    private IEnumerable<AttributeItem> GetAttributes()
    {
        return new[]
        {
            new AttributeItem() {
                Name = "Row",
                Description = Localizer["RowAttr"],
                Type = "object",
                ValueList = " — ",
                DefaultValue = "<TModel>"
            },
            new AttributeItem() {
                Name = "ColumnName",
                Description = Localizer["ColumnNameAttr"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "Colspan",
                Description = Localizer["ColspanAttr"],
                Type = "int",
                ValueList = " — ",
                DefaultValue = "0"
            },
            new AttributeItem() {
                Name = "Class",
                Description = Localizer["ClassAttr"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "Value",
                Description = Localizer["ValueAttr"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            }
        };
    }
}
