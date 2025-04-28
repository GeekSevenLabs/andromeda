// ReSharper disable once CheckNamespace
namespace Andromeda;

public static class DecimalExtensions
{
    public static string ToCurrency(this decimal value) => value.ToString("C", CultureHelper.Brazilian);
    public static string ToCurrency(this decimal? value) => value?.ToCurrency() ?? string.Empty;
}