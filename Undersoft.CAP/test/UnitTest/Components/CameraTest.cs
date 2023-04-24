﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace UnitTest.Components;

public class CameraTest : BootstrapBlazorTestBase
{
    [Fact]
    public async Task InitDevices_Ok()
    {
        var count = 0;
        var cut = Context.RenderComponent<Camera>(pb =>
        {
            pb.Add(a => a.OnInit, devices =>
            {
                count = devices.Count();
                return Task.CompletedTask;
            });
            pb.Add(a => a.NotFoundDevicesString, "NotFound");
            pb.Add(a => a.AutoStart, true);
        });
        await cut.InvokeAsync(() => cut.Instance.InitDevices(Enumerable.Empty<DeviceItem>()));
        cut.Contains("NotFound");

        await cut.InvokeAsync(() => cut.Instance.InitDevices(new DeviceItem[]
        {
            new DeviceItem()
            {
                DeviceId = "1",
                Label = "Device 1"
            },
            new DeviceItem()
            {
                DeviceId = "1"
            }
        }));
        Assert.Equal(2, count);
    }

    [Fact]
    public async Task GetError_Ok()
    {
        var msg = "";
        var cut = Context.RenderComponent<Camera>(pb =>
        {
            pb.Add(a => a.OnError, error =>
            {
                msg = error;
                return Task.CompletedTask;
            });
        });
        await cut.InvokeAsync(() => cut.Instance.GetError("Error"));
        Assert.Equal("Error", msg);
    }

    [Fact]
    public async Task Start_Ok()
    {
        var start = false;
        var cut = Context.RenderComponent<Camera>(pb =>
        {
            pb.Add(a => a.OnStart, () =>
            {
                start = true;
                return Task.CompletedTask;
            });
        });
        await cut.InvokeAsync(() => cut.Instance.Start());
        Assert.True(start);
    }

    [Fact]
    public async Task Stop_Ok()
    {
        var stop = false;
        var cut = Context.RenderComponent<Camera>(pb =>
        {
            pb.Add(a => a.OnClose, () =>
            {
                stop = true;
                return Task.CompletedTask;
            });
        });
        await cut.InvokeAsync(() => cut.Instance.Stop());
        Assert.True(stop);
    }

    [Fact]
    public async Task Capture_Ok()
    {
        var capture = false;
        var cut = Context.RenderComponent<Camera>(pb =>
        {
            pb.Add(a => a.OnCapture, payload =>
            {
                capture = true;
                return Task.CompletedTask;
            });
        });
        await cut.InvokeAsync(() => cut.Instance.Capture("test"));
        await cut.InvokeAsync(() => cut.Instance.Capture("__BB__%END%__BB__"));
        Assert.True(capture);
    }

    [Fact]
    public void ShowPreview_Ok()
    {
        var cut = Context.RenderComponent<Camera>(pb =>
        {
            pb.Add(a => a.ShowPreview, true);
        });
        cut.Contains("camera-header");
    }

    [Fact]
    public void Width_Height_Ok()
    {
        var cut = Context.RenderComponent<Camera>(pb =>
        {
            pb.Add(a => a.VideoWidth, 30);
            pb.Add(a => a.VideoHeight, 20);
        });
        Assert.Equal(40, cut.Instance.VideoWidth);
        Assert.Equal(30, cut.Instance.VideoHeight);
    }
}
