using System.Text;

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

    public static string SplitByUppercase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var sb = new StringBuilder();
        foreach (var c in input)
        {
            if (char.IsUpper(c) && sb.Length > 0)
            {
                sb.Append(' ');
            }

            sb.Append(c);
        }

        return sb.ToString();
    }
}
