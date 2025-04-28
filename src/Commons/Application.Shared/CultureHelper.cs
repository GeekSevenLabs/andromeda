using System.Globalization;

namespace Andromeda;

public static class CultureHelper
{
    public static CultureInfo Brazilian { get; private set; } = new ("pt-BR"); 
}