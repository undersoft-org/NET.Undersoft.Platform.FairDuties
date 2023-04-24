﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Components.Rendering;

namespace UnitTest.Components;

public class RibbonTabTest : BootstrapBlazorTestBase
{
    [Fact]
    public async Task ShowFloatButton_Ok()
    {
        var isFloat = false;
        RibbonTabItem? tabItem = null;
        var cut = Context.RenderComponent<RibbonTab>();
        Assert.DoesNotContain("ribbon-arrow", cut.Markup);
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.Items, GetItems());
            pb.Add(a => a.ShowFloatButton, true);
            pb.Add(a => a.RibbonArrowUpIcon, "test-up");
            pb.Add(a => a.RibbonArrowDownIcon, "test-down");
            pb.Add(a => a.RibbonArrowPinIcon, "test-pin");
            pb.Add(a => a.OnItemClickAsync, item =>
            {
                tabItem = item;
                return Task.CompletedTask;
            });
            pb.Add(a => a.OnFloatChanged, floating =>
            {
                isFloat = floating;
                return Task.CompletedTask;
            });
        });
        cut.Contains("class=\"ribbon-tab border\"");
        Assert.Contains("ribbon-arrow", cut.Markup);
        Assert.Contains("test-up", cut.Markup);

        var i = cut.Find(".ribbon-arrow > i");
        await cut.InvokeAsync(() => i.Click());
        Assert.True(isFloat);
        Assert.Contains("test-down", cut.Markup);

        // 点击 Tab 显示 pin 图标
        var tab = cut.Find(".tabs-item");
        await cut.InvokeAsync(() => tab.Click());
        Assert.Contains("test-pin", cut.Markup);

        var linkButton = cut.FindComponent<LinkButton>();
        await cut.InvokeAsync(() => linkButton.Instance.OnClick.InvokeAsync());
        Assert.NotNull(tabItem);

        await cut.InvokeAsync(() => i.Click());
        Assert.False(isFloat);
        Assert.Contains("test-up", cut.Markup);
    }

    [Fact]
    public async Task SetExpand_Ok()
    {
        var cut = Context.RenderComponent<RibbonTab>(pb =>
        {
            pb.Add(a => a.ShowFloatButton, true);
        });

        var i = cut.Find(".ribbon-arrow > i");
        await cut.InvokeAsync(() => i.Click());
        Assert.Contains("fa-angle-down", cut.Markup);

        await cut.InvokeAsync(() => cut.Instance.SetExpand());
        Assert.Contains("fa-angle-down", cut.Markup);
    }

    [Fact]
    public void RightButtonsTemplate_Ok()
    {
        var cut = Context.RenderComponent<RibbonTab>(pb =>
        {
            pb.Add(a => a.RightButtonsTemplate, builder =>
            {
                builder.AddContent(0, "test-content");
            });
        });
        Assert.Contains("test-content", cut.Markup);
    }

    [Fact]
    public void RibbonTabItem_Ok()
    {
        var item = new RibbonTabItem()
        {
            ImageUrl = "test-image-url",
            Command = "test-command"
        };
        Assert.Equal("test-image-url", item.ImageUrl);
        Assert.Equal("test-command", item.Command);
    }

    [Fact]
    public void RibbonTabItem_Template()
    {
        var cut = Context.RenderComponent<RibbonTab>(pb =>
        {
            pb.Add(a => a.Items, new RibbonTabItem[]
            {
                new RibbonTabItem()
                {
                    Text = "test",
                    Items = new RibbonTabItem[]
                    {
                        new RibbonTabItem()
                        {
                            Text = "Item",
                            Template = builder => builder.AddContent(0, "Test-Template")
                        }
                    }
                }
            });
        });
        Assert.Contains("Test-Template", cut.Markup);
    }

    [Fact]
    public void RibbonTabItem_Component()
    {
        var cut = Context.RenderComponent<RibbonTab>(pb =>
        {
            pb.Add(a => a.Items, new RibbonTabItem[]
            {
                new RibbonTabItem()
                {
                    Text = "test",
                    Items = new RibbonTabItem[]
                    {
                        new RibbonTabItem()
                        {
                            Text = "Item",
                            Component = BootstrapDynamicComponent.CreateComponent<MockCom>()
                        }
                    }
                }
            });
        });
        Assert.Contains("Test-Template", cut.Markup);
    }

    [Fact]
    public void ChildContent_Ok()
    {
        var cut = Context.RenderComponent<RibbonTab>(pb =>
        {
            pb.Add(a => a.Items, new RibbonTabItem[]
            {
                new RibbonTabItem()
                {
                    Text = "test",
                    Items = new RibbonTabItem[]
                    {
                        new RibbonTabItem()
                        {
                            Text = "Item"
                        }
                    }
                }
            });
            pb.Add(a => a.ChildContent, builder =>
            {
                builder.AddContent(0, "test-child-content");
            });
        });
        Assert.Contains("test-child-content", cut.Markup);
        Assert.Contains("ribbon-body", cut.Markup);
    }

    [Fact]
    public void OnMenuClickAsync_Ok()
    {
        var clickedText = "";
        var cut = Context.RenderComponent<RibbonTab>(pb =>
        {
            pb.Add(a => a.Items, new RibbonTabItem[]
            {
                new RibbonTabItem()
                {
                    Text = "test 1",
                    Items = new RibbonTabItem[]
                    {
                        new RibbonTabItem()
                        {
                            Text = "Item"
                        }
                    }
                }
            });
            pb.Add(a => a.OnMenuClickAsync, item =>
            {
                clickedText = item.Text;
                return Task.CompletedTask;
            });
        });

        var tab = cut.Find(".tabs-item");
        cut.InvokeAsync(() => tab.Click());
        Assert.Equal("test 1", clickedText);
    }

    [Fact]
    public void IsBoard_Ok()
    {
        var cut = Context.RenderComponent<RibbonTab>(pb =>
        {
            pb.Add(a => a.Items, new RibbonTabItem[]
            {
                new RibbonTabItem()
                {
                    Text = "test 1",
                    Items = new RibbonTabItem[]
                    {
                        new RibbonTabItem()
                        {
                            Text = "Item"
                        }
                    }
                }
            });
            pb.Add(a => a.IsBorder, false);
        });
        cut.Contains("class=\"ribbon-tab\"");
    }

    [Fact]
    public void IsDefault_Ok()
    {
        var item = new RibbonTabItem() { IsDefault = true };
        Assert.True(item.IsDefault);
    }

    private static IEnumerable<RibbonTabItem> GetItems() => new List<RibbonTabItem>()
    {
        new()
        {
            Text = "文件",
            Items = new List<RibbonTabItem>()
            {
                new() { Text = "常规操作", Icon = "fa-solid fa-font-awesome", GroupName = "操作组一" },
                new() { Text = "常规操作", Icon = "fa-solid fa-font-awesome", GroupName = "操作组一" },
                new() { Text = "常规操作", Icon = "fa-solid fa-font-awesome", GroupName = "操作组一" },
                new() { Text = "打开", Icon = "fa-solid fa-font-awesome", GroupName = "操作组二" },
                new() { Text = "保存", Icon = "fa-solid fa-font-awesome", GroupName = "操作组二" },
                new() { Text = "另存为", Icon = "fa-solid fa-font-awesome", GroupName = "操作组二" }
            }
        },
        new()
        {
            Text = "编辑",
            Items = new List<RibbonTabItem>()
            {
                new() { Text = "打开", Icon = "fa-solid fa-font-awesome", GroupName = "操作组三", IsDefault = true },
                new() { Text = "保存", Icon = "fa-solid fa-font-awesome", GroupName = "操作组三" },
                new() { Text = "另存为", Icon = "fa-solid fa-font-awesome", GroupName = "操作组三" },
                new() { Text = "常规操作", Icon = "fa-solid fa-font-awesome", GroupName = "操作组四" },
                new() { Text = "常规操作", Icon = "fa-solid fa-font-awesome", GroupName = "操作组四" },
                new() { Text = "常规操作", Icon = "fa-solid fa-font-awesome", GroupName = "操作组四" }
            }
        }
    };

    class MockCom : ComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(0, "Test-Template");
        }
    }
}
