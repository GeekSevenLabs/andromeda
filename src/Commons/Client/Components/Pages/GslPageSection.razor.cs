// ReSharper disable once CheckNamespace
namespace Andromeda;

public partial class GslPageSection : GslComponentBase
{
    [Parameter] public string? Label { get; set; }
    [Parameter] public GslGap Gap { get; set; } = GslGap.Medium;
    [Parameter] public bool NoPaper { get; set; }
    [Parameter, EditorRequired] public required RenderFragment ChildContent { get; set; }
}