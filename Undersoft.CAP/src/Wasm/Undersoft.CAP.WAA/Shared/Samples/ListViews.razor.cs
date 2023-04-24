﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// ListViews
/// </summary>
public sealed partial class ListViews
{
    internal class Product
    {
        public string ImageUrl { get; set; } = "";

        public string Description { get; set; } = "";

        public string Category { get; set; } = "";
    }

    private IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
    {
        new AttributeItem(){
            Name = "Items",
            Description = Localizer["Items"],
            Type = "IEnumerable<TItem>",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem(){
            Name = "Pageable",
            Description = Localizer["Pageable"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new AttributeItem(){
            Name = "HeaderTemplate",
            Description = Localizer["HeaderTemplate"],
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem(){
            Name = "BodyTemplate",
            Description = Localizer["BodyTemplate"],
            Type = "RenderFragment<TItem>",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem(){
            Name = "FooterTemplate",
            Description = Localizer["FooterTemplate"],
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem(){
            Name = nameof(ListView<Foo>.Collapsable),
            Description = Localizer["Collapsable"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new AttributeItem(){
            Name = nameof(ListView<Foo>.IsAccordion),
            Description = Localizer["IsAccordion"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new AttributeItem() {
            Name = "OnQueryAsync",
            Description = Localizer["OnQueryAsync"],
            Type = "Func<QueryPageOptions, Task<QueryData<TItem>>>",
            ValueList = "—",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = "OnListViewItemClick",
            Description = Localizer["OnListViewItemClick"],
            Type = "Func<TItem, Task>",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new AttributeItem() {
            Name = nameof(ListView<Foo>.CollapsedGroupCallback),
            Description = Localizer["CollapsedGroupCallback"],
            Type = "Func<object?, bool>",
            ValueList = " — ",
            DefaultValue = " — "
        }
    };

    private IEnumerable<MethodItem> GetMethods() => new MethodItem[]
    {
        new MethodItem()
        {
            Name = "QueryAsync",
            Description = Localizer["QueryAsync"],
            Parameters = " — ",
            ReturnValue = "Task"
        }
    };
}
