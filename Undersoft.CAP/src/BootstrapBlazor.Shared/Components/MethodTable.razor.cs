namespace BootstrapBlazor.Shared.Components;

public sealed partial class MethodTable
{
    [Inject]
    [NotNull]
    private IStringLocalizer<MethodTable>? Localizer { get; set; }

    [Parameter]
    [NotNull] 
    public string? Title { get; set; }

    [Parameter] public IEnumerable<MethodItem>? Items { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Title ??= Localizer[nameof(Title)];

    }
}


