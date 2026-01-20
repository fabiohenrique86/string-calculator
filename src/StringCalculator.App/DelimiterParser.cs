using System.Text.RegularExpressions;

namespace StringCalculator.App;

public static class DelimiterParser
{
    public static (string numbers, List<string> delimiters) Parse(string input)
    {
        var delimiters = new List<string> { ",", "\n" };

        if (!input.StartsWith("//"))
            return (input, delimiters);

        var parts = input.Split('\n', 2);
        var delimiterSection = parts[0];

        var matches = Regex.Matches(delimiterSection, @"\[(.*?)\]");
        if (matches.Count > 0)
            delimiters.AddRange(matches.Select(m => m.Groups[1].Value));
        else
            delimiters.Add(delimiterSection[2..]);

        return (parts.Length > 1 ? parts[1] : string.Empty, delimiters);
    }
}
