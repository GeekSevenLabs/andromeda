using System.Globalization;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public static class DecimalExtensions
{
    private const string DefaultValue = "-";
    
    public static string ToCurrencyOrDefault(this decimal? value, string defaultValue = DefaultValue)
    {
        return value.HasValue ? value.Value.ToCurrency() : defaultValue;
    }
    
    public static string ToCurrency(this decimal value)
    {
        return $"R$ {value.ToBrFormat()}";
    }

    public static string? ToBrFormat(this decimal? value)
    {
        if (!value.HasValue) { return ""; }
        return value.Value.ToBrFormat();
    }

    public static string ToBrFormat(this decimal value)
    {
        return value.ToString(format: "#,##0.00", new CultureInfo("PT-BR"));
    }

    public static string ToPercentage(this decimal? value)
    {
        if (!value.HasValue) { return ""; }
        return $"{value.ToBrFormat()}%";
    }
}