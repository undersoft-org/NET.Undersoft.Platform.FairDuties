﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace UnitTest.Components;

public class ListViewTest : BootstrapBlazorTestBase
{
    [Fact]
    public void Items_Ok()
    {
        var cut = Context.RenderComponent<ListView<Product>>(pb =>
        {
            pb.Add(a => a.BodyTemplate, p => builder => builder.AddContent(0, $"{p.ImageUrl}-{p.Description}-{p.Category}"));
        });
        cut.Markup.Contains("listview-body");
    }

    [Fact]
    public async Task ListView_Ok()
    {
        var clicked = false;
        var items = Enumerable.Range(1, 6).Select(i => new Product()
        {
            ImageUrl = $"images/Pic{i}.jpg",
            Description = $"Pic{i}.jpg",
            Category = $"Group{(i % 4) + 1}"
        });
        var cut = Context.RenderComponent<ListView<Product>>(pb =>
        {
            pb.Add(a => a.Items, items);
            pb.Add(a => a.HeaderTemplate, builder => builder.AddContent(0, "Test-Header"));
            pb.Add(a => a.BodyTemplate, p => builder => builder.AddContent(0, $"{p.ImageUrl}-{p.Description}-{p.Category}"));
            pb.Add(a => a.FooterTemplate, builder => builder.AddContent(0, "Footer-Header"));
            pb.Add(a => a.OnListViewItemClick, p =>
            {
                clicked = true;
                return Task.CompletedTask;
            });
        });
        cut.Contains("Test-Header");
        cut.Contains("Footer-Header");
        cut.Contains("images/Pic1.jpg");

        var item = cut.Find(".listview-item");
        await cut.InvokeAsync(() => item.Click());
        Assert.True(clicked);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.GroupName, p => p.Category);
            pb.Add(a => a.IsVertical, true);
        });
        cut.Contains("Group1");
        cut.Contains("is-vertical");

        clicked = false;
        item = cut.Find(".listview-item");
        await cut.InvokeAsync(() => item.Click());
        Assert.True(clicked);
    }

    [Fact]
    public void Pageable_Ok()
    {
        var items = Enumerable.Range(1, 6).Select(i => new Product()
        {
            ImageUrl = $"images/Pic{i}.jpg",
            Description = $"Pic{i}.jpg",
            Category = $"Group{(i % 4) + 1}"
        });
        var cut = Context.RenderComponent<ListView<Product>>(pb =>
        {
            pb.Add(a => a.OnQueryAsync, Query);
            pb.Add(a => a.Pageable, true);
            pb.Add(a => a.PageItems, 2);
        });

        var pages = cut.FindAll(".page-link");
        Assert.Equal(5, pages.Count);
        cut.InvokeAsync(() => pages[2].Click());

        Task<QueryData<Product>> Query(QueryPageOptions option) => Task.FromResult(new QueryData<Product>()
        {
            Items = items,
            TotalCount = 6
        });
    }

    [Fact]
    public void QueryAsync_Ok()
    {
        bool query = false;
        var items = Enumerable.Range(1, 6).Select(i => new Product()
        {
            ImageUrl = $"images/Pic{i}.jpg",
            Description = $"Pic{i}.jpg",
            Category = $"Group{(i % 4) + 1}"
        });
        var cut = Context.RenderComponent<ListView<Product>>(pb =>
        {
            pb.Add(a => a.OnQueryAsync, option =>
            {
                query = true;
                var ret = new QueryData<Product>()
                {
                    Items = items,
                    TotalCount = 6
                };
                return Task.FromResult(ret);
            });
            pb.Add(a => a.Pageable, true);
            pb.Add(a => a.PageItems, 2);
        });
        Assert.True(query);

        query = false;
        cut.InvokeAsync(() => cut.Instance.QueryAsync());
        Assert.True(query);
    }

    [Fact]
    public void Collapsable_Ok()
    {
        var clicked = false;
        var items = Enumerable.Range(1, 6).Select(i => new Product()
        {
            ImageUrl = $"images/Pic{i}.jpg",
            Description = $"Pic{i}.jpg",
            Category = $"Group{(i % 4) + 1}"
        });
        var cut = Context.RenderComponent<ListView<Product>>(pb =>
        {
            pb.Add(a => a.Collapsable, true);
            pb.Add(a => a.GroupName, p => p.Category);
            pb.Add(a => a.BodyTemplate, p => builder => builder.AddContent(0, $"{p.ImageUrl}-{p.Description}-{p.Category}"));
            pb.Add(a => a.OnQueryAsync, option =>
            {
                var ret = new QueryData<Product>()
                {
                    Items = items,
                    TotalCount = 6
                };
                return Task.FromResult(ret);
            });
            pb.Add(a => a.Pageable, true);
            pb.Add(a => a.PageItems, 2);
            pb.Add(a => a.OnListViewItemClick, p =>
            {
                clicked = true;
                return Task.CompletedTask;
            });
        });
        var collapse = cut.FindComponent<Collapse>();
        Assert.NotNull(collapse);

        var item = cut.Find(".listview-item");
        cut.InvokeAsync(() => item.Click());
        Assert.True(clicked);
    }

    [Fact]
    public void IsAccordion_Ok()
    {
        var items = Enumerable.Range(1, 6).Select(i => new Product()
        {
            ImageUrl = $"images/Pic{i}.jpg",
            Description = $"Pic{i}.jpg",
            Category = $"Group{(i % 4) + 1}"
        });
        var cut = Context.RenderComponent<ListView<Product>>(pb =>
        {
            pb.Add(a => a.Collapsable, true);
            pb.Add(a => a.IsAccordion, true);
            pb.Add(a => a.GroupName, p => p.Category);
            pb.Add(a => a.BodyTemplate, p => builder => builder.AddContent(0, $"{p.ImageUrl}-{p.Description}-{p.Category}"));
            pb.Add(a => a.OnQueryAsync, option =>
            {
                var ret = new QueryData<Product>()
                {
                    Items = items,
                    TotalCount = 6
                };
                return Task.FromResult(ret);
            });
            pb.Add(a => a.Pageable, true);
            pb.Add(a => a.PageItems, 2);
        });
        var collapse = cut.FindComponent<Collapse>();
        Assert.NotNull(collapse);
    }

    [Fact]
    public void CollapsedGroupCallback_Ok()
    {
        var callback = false;
        var items = Enumerable.Range(1, 6).Select(i => new Product()
        {
            ImageUrl = $"images/Pic{i}.jpg",
            Description = $"Pic{i}.jpg",
            Category = $"Group{(i % 4) + 1}"
        });
        var cut = Context.RenderComponent<ListView<Product>>(pb =>
        {
            pb.Add(a => a.Collapsable, true);
            pb.Add(a => a.IsAccordion, true);
            pb.Add(a => a.GroupName, p => p.Category);
            pb.Add(a => a.BodyTemplate, p => builder => builder.AddContent(0, $"{p.ImageUrl}-{p.Description}-{p.Category}"));
            pb.Add(a => a.CollapsedGroupCallback, p =>
            {
                callback = true;
                return p?.ToString() != "Group1";
            });
            pb.Add(a => a.OnQueryAsync, option =>
            {
                var ret = new QueryData<Product>()
                {
                    Items = items,
                    TotalCount = 6
                };
                return Task.FromResult(ret);
            });
            pb.Add(a => a.Pageable, true);
            pb.Add(a => a.PageItems, 2);
        });
        Assert.True(callback);
    }

    [Fact]
    public void OnCollapseChanged_Ok()
    {
        CollapseItem? expect = null;
        var items = Enumerable.Range(1, 6).Select(i => new Product()
        {
            ImageUrl = $"images/Pic{i}.jpg",
            Description = $"Pic{i}.jpg",
            Category = $"Group{(i % 4) + 1}"
        });
        var cut = Context.RenderComponent<ListView<Product>>(pb =>
        {
            pb.Add(a => a.Collapsable, true);
            pb.Add(a => a.GroupName, p => p.Category);
            pb.Add(a => a.BodyTemplate, p => builder => builder.AddContent(0, $"{p.ImageUrl}-{p.Description}-{p.Category}"));
            pb.Add(a => a.OnQueryAsync, option =>
            {
                var ret = new QueryData<Product>()
                {
                    Items = items,
                    TotalCount = 6
                };
                return Task.FromResult(ret);
            });
            pb.Add(a => a.OnCollapseChanged, item =>
            {
                expect = item;
                return Task.CompletedTask;
            });
            pb.Add(a => a.Pageable, true);
            pb.Add(a => a.PageItems, 2);
        });
        var button = cut.Find(".accordion-button");
        cut.InvokeAsync(() => button.Click());
        Assert.NotNull(expect);
    }

    private class Product
    {
        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }
    }
}
