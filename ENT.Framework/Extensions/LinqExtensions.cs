namespace ENT.Framework.Extensions;

public static class LinqExtensions
{
    public static bool ContainsIgnoreCase(this string source, string value)
    {
        if (source == null || value == null)
            return false;

        return source.ToLower().Contains(value.ToLower());
    }
}