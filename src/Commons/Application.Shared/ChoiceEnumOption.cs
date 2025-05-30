// ReSharper disable once CheckNamespace
namespace Andromeda;

public record ChoiceEnumOption<TEnum>(TEnum Value, string Name, string ShortName) where TEnum : struct, Enum
{
    public string CombinedName => ShortName.IsNotNullOrWhiteSpace() ? $"{Name} ({ShortName})" : Name;
    public override string ToString() => Name;
}