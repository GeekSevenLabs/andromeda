// ReSharper disable once CheckNamespace
namespace Andromeda;

public partial class GslPageSection : GslComponentBase
{
    [Parameter] public string? Label { get; set; }
    [Parameter] public GslGap Gap { get; set; } = GslGap.Medium;
    [Parameter, EditorRequired] public required RenderFragment ChildContent { get; set; }
}