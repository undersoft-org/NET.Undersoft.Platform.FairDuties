﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace UnitTest.Components;

public class ButtonTest : BootstrapBlazorTestBase
{
    [Fact]
    public void ButtonStyle_Ok()
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.ButtonStyle, ButtonStyle.None);
        });
        Assert.DoesNotContain("btn-round", cut.Markup);
        Assert.DoesNotContain("btn-circle", cut.Markup);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.ButtonStyle, ButtonStyle.Circle);
        });
        Assert.Contains("btn-circle", cut.Markup);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.ButtonStyle, ButtonStyle.Round);
        });
        Assert.Contains("btn-round", cut.Markup);
    }

    [Fact]
    public void ButtonType_Ok()
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.ButtonType, ButtonType.Button);
        });
        Assert.Contains("type=\"button\"", cut.Markup);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.ButtonType, ButtonType.Submit);
        });
        Assert.Contains("type=\"submit\"", cut.Markup);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.ButtonType, ButtonType.Reset);
        });
        Assert.Contains("type=\"reset\"", cut.Markup);
    }

    [Theory]
    [InlineData(Color.Primary, "btn-primary")]
    [InlineData(Color.Secondary, "btn-secondary")]
    [InlineData(Color.Info, "btn-info")]
    [InlineData(Color.Success, "btn-success")]
    [InlineData(Color.Warning, "btn-warning")]
    [InlineData(Color.Danger, "btn-danger")]
    [InlineData(Color.Light, "btn-light")]
    [InlineData(Color.Dark, "btn-dark")]
    [InlineData(Color.Link, "btn-link")]
    [InlineData(Color.None, "btn")]
    public void Color_Ok(Color color, string @class)
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.Color, color);
        });
        Assert.Contains(@class, cut.Markup);
    }

    [Fact]
    public void DialogCloseButton_Color()
    {
        var cut = Context.RenderComponent<DialogCloseButton>();
        Assert.Contains("btn-secondary", cut.Markup);
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.Color, Color.Danger);
        });
        Assert.Contains("btn-danger", cut.Markup);
    }

    [Fact]
    public void Icon_Ok()
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.Icon, "fa-solid fa-font-awesome");
        });
        Assert.Contains("class=\"fa-solid fa-font-awesome\"", cut.Markup);
        Assert.Contains("fa-solid fa-spin fa-spinner", cut.Instance.LoadingIcon);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.LoadingIcon, "fa-solid fa-font-awesome");
        });
        Assert.Contains("fa-solid fa-font-awesome", cut.Instance.LoadingIcon);
    }

    [Fact]
    public async Task IsAsync_Ok()
    {
        // 同步点击
        var clicked = false;
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.IsAsync, false);
            pb.Add(b => b.OnClick, e => clicked = true);
        });
        var b = cut.Find("button");
        b.Click();
        Assert.True(clicked);

        // 异步点击
        var tcs = new TaskCompletionSource<bool>();
        clicked = false;
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.IsAsync, true);
            pb.Add(b => b.OnClick, async e =>
            {
                await Task.Delay(10);
                clicked = true;
                tcs.SetResult(true);
            });
        });
        b.Click();
        Assert.False(clicked);
        await tcs.Task;
        Assert.True(clicked);

        // 同步无刷新点击
        clicked = false;
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.IsAsync, false);
            pb.Add(b => b.OnClick, EventCallback<MouseEventArgs>.Empty);
            pb.Add(b => b.OnClickWithoutRender, () =>
            {
                clicked = true;
                return Task.CompletedTask;
            });
        });
        b.Click();
        Assert.True(clicked);

        // 异步无刷新点击
        clicked = false;
        tcs = new TaskCompletionSource<bool>();
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.IsAsync, true);
            pb.Add(b => b.OnClick, EventCallback<MouseEventArgs>.Empty);
            pb.Add(b => b.OnClickWithoutRender, async () =>
            {
                await Task.Delay(10);
                clicked = true;
                tcs.SetResult(true);
            });
        });
        b.Click();
        Assert.False(clicked);
        Assert.True(cut.Instance.IsDisabled);
        await tcs.Task;
        Assert.True(clicked);
    }

    [Fact]
    public void Text_Ok()
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.Text, "Test");
        });
        Assert.Contains("<span>Test</span>", cut.Markup);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.Text, null);
            pb.AddChildContent("Button-Test");
        });
        Assert.Contains("Button-Test", cut.Markup);
    }

    [Fact]
    public void IsOutline_Ok()
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.IsOutline, true);
        });
        Assert.Contains("btn-outline-primary", cut.Markup);
    }

    [Theory]
    [InlineData(Size.ExtraSmall, "btn-xs")]
    [InlineData(Size.Small, "btn-sm")]
    [InlineData(Size.Medium, "btn-md")]
    [InlineData(Size.Large, "btn-lg")]
    [InlineData(Size.ExtraLarge, "btn-xl")]
    [InlineData(Size.ExtraExtraLarge, "btn-xxl")]
    public void Size_Ok(Size size, string @class)
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.Size, size);
        });
        Assert.Contains(@class, cut.Markup);
    }

    [Fact]
    public void IsBlock_Ok()
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.IsBlock, true);
        });
        Assert.Contains("btn-block", cut.Markup);
    }

    [Fact]
    public void StopPropagation_Ok()
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(b => b.StopPropagation, true);
        });
    }

    [Fact]
    public async Task SetDisable_Ok()
    {
        var cut = Context.RenderComponent<Button>();
        Assert.DoesNotContain("disabled=\"disabled\"", cut.Markup);
        Assert.Contains("aria-disabled=\"false\"", cut.Markup);

        await cut.InvokeAsync(() => cut.Instance.SetDisable(true));
        Assert.Contains("disabled=\"disabled\"", cut.Markup);
        Assert.Contains("aria-disabled=\"true\"", cut.Markup);
    }

    [Fact]
    public void Tooltip_Ok()
    {
        var cut = Context.RenderComponent<Tooltip>(pb =>
        {
            pb.Add(a => a.Placement, Placement.Top);
            pb.Add(a => a.Title, "Tooltip");
            pb.AddChildContent<Button>();
        });

        var button = cut.FindComponent<Button>();
        cut.InvokeAsync(() => button.Instance.ShowTooltip());

        button.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.TooltipText, "Tooltip-Button");
        });
        Assert.Equal("Tooltip-Button", cut.Instance.Title);

        var cut1 = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(a => a.TooltipText, "tooltip");
        });
        cut1.InvokeAsync(() => cut1.Instance.ShowTooltip());
    }

    [Fact]
    public void Popover_Ok()
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.AddChildContent<Popover>(pb =>
            {
                pb.Add(t => t.Title, "popover-title");
            });
        });

        // 切换 Disabled 状态移除 Popover
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.IsDisabled, true);
        });

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(b => b.IsDisabled, false);
        });
    }

    [Fact]
    public async Task ValidateFormButton_Ok()
    {
        var valid = false;
        var tcs = new TaskCompletionSource<bool>();
        var model = Foo.Generate(Context.Services.GetRequiredService<IStringLocalizer<Foo>>());
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(v => v.Model, model);
            pb.Add(v => v.OnValidSubmit, context =>
            {
                valid = true;
                tcs.SetResult(true);
                return Task.CompletedTask;
            });
            pb.AddChildContent<BootstrapInput<string>>(pb =>
            {
                pb.Add(a => a.Value, model.Name);
                pb.Add(a => a.ValueChanged, v => model.Name = v);
                pb.Add(a => a.ValueExpression, model.GenerateValueExpression());
            });
            pb.AddChildContent<Button>(pb =>
            {
                pb.Add(b => b.IsAsync, true);
                pb.Add(b => b.ButtonType, ButtonType.Submit);
            });
        });
        cut.Find("input").Change("Test1");
        cut.Find("form").Submit();
        await tcs.Task;
        Assert.True(valid);
    }

    [Fact]
    public async Task ShowTooltip_Ok()
    {
        var cut = Context.RenderComponent<Button>();
        await cut.InvokeAsync(() => cut.Instance.ShowTooltip());
    }

    [Fact]
    public void Trigger_Ok()
    {
        var cut = Context.RenderComponent<Button>();
        cut.DoesNotContain("data-bs-trigger");

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.TooltipTrigger, "click");
        });
        cut.Contains("data-bs-trigger=\"click\"");
    }

    [Fact]
    public async Task RemoveTooltip_Ok()
    {
        var cut = Context.RenderComponent<Button>();
        await cut.InvokeAsync(() => cut.Instance.RemoveTooltip());
    }

    [Fact]
    public void IsAutoFocus_Ok()
    {
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(a => a.IsAutoFocus, true);
        });
    }

    [Fact]
    public void DialogCloseButton_Ok()
    {
        var clicked = false;
        var cut = Context.RenderComponent<DialogCloseButton>(pb =>
        {
            pb.AddCascadingValue<Func<Task>>(() =>
            {
                clicked = true;
                return Task.FromResult(0);
            });
        });
        var button = cut.Find("button");
        cut.InvokeAsync(() => button.Click());
        Assert.True(clicked);
    }

    [Fact]
    public void DialogSaveButton_Ok()
    {
        var cut = Context.RenderComponent<DialogSaveButton>();
        cut.Contains("button type=\"submit\"");
    }
}
