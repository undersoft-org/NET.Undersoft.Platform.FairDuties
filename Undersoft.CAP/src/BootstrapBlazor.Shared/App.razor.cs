using BootstrapBlazor.Shared.Extensions;

namespace BootstrapBlazor.Shared;

public partial class App
{
    [Inject]
    [NotNull]
    private IStringLocalizer<App>? Localizer { get; set; }

    [Inject]
    [NotNull]
    private IDispatchService<GiteePostBody>? DispatchService { get; set; }

    [Inject]
    [NotNull]
    private ToastService? Toast { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        DispatchService.Subscribe(Notify);
    }

    protected override Task InvokeInitAsync() => InvokeVoidAsync("init", Localizer["ErrorMessage"].Value, Localizer["Reload"].Value);

    private async Task Notify(DispatchEntry<GiteePostBody> payload)
    {
        if (payload.CanDispatch())
        {
            var option = new ToastOption()
            {
                Category = ToastCategory.Information,
                Title = "代码提交推送通知",
                Delay = 120 * 1000,
                ForceDelay = true,
                ChildContent = BootstrapDynamicComponent.CreateComponent<CommitItem>(new Dictionary<string, object?>
                {
                    [nameof(CommitItem.Item)] = payload.Entry
                }).Render()
            };
            await Toast.Show(option);
        }
    }

    protected override async ValueTask DisposeAsync(bool disposing)
    {
        if (disposing)
        {
            DispatchService.UnSubscribe(Notify);
        }
        await base.DisposeAsync(disposing);
    }
}
