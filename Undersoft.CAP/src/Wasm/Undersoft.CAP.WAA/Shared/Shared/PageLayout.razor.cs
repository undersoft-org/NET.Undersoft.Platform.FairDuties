﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.JSInterop;

namespace BootstrapBlazor.Shared.Shared;

/// <summary>
/// 
/// </summary>
public sealed partial class PageLayout
{
    private bool IsOpen { get; set; }

    private string? Theme { get; set; }

    private string? LayoutClassString => CssBuilder.Default()
        .AddClass(Theme)
        .AddClass("is-fixed-tab", IsFixedTab)
        .Build();

    private IEnumerable<MenuItem>? Menus { get; set; }

    /// <summary>
    /// 获得/设置 是否固定 TabHeader
    /// </summary>
    [Parameter]
    public bool IsFixedTab { get; set; }

    /// <summary>
    /// 获得/设置 是否固定页头
    /// </summary>
    [Parameter]
    public bool IsFixedHeader { get; set; } = true;

    /// <summary>
    /// 获得/设置 是否固定页脚
    /// </summary>
    [Parameter]
    public bool IsFixedFooter { get; set; } = true;

    /// <summary>
    /// 获得/设置 侧边栏是否外置
    /// </summary>
    [Parameter]
    public bool IsFullSide { get; set; } = true;

    /// <summary>
    /// 获得/设置 是否显示页脚
    /// </summary>
    [Parameter]
    public bool ShowFooter { get; set; } = true;

    /// <summary>
    /// 获得/设置 是否开启多标签模式
    /// </summary>
    [Parameter]
    public bool UseTabSet { get; set; } = true;

    [Inject]
    [NotNull]
    private IJSRuntime? JSRuntime { get; set; }

    /// <summary>
    /// OnInitializedAsync 方法
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        // 模拟异步获取菜单数据
        await Task.Delay(500);
        Menus = new List<MenuItem>
        {
            new MenuItem() { Text = "返回组件库", Icon = "fa-fw fa-solid fa-house", Url = "layouts" },
            new MenuItem() { Text = "后台模拟器", Icon = "fa-fw fa-solid fa-desktop", Url = "layout-page" },
            new MenuItem() { Text = "示例网页", Icon = "fa-fw fa-solid fa-laptop", Url = "layout-demo/text=Parameter1" }
        };
    }

    /// <summary>
    /// 更新组件方法
    /// </summary>
    public void Update() => StateHasChanged();

    private void ToggleDrawer()
    {
        IsOpen = !IsOpen;
    }
}
