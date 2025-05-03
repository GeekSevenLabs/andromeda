// ReSharper disable once CheckNamespace
namespace Andromeda;

public partial class GslPage : GslComponentBase
{
    private string CssClassContainer => CssBuilder.Default(Class).Build();
    
    [Parameter, EditorRequired] public required string Title { get; set; }
    [Parameter] public string BackHref { get; set; } = string.Empty;
    
    [Parameter] public MaxWidth MaxWidth { get; set; } = MaxWidth.Medium;
    
    [Parameter, EditorRequired] public required RenderFragment ChildContent { get; set; }
}