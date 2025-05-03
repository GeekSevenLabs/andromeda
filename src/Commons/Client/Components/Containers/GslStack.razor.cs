// ReSharper disable once CheckNamespace
namespace Andromeda;

public partial class GslStack : GslComponentBase
{
    private string CssClass => CssBuilder
        .Default("tw:flex")
        .AddClass("tw:flex-row", Direction == GslDirection.Row)
        .AddClass("tw:flex-col", Direction == GslDirection.Column)
        .AddClass("tw:gap-0", Gap == GslGap.None)
        .AddClass("tw:gap-2", Gap == GslGap.Small) 
        .AddClass("tw:gap-6", Gap == GslGap.Medium)
        .AddClass("tw:gap-8", Gap == GslGap.Large)
        .AddClass("tw:items-start", Alignment == GslAlignment.Start)
        .AddClass("tw:items-center", Alignment == GslAlignment.Center)
        .AddClass("tw:items-end", Alignment == GslAlignment.End)
        .AddClass("tw:items-stretch", Alignment == GslAlignment.Stretch)
        .AddClass("tw:justify-start", Justify == GslJustify.Start)
        .AddClass("tw:justify-center", Justify == GslJustify.Center)
        .AddClass("tw:justify-end", Justify == GslJustify.End)
        .AddClass("tw:justify-stretch", Justify == GslJustify.Stretch)
        .AddClass("tw:justify-between", Justify == GslJustify.Default)
        .AddClass(Class)
        .Build();
    
    [Parameter, EditorRequired] public required RenderFragment ChildContent { get; set; }
    
    [Parameter] public required GslGap Gap { get; set; } = GslGap.Small;
    [Parameter] public required GslAlignment Alignment { get; set; } = GslAlignment.Default;
    [Parameter] public required GslJustify Justify { get; set; } = GslJustify.Default;
    [Parameter] public required GslDirection Direction { get; set; } = GslDirection.Column;
    
}

public enum GslJustify
{
    Default,
    Start,
    Center,
    End,
    Stretch,
    Between
}

public enum GslAlignment
{
    Default,
    Start,
    Center,
    End,
    Stretch
}

public enum GslDirection
{
    Row,
    Column
}

public enum GslGap 
{
    None,
    Small,
    Medium,
    Large
}