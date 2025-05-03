// ReSharper disable once CheckNamespace
namespace Andromeda;

public partial class GslPageHeader : GslComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [CascadingParameter] public required GslPage Page { get; set; }
}