namespace BootstrapBlazor.Shared.Components;

public partial class CalendarCrewDialogBody
{
    [Parameter]
    [EditorRequired]
    [NotNull]
    public CalendarCellValue? Value { get; set; }

    [Parameter]
    [EditorRequired]
    [NotNull]
    public List<Crew>? Crews { get; set; }

    private static void OnUpdateValue(Crew crew, int interval)
    {
        crew.Value += interval;
    }
}
