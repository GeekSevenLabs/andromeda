// ReSharper disable once CheckNamespace
namespace Andromeda;

public static class ObjectExtensions
{
    public static bool IsNotNull<T>(this T? value) where T : class => value is not null; 
    public static bool IsNull<T>(this T? value) where T : class => value is null;
}