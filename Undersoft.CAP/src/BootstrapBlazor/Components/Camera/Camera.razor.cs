﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.Extensions.Localization;
using System.Text;

namespace BootstrapBlazor.Components;

/// <summary>
/// 
/// </summary>
public partial class Camera : IAsyncDisposable
{
    private ElementReference CameraElement { get; set; }

    private JSInterop<Camera>? Interop { get; set; }

    private string DeviceId { get; set; } = "";

    private bool IsDisabled { get; set; } = true;

    private bool CaptureDisabled { get; set; } = true;

    private IEnumerable<SelectedItem> Devices { get; set; } = Enumerable.Empty<SelectedItem>();

    [NotNull]
    private IEnumerable<SelectedItem>? Cameras { get; set; }

    private SelectedItem? ActiveCamera { get; set; }

    /// <summary>
    /// 获得/设置 是否自动开启摄像头 默认为 false
    /// </summary>
    [Parameter]
    public bool AutoStart { get; set; }

    /// <summary>
    /// 获得/设置 前置摄像头显示文本 默认前置
    /// </summary>
    [Parameter]
    [NotNull]
    public string? FrontText { get; set; }

    /// <summary>
    /// 获得/设置 后置摄像头显示文本 默认后置
    /// </summary>
    [Parameter]
    [NotNull]
    public string? BackText { get; set; }

    /// <summary>
    /// 获得/设置 是否显示 照片预览 默认为 false 不预览
    /// </summary>
    [Parameter]
    public bool ShowPreview { get; set; }

    /// <summary>
    /// 获得/设置 设备列表前置标签文字 默认为 摄像头
    /// </summary>
    [Parameter]
    [NotNull]
    public string? DeviceLabel { get; set; }

    /// <summary>
    /// 获得/设置 初始化设备列表文字 默认为 正在识别摄像头
    /// </summary>
    [Parameter]
    [NotNull]
    public string? InitDevicesString { get; set; }

    /// <summary>
    /// 获得/设置 摄像头视频宽度
    /// </summary>
    [Parameter]
    public int VideoWidth { get; set; } = 320;

    /// <summary>
    /// 获得/设置 摄像头视频高度
    /// </summary>
    [Parameter]
    public int VideoHeight { get; set; } = 240;

    /// <summary>
    /// 获得/设置 初始化摄像头回调方法
    /// </summary>
    [Parameter]
    public Func<IEnumerable<DeviceItem>, Task>? OnInit { get; set; }

    /// <summary>
    /// 获得/设置 扫码出错回调方法
    /// </summary>
    [Parameter]
    public Func<string, Task>? OnError { get; set; }

    /// <summary>
    /// 获得/设置 开始扫码回调方法
    /// </summary>
    [Parameter]
    public Func<Task>? OnStart { get; set; }

    /// <summary>
    /// 获得/设置 关闭扫码回调方法
    /// </summary>
    [Parameter]
    public Func<Task>? OnClose { get; set; }

    /// <summary>
    /// 获得/设置 扫码成功回调方法
    /// </summary>
    [Parameter]
    public Func<string, Task>? OnCapture { get; set; }

    /// <summary>
    /// 获得/设置 开始按钮图标
    /// </summary>
    [Parameter]
    [NotNull]
    public string? PlayIcon { get; set; }

    /// <summary>
    /// 获得/设置 停止按钮图标
    /// </summary>
    [Parameter]
    [NotNull]
    public string? StopIcon { get; set; }

    /// <summary>
    /// 获得/设置 拍照按钮图标
    /// </summary>
    [Parameter]
    [NotNull]
    public string? PhotoIcon { get; set; }

    /// <summary>
    /// 获得/设置 开启按钮显示文本 默认为开启
    /// </summary>
    [Parameter]
    [NotNull]
    public string? PlayText { get; set; }

    /// <summary>
    /// 获得/设置 关闭按钮显示文本 默认为关闭
    /// </summary>
    [Parameter]
    [NotNull]
    public string? StopText { get; set; }

    /// <summary>
    /// 获得/设置 拍照按钮显示文本 默认为拍照
    /// </summary>
    [Parameter]
    [NotNull]
    public string? PhotoText { get; set; }

    /// <summary>
    /// 获得/设置 未找到视频相关设备文字 默认为 未找到视频相关设备
    /// </summary>
    [Parameter]
    [NotNull]
    public string? NotFoundDevicesString { get; set; }

    [Inject]
    [NotNull]
    private IStringLocalizer<Camera>? Localizer { get; set; }

    [Inject]
    [NotNull]
    private IIconTheme? IconTheme { get; set; }

    private string VideoWidthString => $"{VideoWidth}px;";

    private string VideoHeightString => $"{VideoHeight}px;";

    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        PlayText ??= Localizer[nameof(PlayText)];
        StopText ??= Localizer[nameof(StopText)];
        PhotoText ??= Localizer[nameof(PhotoText)];
        DeviceLabel ??= Localizer[nameof(DeviceLabel)];
        InitDevicesString ??= Localizer[nameof(InitDevicesString)];
        NotFoundDevicesString ??= Localizer[nameof(NotFoundDevicesString)];
        FrontText ??= Localizer[nameof(FrontText)];
        BackText ??= Localizer[nameof(BackText)];

        Cameras = new SelectedItem[]
        {
            new SelectedItem { Text = FrontText!, Value = "user", Active = true },
            new SelectedItem { Text = BackText!, Value = "environment" }
        };
    }

    /// <summary>
    /// OnParametersSet 方法
    /// </summary>
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        PlayIcon ??= IconTheme.GetIconByKey(ComponentIcons.CameraPlayIcon);
        StopIcon ??= IconTheme.GetIconByKey(ComponentIcons.CameraStopIcon);
        PhotoIcon ??= IconTheme.GetIconByKey(ComponentIcons.CameraPhotoIcon);

        if (VideoWidth < 40)
        {
            VideoWidth = 40;
        }

        if (VideoHeight < 30)
        {
            VideoHeight = 30;
        }
    }

    /// <summary>
    /// OnAfterRenderAsync 方法
    /// </summary>
    /// <param name="firstRender"></param>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            Interop = new JSInterop<Camera>(JSRuntime);
            await Interop.InvokeVoidAsync(this, CameraElement, "bb_camera", "init", AutoStart, VideoWidth, VideoHeight);
        }
    }

    /// <summary>
    /// 初始化设备方法
    /// </summary>
    /// <param name="devices"></param>
    /// <returns></returns>
    [JSInvokable]
    public async Task InitDevices(IEnumerable<DeviceItem> devices)
    {
        Devices = devices.Select(i => new SelectedItem { Value = i.DeviceId, Text = i.Label });
        IsDisabled = !Devices.Any();

        if (OnInit != null)
        {
            await OnInit(devices);
        }

        if (devices.Any())
        {
            for (var index = 0; index < devices.Count(); index++)
            {
                var d = devices.ElementAt(index);
                if (string.IsNullOrEmpty(d.Label))
                {
                    d.Label = $"Video device {index + 1}";
                }
            }
            ActiveCamera = Cameras.First();
        }

        if (IsDisabled)
        {
            InitDevicesString = NotFoundDevicesString;
        }

        StateHasChanged();
    }

    /// <summary>
    /// 扫描发生错误回调方法
    /// </summary>
    /// <param name="err"></param>
    /// <returns></returns>
    [JSInvokable]
    public async Task GetError(string err)
    {
        if (OnError != null)
        {
            await OnError.Invoke(err);
        }
    }

    /// <summary>
    /// 开启摄像头回调方法
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public async Task Start()
    {
        CaptureDisabled = false;
        if (OnStart != null)
        {
            await OnStart.Invoke();
        }

        StateHasChanged();
    }

    /// <summary>
    /// 停止摄像头回调方法
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public async Task Stop()
    {
        CaptureDisabled = true;
        if (OnClose != null)
        {
            await OnClose.Invoke();
        }

        StateHasChanged();
    }

    private readonly StringBuilder _sb = new();
    /// <summary>
    /// 拍照回调方法
    /// </summary>
    /// <returns></returns>
    [JSInvokable]
    public async Task Capture(string payload)
    {
        if (payload == "__BB__%END%__BB__")
        {
            var data = _sb.ToString();
            _sb.Clear();
            if (OnCapture != null)
            {
                await OnCapture(data);
            }
        }
        else
        {
            _sb.Append(payload);
        }
    }

    /// <summary>
    /// DisposeAsyncCore 方法
    /// </summary>
    /// <param name="disposing"></param>
    /// <returns></returns>
    protected virtual async ValueTask DisposeAsyncCore(bool disposing)
    {
        if (disposing)
        {
            if (Interop != null)
            {
                await JSRuntime.InvokeVoidAsync(CameraElement, "bb_camera", "", "stop").ConfigureAwait(false);
                Interop.Dispose();
                Interop = null;
            }
        }
    }

    /// <summary>
    /// DisposeAsync 方法
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore(true).ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }
}
