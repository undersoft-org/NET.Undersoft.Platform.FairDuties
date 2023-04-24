﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace UnitTest;

internal class MockTableColumn : ITableColumn
{
    public MockTableColumn(string fieldName, Type propertyType) => (FieldName, PropertyType) = (fieldName, propertyType);

    public string FieldName { get; }

    public Type PropertyType { get; }

    public bool Editable { get; set; }

    public bool Readonly { get; set; }

    /// <summary>
    /// 获得/设置 新建时此列只读 默认为 false
    /// </summary>
    public bool IsReadonlyWhenAdd { get; set; }

    /// <summary>
    /// 获得/设置 编辑时此列只读 默认为 false
    /// </summary>
    public bool IsReadonlyWhenEdit { get; set; }

    public bool SkipValidate { get; set; }

    public string? Text { get; set; }

    public IEnumerable<SelectedItem>? Items { get; set; }

    public object? Step { get; set; }

    public int Rows { get; set; }

    public RenderFragment<object>? EditTemplate { get; set; }

    public System.Type? ComponentType { get; set; }

    public bool Sortable { get; set; }

    public bool DefaultSort { get; set; }

    public SortOrder DefaultSortOrder { get; set; }

    public bool Filterable { get; set; }

    public bool Searchable { get; set; }

    public int? Width { get; set; }

    public bool Fixed { get; set; }

    public bool Visible { get; set; }

    public bool TextWrap { get; set; }

    public bool TextEllipsis { get; set; }

    public string? CssClass { get; set; }

    public BreakPoint ShownWithBreakPoint { get; set; }

    public RenderFragment<object>? Template { get; set; }

    public RenderFragment<object>? SearchTemplate { get; set; }

    public RenderFragment? FilterTemplate { get; set; }

    public RenderFragment<ITableColumn>? HeaderTemplate { get; set; }

    public IFilter? Filter { get; set; }

    public string? FormatString { get; set; }

    public Func<object?, Task<string>>? Formatter { get; set; }

    public Alignment Align { get; set; }

    public bool ShowTips { get; set; }

    public int Order { get; set; }

    public Action<TableCellArgs>? OnCellRender { get; set; }

    public IEnumerable<KeyValuePair<string, object>>? ComponentParameters { get; set; }

    public string? PlaceHolder { get; set; }

    /// <summary>
    /// 获得/设置 自定义验证集合
    /// </summary>
    public List<IValidator>? ValidateRules { get; set; }

    public IEnumerable<SelectedItem>? Lookup { get; set; }

    public bool ShowSearchWhenSelect { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public bool IsPopover { get; set; }

    public StringComparison LookupStringComparison { get; set; } = StringComparison.OrdinalIgnoreCase;

    public string? LookupServiceKey { get; set; }

    public bool? ShowLabelTooltip { get; set; }

    public string GetDisplayName() => Text ?? FieldName;

    public string GetFieldName() => FieldName;

    public string? GroupName { get; set; }

    public int GroupOrder { get; set; }

    public bool ShowCopyColumn { get; set; }

    public bool HeaderTextWrap { get; set; }

    public bool ShowHeaderTooltip { get; set; }

    public string? HeaderTextTooltip { get; set; }

    public bool HeaderTextEllipsis { get; set; }
}
