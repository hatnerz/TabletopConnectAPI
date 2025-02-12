namespace TabletopConnect.Common.Extensions;

public static class StringExtensions
{
    public static string MakeFirstLetterUppercase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpperInvariant(input[0]) + input[1..];
    }

    public static string MakeFirstLetterLowercase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToLowerInvariant(input[0]) + input[1..];
    }
}
