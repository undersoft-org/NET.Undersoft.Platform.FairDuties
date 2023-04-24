﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Shared;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace UnitTest.Components;

public class UploadTest : BootstrapBlazorTestBase
{
    [Fact]
    public async Task InputUpload_Ok()
    {
        UploadFile? uploadFile = null;
        var cut = Context.RenderComponent<InputUpload<string>>(pb =>
        {
            pb.Add(a => a.PlaceHolder, "TestPlaceHolder");
            pb.Add(a => a.OnChange, file =>
            {
                uploadFile = file;
                return Task.CompletedTask;
            });
            pb.Add(a => a.Value, "test.jpg");
        });
        cut.Contains("value=\"test.jpg\"");

        var input = cut.FindComponent<InputFile>();
        await cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));
        Assert.Equal("UploadTestFile", uploadFile!.OriginFileName);
        cut.Contains("fa-regular fa-folder-open");
        cut.Contains("btn-primary");
        cut.Contains("TestPlaceHolder");

        // 参数
        cut.SetParametersAndRender(pb => pb.Add(a => a.BrowserButtonIcon, "fa-solid fa-chrome"));
        cut.Contains("fa-solid fa-chrome");

        cut.SetParametersAndRender(pb => pb.Add(a => a.BrowserButtonClass, "btn btn-browser"));
        cut.Contains("btn btn-browser");

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.ShowDeleteButton, true);
            pb.Add(a => a.DeleteButtonText, "Delete-Test");
            pb.Add(a => a.DeleteButtonIcon, "fa-solid fa-trash");
        });
        cut.Contains("fa-solid fa-trash");
        cut.Contains("btn-danger");

        // 删除逻辑
        var deleted = false;
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.DeleteButtonClass, "btn btn-delete");
            pb.Add(a => a.OnDelete, file =>
            {
                deleted = true;
                return Task.FromResult(true);
            });
        });
        cut.Contains("btn btn-delete");

        var button = cut.Find(".input-group button");
        await cut.InvokeAsync(() => button.Click());
        Assert.True(deleted);

        // IsDisable
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.IsDisabled, true);
        });
        cut.Contains("btn btn-delete");
    }

    [Fact]
    public async Task InputUpload_ValidateForm_Ok()
    {
        var invalid = false;
        var foo = new Foo();
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(a => a.Model, foo);
            pb.AddChildContent<InputUpload<string>>(pb =>
            {
                pb.Add(a => a.Value, foo.Name);
                pb.Add(a => a.ValueExpression, foo.GenerateValueExpression());
            });
            pb.Add(a => a.OnValidSubmit, context =>
            {
                invalid = false;
                return Task.CompletedTask;
            });
            pb.Add(a => a.OnInvalidSubmit, context =>
            {
                invalid = true;
                return Task.CompletedTask;
            });
        });

        // 提交表单
        var form = cut.Find("form");
        await cut.InvokeAsync(() => form.Submit());
        Assert.True(invalid);

        var input = cut.FindComponent<InputFile>();
        await cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));
        await cut.InvokeAsync(() => form.Submit());
        Assert.False(invalid);
    }

    [Fact]
    public void InputUpload_FileValidate_OK()
    {
        var foo = new Person();
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(a => a.Model, foo);
            pb.AddChildContent<InputUpload<IBrowserFile>>(pb =>
            {
                pb.Add(a => a.Value, foo.Picture);
                pb.Add(a => a.ValueExpression, Utility.GenerateValueExpression(foo, nameof(Person.Picture), typeof(IBrowserFile)));
            });
        });

        var input = cut.FindComponent<InputFile>();
        cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));

        // 提交表单
        var form = cut.Find("form");
        cut.InvokeAsync(() => form.Submit());
    }

    [Fact]
    public void AvatarUpload_Ok()
    {
        UploadFile? uploadFile = null;
        var cut = Context.RenderComponent<AvatarUpload<string>>(pb =>
        {
            pb.Add(a => a.IsSingle, true);
            pb.Add(a => a.OnChange, file =>
            {
                uploadFile = file;
                return Task.CompletedTask;
            });
        });
        var input = cut.FindComponent<InputFile>();
        cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));

        // Height/Width
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.Height, 40);
            pb.Add(a => a.Width, 50);
        });
        cut.Contains("width: 50px;");
        cut.Contains("height: 40px;");

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.IsCircle, true);
        });
        cut.Contains("height: 50px;");

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.Height, 0);
        });
        cut.Contains("height: 50px;");

        // DefaultFileList
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.OnChange, null);
            pb.Add(a => a.ShowProgress, true);
            pb.Add(a => a.DefaultFileList, new List<UploadFile>()
            {
                new UploadFile() { FileName  = "Test-File" }
            });
        });
        input = cut.FindComponent<InputFile>();
        cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));

        // upload-item-delete
        var button = cut.Find(".upload-item-delete");
        cut.InvokeAsync(() => button.Click());

        // isdisable
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.IsDisabled, true);
        });
    }

    [Fact]
    public void AvatarUpload_Value_Ok()
    {
        var cut = Context.RenderComponent<AvatarUpload<IBrowserFile>>(pb => pb.Add(a => a.IsSingle, true));
        var input = cut.FindComponent<InputFile>();
        cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));
        Assert.Equal("UploadTestFile", cut.Instance.Value!.Name);
    }

    [Fact]
    public async Task AvatarUpload_ListValue_Ok()
    {
        var cut = Context.RenderComponent<AvatarUpload<List<IBrowserFile>>>();
        var input = cut.FindComponent<InputFile>();
        await cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));
        Assert.Single(cut.Instance.Value);
    }

    [Fact]
    public async Task AvatarUpload_ValidateForm_Ok()
    {
        var invalid = false;
        var foo = new Foo();
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(a => a.Model, foo);
            pb.AddChildContent<AvatarUpload<string>>(pb =>
            {
                pb.Add(a => a.Accept, "Image");
                pb.Add(a => a.Value, foo.Name);
                pb.Add(a => a.ValueExpression, foo.GenerateValueExpression());
            });
            pb.Add(a => a.OnValidSubmit, context =>
            {
                invalid = false;
                return Task.CompletedTask;
            });
            pb.Add(a => a.OnInvalidSubmit, context =>
            {
                invalid = true;
                return Task.CompletedTask;
            });
        });

        // 提交表单
        var form = cut.Find("form");
        await cut.InvokeAsync(() => form.Submit());
        Assert.True(invalid);

        var input = cut.FindComponent<InputFile>();
        await cut.InvokeAsync(async () =>
        {
            await input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
            {
                new MockBrowserFile()
            }));
            form.Submit();
        });
        Assert.False(invalid);
    }

    [Fact]
    public async Task AvatarUpload_Validate_Ok()
    {
        var invalid = true;
        var foo = new Foo
        {
            Name = "abc"
        };
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(a => a.Model, foo);
            pb.AddChildContent<AvatarUpload<string>>(pb =>
            {
                pb.Add(a => a.Accept, "Image");
                pb.Add(a => a.Value, foo.Name);
                pb.Add(a => a.ValueExpression, foo.GenerateValueExpression());
            });
            pb.Add(a => a.OnValidSubmit, context =>
            {
                invalid = false;
                return Task.CompletedTask;
            });
        });

        // 由于设置了属性 Name 值 Validate 方法通过
        var form = cut.Find("form");
        await cut.InvokeAsync(() => form.Submit());
        Assert.False(invalid);
    }

    [Fact]
    public void AvatarUpload_FileValidate_Ok()
    {
        var foo = new Person();
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(a => a.Model, foo);
            pb.AddChildContent<AvatarUpload<IBrowserFile>>(pb =>
            {
                pb.Add(a => a.Value, foo.Picture);
                pb.Add(a => a.ValueExpression, Utility.GenerateValueExpression(foo, nameof(Person.Picture), typeof(IBrowserFile)));
            });
        });

        var input = cut.FindComponent<InputFile>();
        cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));

        // 提交表单
        var form = cut.Find("form");
        cut.InvokeAsync(() => form.Submit());
    }

    [Fact]
    public void ButtonUpload_Ok()
    {
        UploadFile? uploadFile = null;
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.IsSingle, true);
            pb.Add(a => a.BrowserButtonClass, "browser-class");
            pb.Add(a => a.BrowserButtonIcon, "fa-solid fa-chrome");
        });
        cut.Contains("fa-solid fa-chrome");
        cut.Contains("browser-class");
        cut.DoesNotContain("form-label");

        // DefaultFileList
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.ShowProgress, true);
            pb.Add(a => a.OnChange, file =>
            {
                uploadFile = file;
                return Task.CompletedTask;
            });
        });
        var input = cut.FindComponent<InputFile>();
        cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));
    }

    [Fact]
    public void ButtonUpload_IsDisabled_Ok()
    {
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.IsDisabled, true);
        });
        var button = cut.Find(".btn-browser");
        Assert.Contains("disabled=\"disabled\"", button.ToMarkup());

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.IsDisabled, false);
            pb.Add(a => a.IsSingle, false);
        });
        Assert.DoesNotContain("disabled=\"disabled\"", button.ToMarkup());

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.IsDisabled, false);
            pb.Add(a => a.IsSingle, true);
        });
        Assert.DoesNotContain("disabled=\"disabled\"", button.ToMarkup());

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.IsDisabled, false);
            pb.Add(a => a.IsSingle, true);
        });
        var input = cut.FindComponent<InputFile>();
        cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));
        Assert.Contains("disabled=\"disabled\"", button.ToMarkup());
    }

    [Fact]
    public void ButtonUpload_ValidateForm_Ok()
    {
        var foo = new Foo();
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(a => a.Model, foo);
            pb.AddChildContent<ButtonUpload<string>>(pb =>
            {
                pb.Add(a => a.Value, foo.Name);
                pb.Add(a => a.ValueExpression, foo.GenerateValueExpression());
            });
        });
        cut.Contains("form-label");

        // ValidateId 为空情况
        var uploader = cut.FindComponent<ButtonUpload<string>>();
        var pi = typeof(ButtonUpload<string>).GetProperty("UploadFiles", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        Assert.NotNull(pi);
        var filesValue = pi.GetValue(uploader.Instance);

        if (filesValue is List<UploadFile> fs)
        {
            fs.Add(new UploadFile());
        }
        var results = new List<ValidationResult>()
        {
            new ValidationResult("test", new string[] { "bb_validate_123" })
        };
        uploader.Instance.ToggleMessage(results, true);
    }

    [Fact]
    public async Task ButtonUpload_ShowDownload()
    {
        var clicked = false;
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.ShowDownloadButton, true);
            pb.Add(a => a.OnDownload, file =>
            {
                clicked = true;
                return Task.CompletedTask;
            });
            pb.Add(a => a.DefaultFileList, new List<UploadFile>()
            {
                new UploadFile() { FileName  = "Test-File1.text" }
            });
        });

        var button = cut.Find(".fa-download");
        await cut.InvokeAsync(() => button.Click());
        Assert.True(clicked);
    }

    [Fact]
    public async Task ButtonUpload_Validate_Ok()
    {
        var invalid = true;
        var foo = new Foo
        {
            Name = "abc"
        };
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(a => a.Model, foo);
            pb.AddChildContent<ButtonUpload<string>>(pb =>
            {
                pb.Add(a => a.Accept, "Image");
                pb.Add(a => a.Value, foo.Name);
                pb.Add(a => a.ValueExpression, foo.GenerateValueExpression());
            });
            pb.Add(a => a.OnValidSubmit, context =>
            {
                invalid = false;
                return Task.CompletedTask;
            });
        });

        // 由于设置了属性 Name 值 Validate 方法通过
        var form = cut.Find("form");
        await cut.InvokeAsync(() => form.Submit());
        Assert.False(invalid);
    }

    [Fact]
    public void ShowUploadList_Ok()
    {
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.Accept, "Image");
        });

        cut.Contains("upload-body is-list");

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.ShowUploadFileList, false);
        });
        cut.DoesNotContain("upload-body is-list");
    }

    [Fact]
    public async Task ButtonUpload_OnDeleteFile_Ok()
    {
        UploadFile? deleteFile = null;
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.IsSingle, false);
            pb.Add(a => a.DefaultFileList, new List<UploadFile>()
            {
                new UploadFile() { FileName  = "Test-File" }
            });
            pb.Add(a => a.OnDelete, file =>
            {
                deleteFile = file;
                return Task.FromResult(true);
            });
        });
        await cut.InvokeAsync(() => cut.Find(".delete-icon").Click());
        Assert.NotNull(deleteFile);
        Assert.Null(deleteFile!.Error);

        deleteFile = null;
        // 上传失败测试
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.DefaultFileList, new List<UploadFile>()
            {
                new UploadFile() { FileName  = "Test-File2", Code = 1001 }
            });
        });
        await cut.InvokeAsync(() => cut.Find(".delete-icon").Click());
        Assert.NotNull(deleteFile);
    }

    [Fact]
    public void ButtonUpload_ShowProgress_Ok()
    {
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.ShowProgress, true);
            pb.Add(a => a.OnChange, async file =>
            {
                await file.SaveToFileAsync("1.txt");
            });
        });
        var input = cut.FindComponent<InputFile>();
        cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile()
        })));
    }

    [Fact]
    public async Task ButtonUpload_IsDirectory_Ok()
    {
        var fileNames = new List<string>();
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.IsDirectory, true);
            pb.Add(a => a.OnChange, file =>
            {
                fileNames.Add(file.OriginFileName!);
                return Task.CompletedTask;
            });
        });
        var input = cut.FindComponent<InputFile>();
        await cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile(),
            new MockBrowserFile("UploadTestFile2")
        })));
        Assert.Equal(2, fileNames.Count);
    }

    [Fact]
    public void ButtonUpload_Accept_Ok()
    {
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.Accept, ".jpg");
        });
        cut.Contains("accept=\".jpg\"");
    }

    [Fact]
    public void ButtonUpload_OnGetFileFormat_Ok()
    {
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.DefaultFileList, new List<UploadFile>()
            {
                new UploadFile() { FileName  = "1.csv" },
                new UploadFile() { FileName  = "1.xls" },
                new UploadFile() { FileName  = "1.xlsx" },
                new UploadFile() { FileName  = "1.doc" },
                new UploadFile() { FileName  = "1.docx" },
                new UploadFile() { FileName  = "1.dot" },
                new UploadFile() { FileName  = "1.ppt" },
                new UploadFile() { FileName  = "1.pptx" },
                new UploadFile() { FileName  = "1.wav" },
                new UploadFile() { FileName  = "1.mp3" },
                new UploadFile() { FileName  = "1.mp4" },
                new UploadFile() { FileName  = "1.mov" },
                new UploadFile() { FileName  = "1.mkv" },
                new UploadFile() { FileName  = "1.cs" },
                new UploadFile() { FileName  = "1.html" },
                new UploadFile() { FileName  = "1.vb" },
                new UploadFile() { FileName  = "1.pdf" },
                new UploadFile() { FileName  = "1.zip" },
                new UploadFile() { FileName  = "1.rar" },
                new UploadFile() { FileName  = "1.iso" },
                new UploadFile() { FileName  = "1.txt" },
                new UploadFile() { FileName  = "1.log" },
                new UploadFile() { FileName  = "1.jpg" },
                new UploadFile() { FileName  = "1.jpeg" },
                new UploadFile() { FileName  = "1.png" },
                new UploadFile() { FileName  = "1.bmp" },
                new UploadFile() { FileName  = "1.gif" },
                new UploadFile() { FileName  = "1.test" },
                new UploadFile() { FileName  = "1" }
            });
        });
        cut.Contains("fa-regular fa-file-excel");
        cut.Contains("fa-regular fa-file-word");
        cut.Contains("fa-regular fa-file-powerpoint");
        cut.Contains("fa-regular fa-file-audio");
        cut.Contains("fa-regular fa-file-video");
        cut.Contains("fa-regular fa-file-code");
        cut.Contains("fa-regular fa-file-pdf");
        cut.Contains("fa-regular fa-file-archive");
        cut.Contains("fa-regular fa-file-text");
        cut.Contains("fa-regular fa-file-image");
        cut.Contains("fa-regular fa-file");

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.OnGetFileFormat, extensions =>
            {
                return "fa-format-test";
            });
        });
        cut.Contains("fa-format-test");
    }

    [Fact]
    public async Task CardUpload_Ok()
    {
        var zoom = false;
        var deleted = false;
        var cut = Context.RenderComponent<CardUpload<string>>(pb =>
        {
            pb.Add(a => a.OnDelete, file =>
            {
                deleted = true;
                return Task.FromResult(true);
            });
            pb.Add(a => a.DefaultFileList, new List<UploadFile>()
            {
                new UploadFile() { FileName  = "Test-File1.text" },
                new UploadFile() { FileName  = "Test-File2.jpg" },
                new UploadFile() { PrevUrl  = "Test-File3.png" },
                new UploadFile() { PrevUrl  = "Test-File4.bmp" },
                new UploadFile() { PrevUrl  = "Test-File5.jpeg" },
                new UploadFile() { PrevUrl  = "Test-File6.gif" },
                new UploadFile() { PrevUrl  = "data:image/png;base64,iVBORw0KGgoAAAANS=" },
                new UploadFile() { FileName = null! }
            });
        });
        cut.Contains("bb-previewer collapse active");

        // OnZoom
        await cut.InvokeAsync(() => cut.Find(".btn-secondary").Click());
        Assert.False(zoom);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.OnZoomAsync, file =>
            {
                zoom = true;
                return Task.CompletedTask;
            });
        });
        await cut.InvokeAsync(() => cut.Find(".btn-secondary").Click());
        Assert.True(zoom);

        // OnDelete
        await cut.InvokeAsync(() => cut.Find(".btn-outline-danger").Click());
        Assert.True(deleted);

        // ShowProgress
        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.ShowProgress, true);
            pb.Add(a => a.OnChange, async file =>
            {
                await file.SaveToFileAsync("1.txt");
            });
        });
        var input = cut.FindComponent<InputFile>();
        await cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile("test.txt", "Image-Png")
        })));
        await cut.InvokeAsync(() => input.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(new List<MockBrowserFile>()
        {
            new MockBrowserFile("test.png")
        })));
    }

    [Fact]
    public async Task CardUpload_Reset()
    {
        var cut = Context.RenderComponent<CardUpload<string>>();
        await cut.InvokeAsync(() => cut.Instance.Reset());
        Assert.Null(cut.Instance.DefaultFileList);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.DefaultFileList, new List<UploadFile>()
            {
                new UploadFile() { FileName  = "Test-File1.text" }
            });
        });
        await cut.InvokeAsync(() => cut.Instance.Reset());
        Assert.NotNull(cut.Instance.DefaultFileList);
        Assert.Empty(cut.Instance.DefaultFileList);
    }

    [Fact]
    public async Task CardUpload_ShowDownload()
    {
        var clicked = false;
        var cut = Context.RenderComponent<CardUpload<string>>(pb =>
        {
            pb.Add(a => a.ShowDownloadButton, true);
            pb.Add(a => a.OnDownload, file =>
            {
                clicked = true;
                return Task.CompletedTask;
            });
            pb.Add(a => a.DefaultFileList, new List<UploadFile>()
            {
                new UploadFile() { FileName  = "Test-File1.text" }
            });
        });

        var button = cut.FindAll(".btn-secondary");
        await cut.InvokeAsync(() => button[1].Click());
        Assert.True(clicked);
    }

    [Fact]
    public void CardUpload_ValidateForm_Ok()
    {
        var foo = new Foo();
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(a => a.Model, foo);
            pb.AddChildContent<CardUpload<string>>(pb =>
            {
                pb.Add(a => a.Value, foo.Name);
                pb.Add(a => a.ValueExpression, foo.GenerateValueExpression());
            });
        });
        cut.Contains("form-label");
    }

    [Fact]
    public void CardUpload_IconTemplate_Ok()
    {
        var foo = new Foo();
        var cut = Context.RenderComponent<CardUpload<string>>(pb =>
        {
            pb.Add(a => a.DefaultFileList, new List<UploadFile>()
            {
                new UploadFile() { FileName  = "Test-File1.text" }
            });
            pb.Add(a => a.IconTemplate, file => builder =>
            {
                builder.AddContent(0, "custom-file-icon-template");
            });
        });
        cut.Contains("custom-file-icon-template");
    }

    [Fact]
    public void FileSize_Ok()
    {
        var validator = new FileValidationAttribute()
        {
            FileSize = 5
        };
        var p = new Person()
        {
            Picture = new MockBrowserFile("test.log")
        };
        var result = validator.GetValidationResult(p.Picture, new ValidationContext(p));
        Assert.NotEqual(ValidationResult.Success, result);
    }

    [Fact]
    public void FileExtensions_Ok()
    {
        var validator = new FileValidationAttribute()
        {
            Extensions = new string[] { "jpg" }
        };
        var p = new Person()
        {
            Picture = new MockBrowserFile("test.log")
        };
        var result = validator.GetValidationResult(p.Picture, new ValidationContext(p));
        Assert.NotEqual(ValidationResult.Success, result);
    }

    [Fact]
    public void IsValid_Ok()
    {
        var validator = new FileValidationAttribute()
        {
            Extensions = new string[] { "jpg" }
        };
        var p = new Person()
        {
            Picture = new MockBrowserFile("test.log")
        };
        Assert.False(validator.IsValid(p.Picture));
    }

    [Fact]
    public void Validate_Ok()
    {
        var validator = new FileValidationAttribute()
        {
            Extensions = new string[] { "jpg" }
        };
        var p = new Person()
        {
            Picture = new MockBrowserFile("test.log")
        };
        Assert.Throws<ValidationException>(() => validator.Validate(p.Picture, "Picture"));
        Assert.Throws<ValidationException>(() => validator.Validate(p.Picture, new ValidationContext(p)));
    }

    [Fact]
    public void Capture_Ok()
    {
        var cut = Context.RenderComponent<ButtonUpload<string>>(pb =>
        {
            pb.Add(a => a.Capture, "camera");
        });
        cut.Contains("capture=\"camera\"");
    }

    private class Person
    {
        [Required]
        [FileValidation(Extensions = new string[] { ".png", ".jpg", ".jpeg" })]
        public IBrowserFile? Picture { get; set; }
    }

    private class MockBrowserFile : IBrowserFile
    {
        public MockBrowserFile(string name = "UploadTestFile", string contentType = "text")
        {
            Name = name;
            LastModified = DateTimeOffset.Now;
            Size = 10;
            ContentType = contentType;
        }

        public string Name { get; }

        public DateTimeOffset LastModified { get; }

        public long Size { get; }

        public string ContentType { get; }

        public Stream OpenReadStream(long maxAllowedSize = 512000, CancellationToken cancellationToken = default)
        {
            return new MemoryStream(new byte[] { 0x01, 0x02 });
        }
    }
}
