// ReSharper disable once CheckNamespace
namespace Andromeda;

public abstract class GslComponentBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; } = [];
    [Parameter] public string Class { get; set; } = string.Empty;
    [Parameter] public string Style { get; set; } = string.Empty;
}