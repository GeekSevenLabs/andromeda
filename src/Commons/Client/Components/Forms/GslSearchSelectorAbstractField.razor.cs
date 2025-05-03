using System.Linq.Expressions;
using Microsoft.AspNetCore.Components.Forms;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public abstract partial class GslSearchSelectorAbstractField<TModel, TValue> : GslComponentBase where TModel : class where TValue : struct
{
    private readonly Dictionary<TValue, TModel> _options = [];

    [CascadingParameter] public EditContext? EditContext { get; set; }
    
    [Parameter] public string? Label { get; set; }
    [Parameter] public string? Placeholder { get; set; }
    [Parameter] public string? HelpText { get; set; }
    
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public bool ReadOnly { get; set; }
    [Parameter] public bool Clearable { get; set; }
    
    [Parameter] public required TValue? Value { get; set; }
    [Parameter] public required EventCallback<TValue?> ValueChanged { get; set; }
    [Parameter] public required Expression<Func<TValue?>> ValueExpression { get; set; }
    
    [Parameter] public required TModel? Model { get; set; }
    [Parameter] public required EventCallback<TModel?> ModelChanged { get; set; }
    
    protected abstract Func<string, Task<TModel[]>> Search { get; }
    protected abstract Func<TValue, Task<TModel>> Recover { get; }
    protected abstract Func<TModel, string> ToText { get; }
    protected abstract Func<TModel, TValue> ToValue { get; }

    protected override async Task OnParametersSetAsync()
    {
        if (!Value.Equals(null) && !_options.ContainsKey(Value.Value))
        {
            try
            {
                var option = await Recover(Value.Value);
                _options[ToValue(option)] = option;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }
            
        await base.OnParametersSetAsync();
    }
    
    private async Task<IEnumerable<TValue?>> SearchAsync(string term, CancellationToken _)
    {
        var options = await Search(term);
            
        foreach (var option in options)
        {
            _options[ToValue(option)] = option;
        }
            
        return options.Select(ToValue).Cast<TValue?>().ToArray();
    }
    
    private string? GetText(TValue? value)
    {
        if(value is null) return null;
        return !_options.TryGetValue(value.Value, out var option) ? null : ToText(option);
    }

    private async Task OnValueChanged(TValue? value)
    {
        if (value is null)
        {
            await ClearAsync();
            return;
        }

        if (_options.TryGetValue(value.Value, out var model))
        {
            await NotificationAsync(model);
        }
        
        try
        {
            var option = await Recover(value.Value);
            _options[value.Value] = option;
            
            if (option.IsNull())
            {
                await ClearAsync();
                return;
            }
            
            await NotificationAsync(option);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await ClearAsync();
        }   
    }
    
    private async Task ClearAsync()
    {
        Value = null;
        await ValueChanged.InvokeAsync(Value);
        
        Model = null;
        await ModelChanged.InvokeAsync(Model);
    }

    private async Task NotificationAsync(TModel model)
    {
        Value = ToValue(model);
        await ValueChanged.InvokeAsync(Value);
        
        Model = model;
        await ModelChanged.InvokeAsync(Model);
    }

}